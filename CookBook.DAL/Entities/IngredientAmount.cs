using System;
using System.Collections.Generic;
using CookBook.DAL.Enums;
using CookBook.DAL.Interfaces;

namespace CookBook.DAL.Entities
{
    public class IngredientAmount : IEntity
    {
        public double Amount { get; set; }
        public IngredientEntity Ingredient { get; set; }

        public static IEqualityComparer<IngredientAmount> IngredientAmountComparer { get; } =
            new IngredientAmountEqualityComparer();

        public RecipeEntity Recipe { get; set; }
        public Unit Unit { get; set; }
        public Guid Id { get; set; }

        private sealed class IngredientAmountEqualityComparer : IEqualityComparer<IngredientAmount>
        {
            public bool Equals(IngredientAmount x, IngredientAmount y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Amount.Equals(y.Amount) &&
                       IngredientEntity.DescriptionNameIdComparer.Equals(x.Ingredient, y.Ingredient) &&
                       RecipeEntity.WithoutIngredientsComparer.Equals(x.Recipe, y.Recipe) && x.Unit == y.Unit &&
                       x.Id.Equals(y.Id);
            }

            public int GetHashCode(IngredientAmount obj)
            {
                unchecked
                {
                    var hashCode = obj.Amount.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Ingredient != null ? obj.Ingredient.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Recipe != null ? obj.Recipe.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (int) obj.Unit;
                    hashCode = (hashCode * 397) ^ obj.Id.GetHashCode();
                    return hashCode;
                }
            }
        }
    }
}