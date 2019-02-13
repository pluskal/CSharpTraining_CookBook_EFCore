using CookBook.BL.DTOs;
using CookBook.DAL.Entities;
using System;
using Xunit;

namespace CookBook.BL.Facades.Tests
{
    public class IngredientFacadeTests
        :IClassFixture<IngredientFacadeTestsClassSetupFixture>
    {
        private readonly IngredientFacadeTestsClassSetupFixture _testContext;

        public IngredientFacadeTests(IngredientFacadeTestsClassSetupFixture testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public void InsertIngredient()
        {
            //Arrange
            var ingredientDetailDto = this._testContext.CRUDFacadeSUT.InitializeNew();
            ingredientDetailDto.Name = "Salt";
            ingredientDetailDto.Description = "Mountain salt";
            

            //Act
            var savedDetailDto =  this._testContext.CRUDFacadeSUT.Save(ingredientDetailDto);

            //Assert
            Assert.NotEqual(Guid.Empty, savedDetailDto.Id);
            savedDetailDto.Id = Guid.Empty;
            Assert.Equal(ingredientDetailDto, savedDetailDto,IngredientDetailDTO.DescriptionNameIdComparer);
        }
    }
}
