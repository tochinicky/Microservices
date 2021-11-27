using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> seeding data.........");
                context.Platforms.AddRange(
                    new Platform { Cost = "Free", Name = "Dot Net", Publisher = "Microsoft" },
                    new Platform { Cost = "Free", Name = "Sql Server Express", Publisher = "Microsoft" },
                    new Platform { Cost = "Free", Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation" }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> we already have data");
            }
        }
    }
}
