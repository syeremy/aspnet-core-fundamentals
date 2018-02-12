﻿using System;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Models;

namespace odeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        
        public OdeToFoodDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
