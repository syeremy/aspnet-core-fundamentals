using System;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    public class GreeterService : IGreeterService
    {
        private IConfiguration _configuration;

        public GreeterService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetMessageOfTheDay()
        {
            return _configuration["greeting"];
        }
    }
}
