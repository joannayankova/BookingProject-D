namespace BookingProject.Services.Data.IServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using BookingProject.Data.Models;
    using Microsoft.AspNetCore.Http;

    public interface IImagesService
    {
        Task<List<Image>> UploadImages(List<IFormFile> fileobj);
    }
}
