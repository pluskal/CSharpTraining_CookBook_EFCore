using System;
using CookBook.DAL.Enums;
using CookBook.DAL.Interfaces;

namespace CookBook.DAL.Entities
{
    public class RecipeEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public FoodType FoodType { get; set; }
    }
}
