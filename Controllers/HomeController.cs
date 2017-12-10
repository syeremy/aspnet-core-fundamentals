using System;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantService;
        private IGreeterService _greeterService;

        public HomeController(IRestaurantData restaurantService, IGreeterService greeterService)
        {
            _restaurantService = restaurantService;
            _greeterService = greeterService;
        }

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
            return Content(id.ToString());
        }
        

    }
}
