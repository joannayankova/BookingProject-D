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
        private readonly IExtrasService extrasService;
        private readonly IImagesService imagesService;

        public PlacesService(IDeletableEntityRepository<Place> placesRepository, IExtrasService extrasService, IImagesService imagesService)
        {
            this.placesRepository = placesRepository;
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

        public T GetById<T>(int id)
        {
            var place = this.placesRepository.All().Where(x => x.Id == id).Include(place => place.PlaceExtras).ThenInclude(pExtra => pExtra.Extra)
                .To<T>().FirstOrDefault();

            return place;
        }

        public T GetByName<T>(string name)
        {
            var place = this.placesRepository.All().Where(x => x.Name == name)
                .To<T>().FirstOrDefault();

            return place;
        }

        public double GetRating(int placeId)
        {
            Place place = this.GetById<Place>(placeId);
            return (int)Math.Round((double)place.Reviews.Select(x => x.Rating).Average());
        }
    }
}
