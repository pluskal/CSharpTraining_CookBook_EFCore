using CookBook.BL.DTOs;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;

namespace CookBook.BL.Facades
{
    public class IngredientMapper:IMapper<IngredientEntity,IngredientListDTO,IngredientDetailDTO>
    {
        public IngredientEntity MapEntity(IngredientDetailDTO detailDto)
        {
            return new IngredientEntity()
            {
                Id = detailDto.Id,
                Name = detailDto.Name,
                Description = detailDto.Description
            };
        }

        public IngredientDetailDTO MapDetail(IngredientEntity entity)
        {
            return new IngredientDetailDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public IngredientListDTO MapList(IngredientEntity entity)
        {
            return new IngredientListDTO()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}