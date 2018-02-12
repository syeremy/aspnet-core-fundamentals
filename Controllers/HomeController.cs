using System;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace OdeToFood.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IRestaurantData _restaurantService;
        IGreeterService _greeterService;

        public HomeController(IRestaurantData restaurantService, IGreeterService greeterService)
        {
            _restaurantService = restaurantService;
            _greeterService = greeterService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Restaurants = _restaurantService.GetAll(),
                CurrentMessage = _greeterService.GetMessageOfTheDay()
            };
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var restaurant = _restaurantService.Get(id);

            if (restaurant == null)
                //return NotFound();
                return RedirectToAction(nameof(Index));

            return View(restaurant);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(RestaurantEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var restaurant = new Restaurant();
            restaurant.Name = model.Name;
            restaurant.Cuisine = model.Cuisine;

            restaurant = _restaurantService.Add(restaurant);

            return RedirectToAction(nameof(Details), new { id = restaurant.Id });

        }

    }
}
