namespace BookingProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BookingProject.Data.Common.Repositories;
    using BookingProject.Data.Models;
    using BookingProject.Services.Data.IServices;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;

    public class ImagesService : IImagesService
    {
        private readonly IDeletableEntityRepository<Image> imagesRepository;
        private readonly IHostingEnvironment ihost;

        public ImagesService(IDeletableEntityRepository<Image> imagesRepository, IHostingEnvironment ihost)
        {
            this.imagesRepository = imagesRepository;
            this.ihost = ihost;
        }

        public object ViewData { get; private set; }

        public async Task<List<Image>> UploadImages(List<IFormFile> fileobj)
        {
            List<Image> images = new List<Image>();
            foreach (IFormFile img in fileobj)
            {
                string imageExt = Path.GetExtension(img.FileName);

                if (imageExt == ".jpg" || imageExt == ".png")
                {
                    var imgPath = Path.Combine(this.ihost.WebRootPath, "images", img.FileName);
                    var stream = new FileStream(imgPath, FileMode.Create);
                    await img.CopyToAsync(stream);

                    Image image = new Image { Name = img.FileName, Ext = imageExt, Path = imgPath };
                    images.Add(image);

                    // await this.imagesRepository.AddAsync(image);
                    // await this.imagesRepository.SaveChangesAsync();
                }
            }

            return images;
        }
    }
}
