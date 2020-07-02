namespace BookingProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BookingProject.Data.Common.Repositories;
    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class ReviewsService : IReviewsService
    {
        private readonly IDeletableEntityRepository<Review> reviewsRepository;

        public ReviewsService(IDeletableEntityRepository<Review> reviewsRepository)
        {
            this.reviewsRepository = reviewsRepository;
        }

        public async Task Create(int placeId, string userId, string comment, int rating)
        {
            var review = new Review
            {
                PlaceId = placeId,
                UserId = userId,
                Comment = comment,
                Rating = rating,
            };
            await this.reviewsRepository.AddAsync(review);
            await this.reviewsRepository.SaveChangesAsync();
        }

        public bool IsInPlaceId(int reviewId, int placeId)
        {
            var reviewPlaceId = this.reviewsRepository.All().Where(x => x.Id == reviewId)
                .Select(x => x.PlaceId).FirstOrDefault();
            return reviewPlaceId == placeId;
        }
    }
}
