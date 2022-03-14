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
                try
                {
                    Context.Autobusi.Add(autobus);
                    await Context.SaveChangesAsync();
                    return Ok($"Uspesno dodat autobus sa id {autobus.BusID}");
                }
                catch(Exception e)
                {
                    return BadRequest(e.Message);
                }
        }
    }
}
