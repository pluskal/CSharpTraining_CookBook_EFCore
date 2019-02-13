using CookBook.BL.DTOs;
using CookBook.DAL.Entities;

namespace CookBook.BL.Facades.Tests
{
    public class IngredientFacadeTestsClassSetupFixture: FacadeTestsClassSetupFixture<IngredientEntity, IngredientListDTO, IngredientDetailDTO>
    {
        public IngredientFacadeTestsClassSetupFixture():base(new IngredientMapper())
        {

        }
    }
}