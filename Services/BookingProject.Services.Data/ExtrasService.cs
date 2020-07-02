namespace BookingProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BookingProject.Data.Common.Repositories;
    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class ExtrasService : IExtrasService
    {
        private readonly IDeletableEntityRepository<Extra> extrasRepository;

        public ExtrasService(IDeletableEntityRepository<Extra> extrasRepository)
        {
            this.extrasRepository = extrasRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Extra> query =
                this.extrasRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var extra = this.extrasRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
            return extra;
        }
    }
}
