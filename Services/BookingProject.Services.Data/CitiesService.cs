namespace BookingProject.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BookingProject.Data.Common.Repositories;
    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public CitiesService(IDeletableEntityRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<City> query =
                this.citiesRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
            var city = this.citiesRepository.All().Where(x => x.Name == name)
                .To<T>().FirstOrDefault();
            return city;
        }
    }
}
