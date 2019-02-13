using System;

namespace CookBook.BL.DTOs
{
    public class IngredientListDTO : IId
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}