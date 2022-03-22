using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.AspNetCore.Cors;

namespace Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class AutobuskaStanicaController : ControllerBase
    {
        public AutobuskaStanicaContext Context {get; set;}
        public AutobuskaStanicaController(AutobuskaStanicaContext context)
        {
            Context = context;
        }

        [Route("preuzmiSveKarte")]
        [HttpGet]
        public async Task<ActionResult> preuzmiSveKarte()
        {
            try
            {
                return Ok(await Context.Karte.Include(a=>a.PutnikFK).Include(b=>b.AutobusFK).Select(x=> 
                new
                {
                    Ime = x.PutnikFK.Ime,
                    Prezime = x.PutnikFK.Prezime,
                    JMBG = x.PutnikFK.JMBG,
                    Cena = x.Cena,
                    Vreme = x.AutobusFK.datumm,
                    Prevoznik = x.AutobusFK.NazivPrevoznika,
                    Registracija = x.AutobusFK.Registracija,
                    Destinacija = x.AutobusFK.Destinacija,
                    brojSedista = x.BrojSedista,
                }).ToListAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("preuzmiKartu/{jmbg}")]
        [HttpGet]
        public async Task<ActionResult> preuzmiKartu(string jmbg)
        {
            try
            {
                var karta = await Context.Karte.Include(p=>p.PutnikFK).Include(p=>p.AutobusFK).Where(x=>x.PutnikFK.JMBG == jmbg).FirstOrDefaultAsync();
                return Ok(karta);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        
        [Route("PreuzmiKarteZaPrevoznika/{prevoznik}")]
        [HttpGet]
        public async Task<ActionResult> preuzmiKarteZaPrevoznika(string prevoznik)
        {
            try
            {
                var karta = await Context.Karte.Include(p=>p.PutnikFK).Include(a=>a.AutobusFK).Where(x=>x.AutobusFK.NazivPrevoznika == prevoznik).Select(y=>
                new
                {
                    Ime = y.PutnikFK.Ime,
                    Prezime = y.PutnikFK.Prezime,
                    JMBG = y.PutnikFK.JMBG,
                    Cena = y.Cena,
                    Vreme = y.AutobusFK.datumm,
                    Prevoznik = y.AutobusFK.NazivPrevoznika,
                    Destinacija = y.AutobusFK.Destinacija,
                    brojSedista = y.BrojSedista,

                }).ToListAsync();
                if(karta != null)
                {
                    return Ok(karta);
                }
                else
                {
                    return BadRequest("saddsaads");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("PreuzmiKarteZaDestinaciju/{destinacija}")]
        [HttpGet]
        public async Task<ActionResult> preuzmiKarteZaDestinaciju(string destinacija)
        {
            try
            {
                var karta = await Context.Karte.Include(p=>p.PutnikFK).Include(a=>a.AutobusFK).Where(x=>x.AutobusFK.Destinacija == destinacija).Select(y=>
                new
                {
                    Ime = y.PutnikFK.Ime,
                    Prezime = y.PutnikFK.Prezime,
                    JMBG = y.PutnikFK.JMBG,
                    Cena = y.Cena,
                    Datum = y.AutobusFK.datumm,
                    Prevoznik = y.AutobusFK.NazivPrevoznika,
                    Registracija = y.AutobusFK.Registracija,
                    Destinacija = y.AutobusFK.Destinacija,
                    brojSedista = y.BrojSedista,
                }).ToListAsync();
                
                if(karta != null)
                {
                    return Ok(karta);
                }
                else
                {
                    return BadRequest("fddsffds");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [Route("KupiKartu/{brSedista}/{jmbg}/{destinacija}")]
        // [HttpPost]
        // public async Task<ActionResult>kupiKartu(int brSedista,string jmbg,string destinacija)
        // {   
        //     try
        //     {           
        //         int cena;
        //         if(destinacija == "Beograd")
        //             {
        //                  cena = 300;
        //             }
        //         else
        //             {
        //                  cena = 200;
        //             }
                
        //         var kupljenaKarta = await Context.Karte.Include(x=>x.PutnikFK).Where(x=>x.PutnikFK.JMBG == jmbg).FirstOrDefaultAsync();
                
        //         if(kupljenaKarta == null)
        //         {
        //             if(jmbg != null && jmbg.Length == 13 && brSedista < 16 && brSedista > 1)
        //                 {
        //                     var putnik = await Context.Putnici.Where(x=>x.JMBG == jmbg).FirstOrDefaultAsync();
        //                     var bus = await Context.Autobusi.Where(x=>x.Destinacija == destinacija).FirstOrDefaultAsync();
        //                     var sediste = await Context.Karte.Where(x=>x.BrojSedista == brSedista).FirstOrDefaultAsync();
        //                     if(putnik != null && bus != null && sediste == null)
        //                         {
        //                             Karta k = new Karta
        //                                 {
        //                                     BrojSedista = brSedista,
        //                                     Cena = cena,
        //                                     PutnikFK = putnik,
        //                                     AutobusFK = bus
        //                                 };
        //                             Context.Karte.Add(k);
        //                             await Context.SaveChangesAsync();
        //                             return Ok("Uspesno");
        //                         }
        //                     else
        //                         return BadRequest("Zauzeto sediste npr");
                                
        //                 }
        //                 else
        //                     return BadRequest("Pogresan jmbg ili sediste");
        //             }
        //             else
        //             {
        //                 return BadRequest("Putnik je vec kupio kartu");
        //             }          
        //     }
        //     catch(Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }



        [EnableCors ("CORS")]
        [Route("kupiKartuFromBody/{registracija}/{datum}/{cena}/{brSedista}")]
        [HttpPost]
        public async Task<ActionResult>kupiKartuFromBody([FromBody]Putnik putnikk,string registracija,string datum,int cena,int brSedista)
        {
            
            try
            {           
                
                //proveri da li je vec kupljena karta, da li postoji bus sa tom registracijom i da ide tog datuma i da li je slobodno sediste u tom busu
                var kupljenaKarta = await Context.Karte.Include(x=>x.PutnikFK).Where(x=>x.PutnikFK.JMBG == putnikk.JMBG).FirstOrDefaultAsync();
                var bus = await Context.Autobusi.Where(x=>x.Registracija == registracija).Where(x=>x.datumm == datum).FirstOrDefaultAsync();
                var zauzetoMesto = await Context.Karte.Where(x=>x.BrojSedista == brSedista).Include(x=>x.AutobusFK).Where(x=>x.AutobusFK.Registracija == registracija).Where(x=>x.AutobusFK.datumm == datum).FirstOrDefaultAsync();
                
                //if(kupljenaKarta == null && zauzetoMesto == null && bus != null )
                if(kupljenaKarta != null)
                {
                    return BadRequest("Putnik je vec kupio kartu");
                }
                else if(zauzetoMesto != null)
                {
                    return BadRequest("Mesto je zauzeto");
                }
                else if(bus == null)
                {
                    return BadRequest("Ne postoji izabrana autobuska linija");
                }
                else
                {
                                    Karta k = new Karta
                                        {
                                            BrojSedista = brSedista,
                                            Cena = cena,
                                            PutnikFK = putnikk,
                                            AutobusFK = bus
                                        };
                                    Context.Karte.Add(k);
                                    await Context.SaveChangesAsync();
                                    return Ok("Uspesno");
                                
                }        
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("IzbrisiKupljenuKartu/{jmbg}")]
        [HttpDelete]
        public async Task<ActionResult> izbrisiKupljenuKartu(string jmbg)
        {
            try
            {
                if(jmbg!=null && jmbg.Length==13)
                {
                    var karta = await Context.Karte.Include(p=>p.PutnikFK).Include(h=>h.AutobusFK).Where(x=>x.PutnikFK.JMBG == jmbg).FirstOrDefaultAsync();
                    var putnik = await Context.Putnici.Where(x=>x.JMBG == jmbg).FirstOrDefaultAsync();
                    if(karta != null)
                    {
                        Context.Karte.Remove(karta);
                        Context.Putnici.Remove(putnik);
                        await Context.SaveChangesAsync();
                        return Ok("Uspesno obrisana karta");
                    }
                    else
                        return BadRequest("Ne postoji karta");
                }
                else
                    return BadRequest("Putnik sa jmbgom nije rezervisao to sediste");
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("IzmeniBrojSedista/{registracija}/{datum}/{jmbg}/{novoSediste}")]
        [HttpPut]
        public async Task<ActionResult> izmeniKartu(string registracija,string datum,string jmbg,int novoSediste)
        {
            
            var karta = await Context.Karte.Include(p=>p.PutnikFK).Where(x=>x.PutnikFK.JMBG == jmbg).FirstOrDefaultAsync();
            var zauzeto = await Context.Karte.Where(x=>x.BrojSedista == novoSediste).Include(p=>p.AutobusFK).Where(x=>x.AutobusFK.Registracija == registracija).Where(x=>x.AutobusFK.datumm == datum).FirstOrDefaultAsync();

            try
            {
                if(jmbg.Length == 13 && jmbg != null)
                {
                    if(karta != null && zauzeto == null)
                 {
                    karta.BrojSedista = novoSediste;
                    Context.Karte.Update(karta);
                    await Context.SaveChangesAsync();
                    return Ok();
                 }
                 else
                    return BadRequest("Putnik nema kupljenu kartu");
                }
                else
                    return BadRequest("Pogresno unet jmbg");
                
                
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("VratiSedista/{registracija}/{destinacija}/{datum}")]
        [HttpGet]
        public async Task<ActionResult> vratiSedista(string registracija,string destinacija,string datum)
        {
            var bus = await Context.Autobusi.Where(x=>x.Registracija == registracija).Where(x=>x.Destinacija == destinacija).Where(x=>x.datumm == datum).FirstOrDefaultAsync();
            var listaSedista = await Context.Karte.Include(p=>p.AutobusFK).Where(p=>p.AutobusFK.Registracija == registracija).Where(x=>x.AutobusFK.Destinacija == destinacija).Where(x=>x.AutobusFK.datumm == datum).Select(p=>p.BrojSedista).ToListAsync();
            try
            {
                if(bus != null)
                {
                    if(listaSedista != null)
                    {
                    return Ok(listaSedista);
                    }
                    else
                    {
                        return BadRequest("prazna lsita"); // promeni ovo posle, da napise nesto smisleno
                    }  
                }
                else
                {
                    return BadRequest("Greska");
                }
                
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }   
} 