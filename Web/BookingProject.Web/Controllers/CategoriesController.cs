namespace BookingProject.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BookingProject.Services.Data;
    using BookingProject.Web.ViewModels.Places;
    using BookingProject.Services.Data;
    using BookingProject.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class CategoriesController : Controller
    {       
        private readonly ICategoriesService categoriesService;
        private readonly IPlacesService placesService;
        private readonly IHttpContextAccessor http;

        public CategoriesController(
            ICategoriesService categoriesService,
            IPlacesService placesService,
            IHttpContextAccessor http)
        {
            this.categoriesService = categoriesService;
            this.placesService = placesService;
            this.http = http;
        }
    }
}
