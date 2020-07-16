namespace BookingProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BookingProject.Data.Common.Repositories;
    using BookingProject.Data.Models;
    using BookingProject.Services.Data.IServices;
    using BookingProject.Services.Mapping;
    using BookingProject.Web.ViewModels.Places;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    public class PlacesService : IPlacesService
    {
        private readonly IDeletableEntityRepository<Place> placesRepository;
        private readonly IDeletableEntityRepository<Reservation> reservationsRepository;
        private readonly IDeletableEntityRepository<Image> imagesRepository;
        private readonly IDeletableEntityRepository<PlaceExtra> placeExtrasRepository;
        private readonly IDeletableEntityRepository<Review> reviewsRepository;
        private readonly IExtrasService extrasService;
        private readonly IImagesService imagesService;

        public PlacesService(
            IDeletableEntityRepository<Place> placesRepository,
            IDeletableEntityRepository<Reservation> reservationsRepository,
            IDeletableEntityRepository<Image> imagesRepository,
            IDeletableEntityRepository<PlaceExtra> placeExtrasRepository,
            IDeletableEntityRepository<Review> reviewsRepository,
            IExtrasService extrasService,
            IImagesService imagesService)
        {
            this.placesRepository = placesRepository;
            this.reservationsRepository = reservationsRepository;
            this.imagesRepository = imagesRepository;
            this.placeExtrasRepository = placeExtrasRepository;
            this.reviewsRepository = reviewsRepository;
            this.extrasService = extrasService;
            this.imagesService = imagesService;
        }

        public async Task<int> CreateAsync(
            string name,
            int categoryId,
            int cityId,
            string address,
            string description,
            string userId,
            int priceByNight,
            int bedroomsNum,
            int bathroomsNum,
            int bedsNum,
            int maxGuest,
            bool pets,
            bool smoking,
            List<ExtraViewModel> extras,
            List<IFormFile> images)
        {
            var place = new Place
            {
                Name = name,
                CategoryId = categoryId,
                CityId = cityId,
                Address = address,
                Description = description,
                UserId = userId,
                PriceByNight = priceByNight,
                BedroomsNum = bedroomsNum,
                BathroomsNum = bathroomsNum,
                BedsNum = bedsNum,
                MaxGuest = maxGuest,
                Pets = pets,
                Smoking = smoking,
            };
            List<PlaceExtra> placesExtras = new List<PlaceExtra>();
            foreach (var extra in extras)
            {
                if (extra.IsSelected)
                {
                    PlaceExtra newPlaceExtra = new PlaceExtra { ExtraId = extra.Id, Place = place };
                    placesExtras.Add(newPlaceExtra);
                }
            }

            place.PlaceExtras = placesExtras;

            List<Image> placeImages = await this.imagesService.UploadImages(images);

            place.Images = placeImages;

            await this.placesRepository.AddAsync(place);
            await this.placesRepository.SaveChangesAsync();
            return place.Id;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Place> query =
                this.placesRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public IEnumerable<T> GetAllByUser<T>(string userId)
        {
            IQueryable<Place> query =
                this.placesRepository.All().Where(p => p.UserId == userId).OrderBy(x => x.Name);

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var place = this.placesRepository.All().Where(x => x.Id == id).Include(place => place.PlaceExtras).ThenInclude(pExtra => pExtra.Extra).Select(p => p).Include(p => p.City).ThenInclude(c => c.Region)
                .To<T>().FirstOrDefault();

            return place;
        }

        public T GetByName<T>(string name)
        {
            var place = this.placesRepository.All().Where(x => x.Name == name)
                .To<T>().FirstOrDefault();

            return place;
        }

        public IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0)
        {
            var query = this.placesRepository.All()
                .OrderBy(x => x.Name)
                .Where(x => x.CategoryId == categoryId);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }

        public int GetCountById(int id)
        {
            return this.placesRepository.All().Count(x => x.Id == id);
        }

        public double GetRating(int placeId)
        {
            Place place = this.GetById<Place>(placeId);
            return (int)Math.Round((double)place.Reviews.Select(x => x.Rating).Average());
        }

        public async Task DeleteById(int id)
        {
            var place = this.placesRepository.All().Include(p => p.Reservations).Include(p => p.Images).Include(p => p.PlaceExtras).Include(p => p.Reviews).FirstOrDefault(place => place.Id == id);
            place.Reservations.ToList<Reservation>().ForEach(x => this.reservationsRepository.Delete(x));
            place.PlaceExtras.ToList<PlaceExtra>().ForEach(x => this.placeExtrasRepository.Delete(x));
            place.Images.ToList<Image>().ForEach(x => this.imagesRepository.Delete(x));
            place.Reviews.ToList<Review>().ForEach(x => this.reviewsRepository.Delete(x));
            this.placesRepository.Delete(place);

            await this.placesRepository.SaveChangesAsync();
            await this.reservationsRepository.SaveChangesAsync();
            await this.imagesRepository.SaveChangesAsync();
            await this.reviewsRepository.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(
            int placeId,
            string name,
            string description,
            int bedroomsNum,
            int bathroomsNum,
            int priceByNight,
            int bedsNum,
            int maxGuest,
            bool pets,
            bool smoking,
            List<ExtraViewModel> extras)
        {
            Place place = this.GetById<Place>(placeId);
            place.Name = name;
            place.Description = description;
            place.BedroomsNum = bedroomsNum;
            place.BathroomsNum = bathroomsNum;
            place.PriceByNight = priceByNight;
            place.BedsNum = bedsNum;
            place.MaxGuest = maxGuest;
            place.Smoking = smoking;
            place.Pets = pets;

            List<PlaceExtra> placesExtras = new List<PlaceExtra>();
            foreach (var extra in extras)
            {
                if (extra.IsSelected)
                {
                    PlaceExtra newPlaceExtra = new PlaceExtra { ExtraId = extra.Id, Place = place };
                    placesExtras.Add(newPlaceExtra);
                }
            }

            place.PlaceExtras.ToList().ForEach(placeExtra => this.placeExtrasRepository.Delete(placeExtra));
            place.PlaceExtras.ToList().ForEach(placeExtra => place.PlaceExtras.Remove(placeExtra));
            await this.placeExtrasRepository.SaveChangesAsync();

            place.PlaceExtras = placesExtras;

            this.placesRepository.Update(place);
            await this.placesRepository.SaveChangesAsync();
            return place.Id;
        }
    }
}
