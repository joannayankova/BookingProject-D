namespace BookingProject.Services.Data.IServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IReservationsService
    {
        //IEnumerable<T> GetAll<T>(int? count = null);

        Task<int> CreateReservationAsync(
            int placeId,
            string userId,
            string dates);
    }
}
