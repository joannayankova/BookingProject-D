namespace BookingProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using BookingProject.Data.Models;
    using BookingProject.Web.ViewModels.Image;
    using BookingProject.Web.ViewModels.Places;
    using Microsoft.AspNetCore.Http;

    public interface IPlacesService
    {
        Task<int> CreateAsync(
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
            List<IFormFile> images);

        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);

        T GetById<T>(int id);

        public double GetRating(int placeId);
    }
}
