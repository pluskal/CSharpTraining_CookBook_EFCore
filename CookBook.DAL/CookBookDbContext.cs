﻿using System;
using System.Collections.Generic;
using System.Text;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL
{
    public class CookBookDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
@"Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog = CookBook;
                MultipleActiveResultSets = True;
                Integrated Security = True; ");
        }

        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
    }
}
