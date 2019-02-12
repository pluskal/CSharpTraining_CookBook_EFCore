using System;
using CookBook.DAL.Interfaces;

namespace CookBook.DAL.Entities
{
    public class IngredientEntity : IEntity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}