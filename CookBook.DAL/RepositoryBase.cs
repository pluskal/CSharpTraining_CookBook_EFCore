using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.DAL.Interfaces;

namespace CookBook.DAL
{
    public class RepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly UnitOfWork _unitOfWork;

        public RepositoryBase(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(TEntity entity) =>
            _unitOfWork.DbContext.Set<TEntity>().Remove(entity);

        public void DeleteById(Guid entityId)
        {
            var entity = this.InitializeNew();
            entity.Id = entityId;
            this.Delete(entity);
        }

        public TEntity GetById(Guid entityId) =>
            _unitOfWork.DbContext.Set<TEntity>().FirstOrDefault(entity => entity.Id == entityId);

        public TEntity InitializeNew() => new TEntity();

        public TEntity Insert(TEntity entity) => _unitOfWork.DbContext.Set<TEntity>().Add(entity).Entity;

        public void Update(TEntity entity) => _unitOfWork.DbContext.Set<TEntity>().Update(entity);

        public IEnumerable<TEntity> GetAll() => _unitOfWork.DbContext.Set<TEntity>().ToArray();
    }
}