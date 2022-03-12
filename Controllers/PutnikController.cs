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
    public class PutnikController : ControllerBase
    {
        public AutobuskaStanicaContext Context {get; set;}
        public PutnikController(AutobuskaStanicaContext context)
        {
            Context = context;
        }

        [Route("DodajPutnika/{ime}/{prezime}/{jmbg}")]
        [HttpPost]
        public async Task<ActionResult> dodajPutnika(string ime,string prezime,string jmbg)
        {
            try
            {
                var putnik = await Context.Putnici.Where(x=>x.JMBG == jmbg).FirstOrDefaultAsync();
                if(putnik == null)
                {
                    Putnik a = new Putnik
                    {
                        Ime = ime,
                        Prezime = prezime,
                        JMBG = jmbg
                    };
                    Context.Putnici.Add(a);
                    await Context.SaveChangesAsync();
                    return Ok("Uspesno dodat putnik");
                }
                else
                {
                    return BadRequest("Putnik vec postoji");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        

        [Route("izbrisiPutnika/{jmbg}")]
        [HttpDelete]
        public async Task<ActionResult> izbrisiPutnika(string jmbg)
        {
            try
            {
                if(jmbg!=null && jmbg.Length==13)
                {
                    var putnik = await Context.Putnici.Where(x => x.JMBG == jmbg).FirstOrDefaultAsync();
                    if(putnik != null)
                    {
                        Context.Putnici.Remove(putnik);
                        await Context.SaveChangesAsync();
                        return Ok("Uspesno obrisan putnik");
                    }
                    else
                    {
                        return BadRequest("Ne postoji putnik sa tim jmbgom");
                    }
                }
                else
                {
                    return BadRequest("neispravan jbmbg");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}