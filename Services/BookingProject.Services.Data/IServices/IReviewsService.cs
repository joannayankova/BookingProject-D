namespace BookingProject.Services.Data
{
    using System;
    using System.Threading.Tasks;

    public interface IReviewsService
    {
        Task Create(int placeId, string userId, string comment, int rating);

        bool IsInPlaceId(int reviewId, int placeId);
    }
}
