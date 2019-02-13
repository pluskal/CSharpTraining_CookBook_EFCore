using System;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextTestsClassSetupFixture : IDisposable
    {
        public CookBookDbContext CookBookDbContextSUT { get; set; }

        public CookBookDbContextTestsClassSetupFixture()
        {
            this.CookBookDbContextSUT = CreateCookBookDbContext();
        }

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
            CookBookDbContextSUT?.Dispose();
        }
    }
}