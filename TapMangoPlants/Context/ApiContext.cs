using System;
using Microsoft.EntityFrameworkCore;
using TapMangoPlants.Model;

namespace TapMangoPlants.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; }
    }
}
