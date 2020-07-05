using Dapper;
using Microsoft.Extensions.Configuration;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces;
using SensorMusic.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SensorMusic.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public override User GetById(Int64 id)
        {
            try
            {
                using (var db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("idUser", id);
                    return db.QueryFirstOrDefault<User>("GetProfileByIdUser", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Insert(User entity)
        {
            try
            {
                using (var db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("email", entity.Email);
                    param.Add("password", entity.Password);
                    param.Add("createDate", entity.CreateDate);
                    var addUser = db.QueryFirstOrDefault<User>("AddUser", param, commandType: CommandType.StoredProcedure);
                    entity.IdUser = addUser.IdUser;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override bool Update(User entity)
        {
            try
            {
                using (var db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("email", entity.Email);
                    param.Add("password", entity.Password);
                    param.Add("updateDate", entity.UpdateDate);
                    db.Execute("UpdateUser", param, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User Login(string email, string password)
        {
            try
            {
                using (var db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("email", email);
                    param.Add("password", password);
                    return db.QueryFirstOrDefault<User>("GetLogin", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                using (var db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("email", email);
                    return db.QueryFirstOrDefault<User>("GetUserByEmail", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
