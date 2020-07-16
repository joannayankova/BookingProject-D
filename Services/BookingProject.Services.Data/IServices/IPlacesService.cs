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

        Task<int> UpdateAsync(
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
            List<ExtraViewModel> extras);

        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<T> GetAllByUser<T>(string userId);

        T GetByName<T>(string name);

        T GetById<T>(int id);

        Task DeleteById(int id);

        IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0);

        int GetCountById(int categoryId);

        double GetRating(int placeId);
    }
}
