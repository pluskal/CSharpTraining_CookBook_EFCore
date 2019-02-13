using System;
using System.Linq;
using CookBook.DAL.Entities;
using Xunit;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextTests : IClassFixture<CookBookDbContextTestsClassSetupFixture>
    {
        private readonly CookBookDbContextTestsClassSetupFixture _testContext;

        public CookBookDbContextTests(CookBookDbContextTestsClassSetupFixture testContext)
        {
            _testContext = testContext;
            using (var dbx = _testContext.CreateCookBookDbContext())
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
            var ingredientEntity = new IngredientEntity
            {
                Name = "Salt",
                Description = "Mountain salt"
            };

            //Act
            _testContext.CookBookDbContextSUT.Ingredients.Add(ingredientEntity);
            _testContext.CookBookDbContextSUT.SaveChanges();


            //Assert
            using (var dbx = _testContext.CreateCookBookDbContext())
            {
                var retrievedIngredient = dbx.Ingredients.First(entity => entity.Id == ingredientEntity.Id);
                Assert.Equal(ingredientEntity, retrievedIngredient, IngredientEntity.DescriptionNameIdComparer);
            }
        }

    }
}