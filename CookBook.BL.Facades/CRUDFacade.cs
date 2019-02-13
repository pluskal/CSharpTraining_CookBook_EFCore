using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CookBook.BL.DTOs;
using CookBook.DAL;
using CookBook.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CookBook.BL.Facades
{
    public class CRUDFacade<TEntity, TListDTO, TDetailDTO>
    where TEntity: class, IEntity, new()
    where  TListDTO: IId, new()
    where  TDetailDTO: class, IId, new()
    {
        private UnitOfWork _unitOfWork;
        private RepositoryBase<TEntity> _repository;
        private readonly IMapper<TEntity, TListDTO, TDetailDTO> _mapper;

        public CRUDFacade(UnitOfWork unitOfWork, RepositoryBase<TEntity> repository, IMapper<TEntity, TListDTO, TDetailDTO> mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TListDTO> GetList() => this._repository.GetAll().Select(_mapper.MapList).ToArray();

        public TDetailDTO GetDetail(Guid id) => this._mapper.MapDetail(this._repository.GetById(id));

        public void Delete(Guid id){
            this._repository.DeleteById(id);
            this._unitOfWork.Commit();
        }
        public void Delete(TDetailDTO detailDto) => this.Delete(detailDto.Id);
        public void Delete(TListDTO listDto) => this.Delete(listDto.Id);

        public TDetailDTO InitializeNew() => this._mapper.MapDetail(this._repository.InitializeNew());

        public TDetailDTO Save(TDetailDTO detailDto)
        {
            var entity = _mapper.MapEntity(detailDto);
            if (entity.Id == Guid.Empty)
            {
                detailDto = _mapper.MapDetail(this._repository.Insert(entity));
            }
            else
            {
                this._repository.Update(entity);
            }
            this._unitOfWork.Commit();
            return detailDto;
        }
    }
}
