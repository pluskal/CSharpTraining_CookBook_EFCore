using CookBook.BL.DTOs;
using CookBook.DAL;
using CookBook.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BL.Facades.Tests
{
    public class FacadeTestsClassSetupFixture<TEntity, TListDTO, TDetailDTO>
        where TEntity : class, IEntity, new()
        where TListDTO : IId, new()
        where TDetailDTO : class, IId, new()
    {
        private UnitOfWork _unitOfWork;
        public FacadeTestsClassSetupFixture(IMapper<TEntity, TListDTO, TDetailDTO> mapper)
        {
            var cookBookDbContextSUT = CreateCookBookDbContext();
            _unitOfWork = new UnitOfWork(cookBookDbContextSUT);
            var repository = new RepositoryBase<TEntity>(_unitOfWork);
            CRUDFacadeSUT = new CRUDFacade<TEntity, TListDTO, TDetailDTO>(_unitOfWork, repository, mapper);

        }
        public CRUDFacade<TEntity, TListDTO, TDetailDTO> CRUDFacadeSUT { get; set; }
        
        public CookBookDbContext CreateCookBookDbContext()
        {
            return new CookBookDbContext(CreateDbContextOptions());
        }
        private DbContextOptions<CookBookDbContext> CreateDbContextOptions()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            contextOptionsBuilder.UseInMemoryDatabase();
            return contextOptionsBuilder.Options;
        }
        public void Dispose()
        {
            this._unitOfWork?.DbContext?.Dispose();
        }
    }

}