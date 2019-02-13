using System;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL
{
    public class UnitOfWork : IDisposable
    {
        public DbContext DbContext { get; }

        public UnitOfWork(DbContext dbContext) => DbContext = dbContext;

        public void Commit() => this.DbContext.SaveChanges();

        public void Dispose() => DbContext?.Dispose();
    }
}