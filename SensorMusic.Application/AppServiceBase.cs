using SensorMusic.Application.Interfaces;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SensorMusic.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : BaseEntity
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public bool Delete(Int64 id)
        {
            return _serviceBase.Delete(id);
        }

        public void Dispose()
        {
            return;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public TEntity GetById(long id)
        {
            return _serviceBase.GetById(id);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return _serviceBase.GetList(predicate);
        }

        public void Insert(TEntity entity)
        {
            _serviceBase.Insert(entity);
        }

        public bool Update(TEntity entity)
        {
            return _serviceBase.Update(entity);
        }
    }
}
