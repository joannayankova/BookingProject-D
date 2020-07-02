namespace BookingProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BookingProject.Data.Common.Repositories;
    using BookingProject.Data.Models;
    using BookingProject.Services.Data.IServices;
    

    public class ReservationsService : IReservationsService
    {
        private readonly IDeletableEntityRepository<Reservation> reservationsRepository;

        private readonly IPlacesService placesService;

        public ReservationsService(IDeletableEntityRepository<Reservation> reservationsRepository, IPlacesService placesService)
        {
            this.reservationsRepository = reservationsRepository;
            this.placesService = placesService;
        }

        //public IEnumerable<T> GetAll<T>(int? count = null)
        //{
        //    IQueryable<Reservation> query =
        //        this.reservationsRepository.All().OrderBy(x => x.Id);
        //    if (count.HasValue)
        //    {
        //        query = query.Take(count.Value);
        //    }

        //    //return query.To<T>().ToList();
        //}

        public async Task<int> CreateReservationAsync(
            int placeId,
            string userId,
            string dates)
        {
            string[] splitDates = dates.Split(" - ");

            var reservation = new Reservation
            {
                PlaceId = placeId,
                UserId = userId,
                StartDate = DateTime.Parse(splitDates[0]),
                EndDate = DateTime.Parse(splitDates[1]),
            };

            await this.reservationsRepository.AddAsync(reservation);
            await this.reservationsRepository.SaveChangesAsync();
            return reservation.Id;
        }
    }
}
