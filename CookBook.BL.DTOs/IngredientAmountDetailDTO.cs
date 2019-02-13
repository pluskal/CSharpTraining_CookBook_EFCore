using System;
using CookBook.BL.DTOs.Enums;

namespace CookBook.BL.DTOs
{
    public class IngredientAmountDetailDTO : IId
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Guid IngredientId { get; set; }
        public Unit Unit { get; set; }
        public double Amount { get; set; }
    }
}