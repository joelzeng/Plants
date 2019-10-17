using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TapMangoPlants.Context;
using TapMangoPlants.Model;

namespace TapMangoPlants.Repository
{
    public class PlantRepository : IPlantRepository
    {
        
        private readonly ApiContext _context;

        public PlantRepository(ApiContext apiContext)
        {
            _context = apiContext;
        }

        public async Task<IList<Plant>> GetAllPlantsAsync()
        {
            return await _context.Plants.ToListAsync().ConfigureAwait(false);
        }
    }
}

