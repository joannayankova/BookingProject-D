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
        private const int PlacesPerPage = 2;

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

        public IActionResult ByName(string name, int page = 1)
        {
            var viewModel =
                this.categoriesService.GetByName<CategoryViewModel>(name);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.CardPlaces = this.placesService.GetByCategoryId<CardPlaceViewModel>(viewModel.Id, PlacesPerPage, (page - 1) * PlacesPerPage);

            var count = this.placesService.GetCountById(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / PlacesPerPage);
            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }
    }
}
