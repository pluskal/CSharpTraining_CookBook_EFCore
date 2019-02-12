using System;
using CookBook.DAL.Entities;
using Xunit;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextTests
    {
        [Fact]
        public void AddIngredientTest()
        {
            var dbx = new CookBookDbContext();
            dbx.Ingredients.Add(new IngredientEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Salt",
                Description = "Mountain salt"
            });
            dbx.SaveChanges();
        }
    }
}
