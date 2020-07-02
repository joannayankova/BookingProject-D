namespace BookingProject.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BookingProject.Data.Models;
    using BookingProject.Services.Data;
    using BookingProject.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : BaseController
    {
        private readonly IReviewsService reviewsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ReviewsController(
            IReviewsService reviewsService,
            UserManager<ApplicationUser> userManager)
        {
            this.reviewsService = reviewsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateReviewInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.reviewsService.Create(input.PlaceId, userId, input.Comment, input.Rating);
            return this.RedirectToAction("GetById", "Places", new { id = input.PlaceId });
        }
    }
}
