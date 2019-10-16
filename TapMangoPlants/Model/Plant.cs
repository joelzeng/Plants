using System;
namespace TapMangoPlants.Model
{
    public class Plant
    {
        public string Id { get; set; }

        public int WaterLevel { get; set; }

        public DateTime LastWateredTime { get; set; }
    }
}
