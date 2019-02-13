using CookBook.BL.DTOs;
using CookBook.DAL.Interfaces;

namespace CookBook.BL.Facades
{
    public interface IMapper<TEntity, TListDTO, TDetailDTO>
        where TEntity : class, IEntity, new()
        where TListDTO : IId, new()
        where TDetailDTO : class, IId, new()
    {
        TEntity MapEntity(TDetailDTO detailDto);
        TDetailDTO MapDetail(TEntity detailDto);
        TListDTO MapList(TEntity detailDto);
    }
}