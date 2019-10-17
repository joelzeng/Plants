using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TapMangoPlants.Context;
using TapMangoPlants.Model;
using TapMangoPlants.Services;

namespace TapMangoPlants.Controllers
{
    [ApiController]
    [Route("api/plant")]
    public class PlantController : ControllerBase
    {


        private readonly IPlantService _plantService;

        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        [HttpPost] 
        [Route("GetAll")]
        public async Task<IList<PlantViewModel>> GetAll()
        {
            var plants = await _plantService.GetAllPlantsAsync().ConfigureAwait(false);
            return plants.Select(p => new PlantViewModel(p)).ToList() ;
        }

        public class PlantViewModel
        {
            public PlantViewModel(Plant plant)
            {
                Id = plant.Id;
                LastTimeWatered = plant.LastWateredTime;
            }

            public string Id { get; set; }

            public DateTime LastTimeWatered { get; set; }
        }
        
    }
}
