using System.Collections.Generic;
using System.Threading.Tasks;
using TapMangoPlants.Model;

namespace TapMangoPlants.Services
{ 
    public interface IPlantService
    {
        Task<IList<Plant>> GetAllPlantsAsync();

        Plant WaterPlant(string id);
    }
}