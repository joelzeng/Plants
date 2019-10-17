using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TapMangoPlants.Context;
using TapMangoPlants.Model;
using TapMangoPlants.Repository;

namespace TapMangoPlants.Services
{
    public class PlantService : IPlantService
    {
        
        private readonly IPlantRepository _plantRepository;

        public PlantService(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<IList<Plant>> GetAllPlantsAsync()
        {
            return await _plantRepository.GetAllPlantsAsync().ConfigureAwait(false);
        }

        public Plant WaterPlant(string id)
        {
            return _plantRepository.WaterPlant(id);
        }
    }
}
