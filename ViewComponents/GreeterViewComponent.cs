using System;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;

namespace OdeToFood.ViewComponents
{
    public class GreeterViewComponent : ViewComponent
    {
        IGreeterService _greeter;

        public GreeterViewComponent(IGreeterService greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetMessageOfTheDay();

            return View("Default", model);
        }
    }
}
