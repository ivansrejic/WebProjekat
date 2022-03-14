using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Models;

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
                    return BadRequest("fddsffds");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("KupiKartu/{brSedista}/{jmbg}/{destinacija}")]
        [HttpPost]
        public async Task<ActionResult>kupiKartu(int brSedista,string jmbg,string destinacija)
        {   
            try
            {           
                int cena;
                if(destinacija == "Beograd")
                    {
                         cena = 300;
                    }
                else
                    {
                         cena = 200;
                    }
                
                var kupljenaKarta = await Context.Karte.Include(x=>x.PutnikFK).Where(x=>x.PutnikFK.JMBG == jmbg).FirstOrDefaultAsync();
                
                if(kupljenaKarta == null)
                {
                    if(jmbg != null && jmbg.Length == 13 && brSedista < 16 && brSedista > 1)
                        {
                            var putnik = await Context.Putnici.Where(x=>x.JMBG == jmbg).FirstOrDefaultAsync();
                            var bus = await Context.Autobusi.Where(x=>x.Destinacija == destinacija).FirstOrDefaultAsync();
                            var sediste = await Context.Karte.Where(x=>x.BrojSedista == brSedista).FirstOrDefaultAsync();
                            if(putnik != null && bus != null && sediste == null)
                                {
                                    Karta k = new Karta
                                        {
                                            BrojSedista = brSedista,
                                            Cena = cena,
                                            PutnikFK = putnik,
                                            AutobusFK = bus
                                        };
                                    Context.Karte.Add(k);
                                    await Context.SaveChangesAsync();
                                    return Ok("Uspesno");
                                }
                            else
                                return BadRequest("Zauzeto sediste npr");
                                
                        }
                        else
                            return BadRequest("Pogresan jmbg ili sediste");
                    }
                    else
                    {
                        return BadRequest("Putnik je vec kupio kartu");
                    }          
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // --------------------------------------------------------------------------------------------


        // [Route("KupiKartuFromBody")]
        // [HttpPost]
        // public async Task<ActionResult> kupiKartuFromBody([FromBody]Karta karta) // u js pravi validaciju da li je kupljena karta vec, tako sto ces listi vrednosti da dodajes i da proveravas
        // {
        //     // if (predmet.Godina < 1 && predmet.Godina > 5)
        //     // {
        //     //     return BadRequest("Pogrešna Godina!");
        //     // }

        //     // // ... Ostale provere, Naziv
        //     try
        //     {
        //         Context.Karte.Add(karta);
        //         await Context.SaveChangesAsync();
        //         return Ok("Uspesno kupljena karta");

        //     }
        //     catch(Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }


        [Route("kupiKartuFromBody/{prevoznik}/{destinacija}/{brSedista}/{datum}")] // dodaj validaciju za destinaciju, za jmbg , za broj sedista da li je izmedju 1 i 16, da li je zauzeto i tako dalje
        [HttpPost]
        public async Task<ActionResult>kupiKartuFromBody([FromBody]Putnik putnikk,string prevoznik,string destinacija,int brSedista,string datum) // Za ovu fju dodaj proveru da li je vec kupljena karta i to, u java scriptu tako sto ces da napravis listu u klasi, i onda kada povlacis fetch,smesti tamo i onda proveri 
        {
            //Probaj da napravis validaciju da ne moze isti covek da kupi vise karata i da ne se proveri zauzetost sedista u odrejenom busu za odredjenu destinaciju
            
            try
            {           
                int cena;
                if(destinacija == "Beograd")
                    {
                         cena = 300;
                    }
                else
                    {
                         cena = 200;
                    }
                
                var kupljenaKarta = await Context.Karte.Where(x=>x.BrojSedista == brSedista).Include(x=>x.PutnikFK).Where(x=>x.PutnikFK.JMBG == putnikk.JMBG).Include(x=>x.AutobusFK).Where(x=>x.AutobusFK.Destinacija == destinacija).FirstOrDefaultAsync();
                var bus = await Context.Autobusi.Where(x=>x.Destinacija == destinacija).Where(x=>x.NazivPrevoznika == prevoznik).Where(x=>x.datumm == datum).FirstOrDefaultAsync();
                
                if(kupljenaKarta == null)
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
                    else
                    {
                        return BadRequest("Putnik je vec kupio kartu");
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
                    if(karta != null)
                    {
                        Context.Karte.Remove(karta);
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

        [Route("IzmeniBrojSedista/{jmbg}/{novoSediste}")]
        [HttpPut]
        public async Task<ActionResult> izmeniKartu(string jmbg,int novoSediste)
        {
            
            var karta = await Context.Karte.Include(p=>p.PutnikFK).Where(x=>x.PutnikFK.JMBG == jmbg).FirstOrDefaultAsync(); 
            try
            {
                if(jmbg.Length == 13 && jmbg != null)
                {
                    if(karta != null)
                 {
                    karta.BrojSedista = novoSediste;
                    Context.Karte.Update(karta);
                    await Context.SaveChangesAsync();
                    return Ok("Uspesno izmenjeno");
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
    }
} 