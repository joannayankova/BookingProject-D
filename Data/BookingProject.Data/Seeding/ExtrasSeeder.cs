namespace BookingProject.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BookingProject.Data.Models;

    public class ExtrasSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Extras.Any())
            {
                return;
            }

            var extras = new List<string> { "Паркинг", "Климатик", "ТВ", "Безплатен интернет", "Тераса", "Басейн", "Кухненски бокс", "Кафемашина", "Пералня" };

            foreach (var extra in extras)
            {
                await dbContext.Extras.AddAsync(new Extra
                {
                    Name = extra,
                });
            }
        }
    }
}
