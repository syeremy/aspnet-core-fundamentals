using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Services;

namespace OdeToFood.Pages
{
    public class GreetingModel : PageModel
    {
        private IGreeterService _greeter;

        public string CurrentString { get; set; }

        public GreetingModel(IGreeterService greeter)
        {
            _greeter = greeter;
        }

        public void OnGet(string name)
        {
            CurrentString = $"{name} :: {_greeter.GetMessageOfTheDay()}!!!";
        }
    }
}
