namespace BookingProject.Services.Data.IServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IReservationsService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllByUser<T>(string userId);

        IEnumerable<T> GetAllByPlace<T>(int placeId);

        Task<int> CreateReservationAsync(
            int placeId,
            string userId,
            string dates,
            double pricePerNight,
            double totalPrice,
            int numNights);
    }
}
