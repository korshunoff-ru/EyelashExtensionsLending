using EyelashExtensionsLending.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EyelashExtensionsLending.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DateController
    {

        private EELendingDataContext _db;

        public DateController(EELendingDataContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Gets current date and time
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public DateTime Get()
        {
            return DateTime.Now;
        }

    }
}
