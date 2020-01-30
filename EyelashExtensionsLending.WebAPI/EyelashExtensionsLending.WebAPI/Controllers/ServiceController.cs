using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EyelashExtensionsLending.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private EELendingDataContext _db;

        public ServicesController(EELendingDataContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> Get()
        {
            return await _db.Services.ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Service service = _db.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
                return NotFound();
            return new ObjectResult(service);
        }

        [HttpPost]
        public async Task<ActionResult<Service>> Post(Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }

            _db.Services.Add(service);
            await _db.SaveChangesAsync();
            return Ok(service);
        }

        [HttpPut]
        public async Task<ActionResult<Service>> Put(Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }
            if (!_db.Services.Any(x => x.Id == service.Id))
            {   
                return NotFound();
            }

            _db.Update(service);
            await _db.SaveChangesAsync();
            return Ok(service);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> Delete(int id)
        {
            Service service = _db.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            _db.Services.Remove(service);
            await _db.SaveChangesAsync();
            return Ok(service);
        }

    }
}