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
    using BookingProject.Services.Mapping;

    public class ReservationsService : IReservationsService
    {
        private readonly IDeletableEntityRepository<Reservation> reservationsRepository;

        private readonly IPlacesService placesService;

        public ReservationsService(IDeletableEntityRepository<Reservation> reservationsRepository, IPlacesService placesService)
        {
            this.reservationsRepository = reservationsRepository;
            this.placesService = placesService;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Reservation> query =
                this.reservationsRepository.All().OrderBy(r => r.Id);

            return query.To<T>().ToList();
        }

        public IEnumerable<T> GetAllByUser<T>(string userId)
        {
            IQueryable<Reservation> query =
                this.reservationsRepository.All().Where(r => r.UserId == userId).OrderBy(r => r.Id);

            return query.To<T>().ToList();
        }

        public IEnumerable<T> GetAllByPlace<T>(int placeId)
        {
            IQueryable<Reservation> query =
                this.reservationsRepository.All().Where(r => r.PlaceId == placeId).OrderBy(r => r.Id);

            return query.To<T>().ToList();
        }

        public async Task<int> CreateReservationAsync(
            int placeId,
            string userId,
            string dates,
            double pricePerNight,
            double totalPrice,
            int numNights)
        {
            string[] splitDates = dates.Split(" - ");

            var reservation = new Reservation
            {
                PlaceId = placeId,
                UserId = userId,
                StartDate = DateTime.Parse(splitDates[0]),
                EndDate = DateTime.Parse(splitDates[1]),
                PricePerNight = pricePerNight,
                TotalPrice = totalPrice,
                NumNights = numNights,
            };

            await this.reservationsRepository.AddAsync(reservation);
            await this.reservationsRepository.SaveChangesAsync();
            return reservation.Id;
        }
    }
}
