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
    public class AutobusController : ControllerBase
    {
        public AutobuskaStanicaContext Context {get; set;}
        public AutobusController(AutobuskaStanicaContext context)
        {
            Context = context;
        }

        [Route("DodajBus")]
        [HttpPost]
        public async Task<ActionResult> dodajBus([FromBody] Autobus autobus)
        {

                        var postoji = await Context.Autobusi.Where(x=>x.Registracija == autobus.Registracija).Where(x=>x.datumm == autobus.datumm).FirstOrDefaultAsync();
                        if(postoji == null)
                        {
                            try
                        {
                            Context.Autobusi.Add(autobus);
                            await Context.SaveChangesAsync();
                            return Ok("Uspesno dodatko");
                        }
                        catch(Exception e)
                        {
                            return BadRequest(e.Message);
                        }
                        }
                        else
                            return BadRequest("vec je dodat bus");
                        
        }

        [Route("PreuzmiAutobuse/{datum}")]
        [HttpGet]
        public async Task<ActionResult> preuzmiAutobuse(string datum)
        {
            try
            {
                var autobusi = await Context.Autobusi.Where(x=>x.datumm == datum).ToListAsync();
                if(autobusi != null)
                {
                    return Ok(autobusi);
                }
                else
                    return BadRequest($"Nema autobusa za datum -> {datum}");

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
