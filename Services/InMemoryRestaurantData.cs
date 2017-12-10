using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>() { 
                new Restaurant() {Id = 1, Name="Punto Azul"},
                new Restaurant() {Id = 2, Name="Villa Chicken"},
                new Restaurant() {Id = 3, Name="La Lucha"},
                new Restaurant() {Id = 4, Name="El Mostruo"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }
    }
}
