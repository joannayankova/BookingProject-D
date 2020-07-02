//// namespace BookingProject.Web.Controllers
//{
//    using System;
//    using System.Collections.Generic;
//    using System.IO;
//    using System.Linq;
//    using System.Threading.Tasks;

//    using BookingProject.Data;
//    using BookingProject.Data.Models;
//    using Microsoft.AspNetCore.Hosting;
//    using Microsoft.AspNetCore.Http;
//    using Microsoft.AspNetCore.Mvc;
//    using Microsoft.EntityFrameworkCore;

//    public class ImagesController : Controller
//    {
//        private readonly ApplicationDbContext adb;

//        private readonly IWebHostEnvironment iwebhost;

//        public ImagesController(ApplicationDbContext adb, IWebHostEnvironment iwebhost)
//        {
//            this.adb = adb;

//            this.iwebhost = iwebhost;
//        }

//        public IActionResult Index()
//        {
//            // var result = this.adb.Images.ToList();
//            // return this.View(result);
//            return this.View();
//        }

//        [HttpPost]

//        public async Task<IActionResult> LoadImages(List<IFormFile> fileobj, Image image)
//        {
//            if (fileobj == null || fileobj.Count == 0)
//            {
//                this.ViewData["Message"] = "Моля, изберете поне една снимка.";
//            }

//            foreach (IFormFile img in fileobj)
//            {
//                string imageExt = Path.GetExtension(img.FileName);

//                if (imageExt == ".jpg" || imageExt == ".png")
//                {
//                    var saveImage = Path.Combine(this.iwebhost.WebRootPath, "Image", img.FileName);
//                    var stream = new FileStream(saveImage, FileMode.Create);
//                    await img.CopyToAsync(stream);

//                    image.Name = img.FileName;
//                    image.Ext = imageExt;
//                    image.Path = saveImage;

//                    await this.adb.Images.AddAsync(image);
//                    await this.adb.SaveChangesAsync();
//                    this.ViewData["Message"] = "Снимката " + img.Length + " e качена.";
//                }
//                else
//                {
//                    this.ViewData["Message"] = "Грешка. Снимката трябва да е в .jpg или .png формат.";
//                }
//            }

//            return this.RedirectToAction("LoadImage");
//        }
//    }
