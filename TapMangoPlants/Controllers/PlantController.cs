using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TapMangoPlants.Context;
using TapMangoPlants.Model;

namespace TapMangoPlants.Controllers
{
    [ApiController]
    [Route("api/plant")]
    public class PlantController : ControllerBase
    {


        private readonly ApiContext _context;

        public PlantController(ApiContext apiContext)
        {
            _context = apiContext;
        }

        [HttpGet]
        public async Task<IList<Plant>> Get()
        {
            return await _context.Plants.ToListAsync().ConfigureAwait(false);
        }

    }
}
