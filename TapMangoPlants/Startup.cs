using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TapMangoPlants.Context;
using TapMangoPlants.Model;
using TapMangoPlants.Services;
using TapMangoPlants.Repository;

namespace TapMangoPlants
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8080");
                    });
            });
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("MemoryDb"));
            services.AddScoped<IPlantService, PlantService>();
            services.AddScoped<IPlantRepository, PlantRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApiContext>();
                PopulateData(context);

            }
            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void PopulateData(ApiContext context)
        {

            IList<Plant> plants = new List<Plant>()
            {
                new Plant
                {
                    Id = "1",
                    WaterLevel = 1,
                    LastWateredTime = DateTime.Now
                },
                new Plant
                {
                    Id = "2",
                    WaterLevel = 0,
                    LastWateredTime = DateTime.Now.AddHours(-2)
                },
                new Plant
                {
                    Id = "3",
                    WaterLevel = 1,
                    LastWateredTime = DateTime.Now.AddHours(-1)
                },
                new Plant
                {
                    Id = "4",
                    WaterLevel = 0,
                    LastWateredTime = DateTime.Now
                },
                new Plant
                {
                    Id = "5",
                    WaterLevel = 0,
                    LastWateredTime = DateTime.Now.AddHours(-8)
                },
            };

            foreach(var p in plants)
            {
                context.Plants.Add(p);
            }
            context.SaveChanges();
        }
    }
}
