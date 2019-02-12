using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.DAL.Entities;
using Xunit;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextTests : IDisposable
    {
        public CookBookDbContextTests()
        {
            using (var dbx = new CookBookDbContext())
            {
                dbx.Ingredients.RemoveRange(dbx.Ingredients);
                dbx.Recipes.RemoveRange(dbx.Recipes);
                dbx.SaveChanges();
            }
        }
        [Fact]
        public void AddIngredientTest()
        {
            //Arrange
            var ingredientEntity = new IngredientEntity()
            {
                Name = "Salt",
                Description = "Mountain salt"
            };

            //Act
            using (var dbx = new CookBookDbContext())
            {
                dbx.Ingredients.Add(ingredientEntity);
                dbx.SaveChanges();
            }

            //Assert
            using (var dbx = new CookBookDbContext())
            {
                var retrievedIngredient = dbx.Ingredients.First(entity => entity.Id == ingredientEntity.Id);
                Assert.Equal(ingredientEntity, retrievedIngredient, IngredientEntity.DescriptionNameIdComparer);
            }
        }

        public void Dispose()
        {
           
        }
    }
}
