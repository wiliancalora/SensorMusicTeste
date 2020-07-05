using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using SensorMusic.Domain.Interfaces.Repositories;
using SensorMusic.Domain.Entities;
using System.Data.SqlClient;
using Dommel;
using System.Linq.Expressions;

namespace SensorMusic.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {

        private string _connectionString;
        protected string ConnectionString => _connectionString;

        public RepositoryBase(IConfiguration configuration)
        {
            _connectionString = @configuration.GetValue<string>("DBInfo:ConnectionString");
            
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetAll<TEntity>();
            }
        }

        public virtual TEntity GetById(Int64 id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Get<TEntity>(id);
            }
        }

        public virtual void Insert(TEntity entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                Int64 id = Convert.ToInt64(db.Insert(entity));

                entity = GetById(id);
            }
        }

        public virtual bool Update(TEntity entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Update(entity);
            }
        }

        public virtual bool Delete(Int64 id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var entity = GetById(id);

                if (entity == null) throw new Exception("Registro não encontrado");

                return db.Delete(entity);
            }
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Select(predicate);
            }
        }
    }
}
