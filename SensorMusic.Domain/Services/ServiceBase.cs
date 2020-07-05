using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces.Repositories;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SensorMusic.Domain.Services
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public bool Delete(Int64 id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(long id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.GetList(predicate);
        }

        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public bool Update(TEntity entity)
        {
            return _repository.Update(entity);
        }
    }
}
