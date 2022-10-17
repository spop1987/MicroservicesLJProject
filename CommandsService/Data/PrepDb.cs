using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsService.Models;

namespace CommandsService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var platforms = new List<Platform>();

                SeedData(serviceScope.ServiceProvider.GetService<ICommandRepo>(), platforms);
            }
        }

        private static void SeedData(ICommandRepo repo, IEnumerable<Platform> platforms)
        {
            Console.WriteLine("--> CommandService Api: Seeding new platforms...");

            foreach (var platform in platforms)
            {
                if(!repo.ExternalPlatformExists(platform.ExternalId))
                    repo.CreatePlatform(platform);
                
                repo.SaveChanges();
            }
        }
    }
}