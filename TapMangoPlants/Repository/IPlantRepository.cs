using System.Collections.Generic;
using System.Threading.Tasks;
using TapMangoPlants.Model;

namespace TapMangoPlants.Repository
{
    public interface IPlantRepository
    {
        Task<IList<Plant>> GetAllPlantsAsync();
    }
}