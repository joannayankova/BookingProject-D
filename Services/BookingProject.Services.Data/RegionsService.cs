namespace BookingProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using BookingProject.Data.Common.Repositories;
    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class RegionsService : IRegionsService
    {
        private readonly IDeletableEntityRepository<Region> regionsRepository;

        public RegionsService(IDeletableEntityRepository<Region> regionsRepository)
        {
            this.regionsRepository = regionsRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Region> query =
                this.regionsRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
            var region = this.regionsRepository.All().Where(x => x.Name == name)
                .To<T>().FirstOrDefault();
            return region;
        }

        public T GetById<T>(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
