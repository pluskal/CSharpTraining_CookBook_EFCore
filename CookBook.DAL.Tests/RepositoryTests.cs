using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookBook.DAL.Entities;
using Xunit;

namespace CookBook.DAL.Tests
{
    public class IngredientRepositoryTests
        :IClassFixture<RepositoryTestsClassSetupFixture<IngredientEntity>>
    {
        private readonly RepositoryTestsClassSetupFixture<IngredientEntity> _testContext;

        public IngredientRepositoryTests(RepositoryTestsClassSetupFixture<IngredientEntity> testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public void InsertIngredient()
        {
            //Arrange
            var ingredientEntity = this._testContext.RepositorySUT.InitializeNew();
            ingredientEntity.Name = "Salt";
            ingredientEntity.Description = "Mountain salt";
            

            //Act
            this._testContext.RepositorySUT.Insert(ingredientEntity);
            this._testContext.UnitOfWork.Commit();


            //Assert
            using (var dbx = _testContext.CreateCookBookDbContext())
            {
                var retrievedIngredient = dbx.Ingredients.First(entity => entity.Id == ingredientEntity.Id);
                Assert.Equal(ingredientEntity, retrievedIngredient, IngredientEntity.DescriptionNameIdComparer);
            }
        }
    }
}
