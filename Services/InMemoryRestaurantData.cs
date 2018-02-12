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
                new Restaurant() {Id = 1, Cuisine = CuisineType.French, Name="Punto Azul"},
                new Restaurant() {Id = 2, Cuisine = CuisineType.Italian, Name="Villa Chicken"},
                new Restaurant() {Id = 3, Cuisine = CuisineType.Peruvian, Name="La Lucha"},
                new Restaurant() {Id = 4, Cuisine = CuisineType.Peruvian, Name="El Mostruo"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(item => item.Id == id);
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(restaurant);

            return restaurant;
        }
    }
}
