using CookBook.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Tests
{
    public class RepositoryTestsClassSetupFixture<TEntity> where TEntity : class, IEntity, new()
    {
        public RepositoryTestsClassSetupFixture()
        {
            var cookBookDbContextSUT = CreateCookBookDbContext();
            UnitOfWork = new UnitOfWork(cookBookDbContextSUT);
            RepositorySUT = new RepositoryBase<TEntity>(UnitOfWork);
        }

        public UnitOfWork UnitOfWork { get;  }

        public RepositoryBase<TEntity> RepositorySUT { get; }

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
            this.UnitOfWork?.DbContext?.Dispose();
        }
    }
}