namespace BookingProject.Web.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using BookingProject.Data.Common.Repositories;
    using BookingProject.Data.Models;
    using BookingProject.Services.Data;
    using BookingProject.Services.Mapping;
    using BookingProject.Web.ViewModels;
    using BookingProject.Web.ViewModels.Home;
    using BookingProject.Web.ViewModels.Places;
    using BookingProject.Web.ViewModels.Reservations;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly ICitiesService citiesService;

        public HomeController(ICategoriesService categoriesService, ICitiesService citiesService)
        {
            this.categoriesService = categoriesService;
            this.citiesService = citiesService;
    }

        public IActionResult Index()
        {
            var cities = this.citiesService.GetAll<CityDropDownViewModel>();
            var numbers = Enumerable.Range(1, 30).ToList();
            IEnumerable<GuestNumberDropDownViewModel> guestNumbers = numbers.Select(x => new GuestNumberDropDownViewModel { Id = x, Name = x.ToString() });
            var viewModel = new IndexViewModel
            {
                Categories =
                   this.categoriesService.GetAll<IndexCategoryViewModel>(),
                Cities = cities,
                GuestNumbers = guestNumbers,
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return this.View();
        }
    }
}
