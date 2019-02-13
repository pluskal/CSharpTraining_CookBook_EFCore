using System;
using System.Collections.Generic;

namespace CookBook.BL.DTOs
{
    public class IngredientDetailDTO : IId
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }

        private sealed class DescriptionNameIdEqualityComparer : IEqualityComparer<IngredientDetailDTO>
        {
            public bool Equals(IngredientDetailDTO x, IngredientDetailDTO y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Description, y.Description) && string.Equals(x.Name, y.Name) && x.Id.Equals(y.Id);
            }

            public int GetHashCode(IngredientDetailDTO obj)
            {
                unchecked
                {
                    var hashCode = (obj.Description != null ? obj.Description.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Id.GetHashCode();
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<IngredientDetailDTO> DescriptionNameIdComparer { get; } = new DescriptionNameIdEqualityComparer();
    }
}