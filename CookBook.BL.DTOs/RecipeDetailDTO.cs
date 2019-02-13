using System;
using System.Collections.Generic;
using CookBook.BL.DTOs.Enums;

namespace CookBook.BL.DTOs
{
    public class RecipeDetailDTO : IId
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public FoodType FoodType { get; set; }
        public ICollection<IngredientAmountDetailDTO> Ingredients { get; } = new List<IngredientAmountDetailDTO>();
}
}
