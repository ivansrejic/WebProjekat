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
                    Vreme = x.datum,
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
                var karta = await Context.Karte.Include(p=>p.PutnikFK).Include(a=>a.AutobusFK).Where(x=>x.PutnikFK.JMBG == jmbg).Select(y=>
                new
                {
                    Ime = y.PutnikFK.Ime,
                    Prezime = y.PutnikFK.Prezime,
                    JMBG = y.PutnikFK.JMBG,
                    Cena = y.Cena,
                    Vreme = y.datum,
                    Prevoznik = y.AutobusFK.NazivPrevoznika,
                    Destinacija = y.AutobusFK.Destinacija,
                    brojSedista = y.BrojSedista,

                }).ToListAsync();
                if(karta != null)
                {
                    return Ok(karta);
                }
                else
                    return BadRequest("Ne postoji");
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
                    Vreme = y.datum,
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
                    Vreme = y.datum,
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

        [Route("KupiKartu/{brSedista}/{destinacija}/{jmbg}")]
        [HttpPost]
        public async Task<ActionResult>kupiKartu(int brSedista,string destinacija,string jmbg,DateTime datumm)
        {
            try
            {
                if(jmbg.Length == 13 && jmbg != null && brSedista <16 && brSedista >1)
                {
                    int cena;
                    var putnik = await Context.Putnici.Where(x=>x.JMBG == jmbg).FirstOrDefaultAsync();
                    var bus = await Context.Autobusi.Where(x=>x.Destinacija == destinacija).FirstOrDefaultAsync();
                    if(destinacija == "Beograd")
                    {
                        cena = 300;
                    }
                    else
                    {
                        cena = 200;
                    }
                    Karta k = new Karta
                    {
                        BrojSedista = brSedista,
                        Cena = cena,
                        datum = datumm,
                        PutnikFK = putnik,
                        AutobusFK = bus
                    };
                    Context.Karte.Add(k);
                    await Context.SaveChangesAsync();
                    return Ok("Uspesno kupljena karta");
                }
                else
                {
                    return BadRequest("Pogresno uneti podaci");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("IzbrisiKupljenuKartu/{jmbg}/{brSedista}")]
        [HttpDelete]
        public async Task<ActionResult> izbrisiKupljenuKartu(string jmbg,int brSedista)
        {
            try
            {
                if(jmbg!=null && jmbg.Length==13)
                {
                    var karta = await Context.Karte.Include(p=>p.PutnikFK).Include(h=>h.AutobusFK).Where(x=>x.PutnikFK.JMBG == jmbg).Where(x=>x.BrojSedista == brSedista).FirstOrDefaultAsync();
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

        [Route("IzmeniBrojSedista/{jmbg}/{brSedista}")]
        [HttpPut]
        public async Task<ActionResult> izmeniKartu(string jmbg,int brSedista,int novoSediste)
        {
            var karta = await Context.Karte.Include(p=>p.PutnikFK).Where(x=>x.PutnikFK.JMBG == jmbg).Where(p=>p.BrojSedista == brSedista).FirstOrDefaultAsync();
            karta.BrojSedista = novoSediste;
            try
            {
                Context.Karte.Update(karta);
                await Context.SaveChangesAsync();
                return Ok("Uspesno izmenjeno");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    } // Dodaj validaciju svuda
}