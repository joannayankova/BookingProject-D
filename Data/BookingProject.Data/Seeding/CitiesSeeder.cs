namespace BookingProject.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using BookingProject.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any() || dbContext.Regions.Any())
            {
                return;
            }

            // read file into a string and deserialize JSON to a type
            var cities = JsonConvert.DeserializeObject<List<CityForSeed>>(File.ReadAllText(@"C:\Users\Georgi Arihtev\source\repos\Denitsa\BookingProject-D\Data\BookingProject.Data\Seeding\cities.json"));
            Console.WriteLine(cities);

            foreach (var city in cities)
            {
                Region reg;
                if (!await dbContext.Regions.AnyAsync(r => r.Name == city.Region))
                {
                    reg = new Region
                    {
                        Name = city.Region,
                    };
                    await dbContext.Regions.AddAsync(reg);
                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    reg = await dbContext.Regions.Where(r => r.Name == city.Region).FirstOrDefaultAsync();
                }

                await dbContext.Cities.AddAsync(new City
                {
                    Name = city.Name,
                    RegionId = reg.Id,
                });
            }
        }
    }
}
