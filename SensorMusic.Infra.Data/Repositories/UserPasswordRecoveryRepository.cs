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
    public class UserPasswordRecoveryRepository : RepositoryBase<UserPasswordRecovery>, IUserPasswordRecoveryRepository
    {
        public UserPasswordRecoveryRepository(IConfiguration configuration) : base(configuration) { }

        public override void Insert(UserPasswordRecovery entity)
        {
            try
            {
                using (var db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("email", entity.Email);
                    param.Add("hash", entity.Hash);
                    param.Add("createDate", entity.CreateDate);
                    db.Execute("AddUserPasswordRecovery", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override bool Update(UserPasswordRecovery entity)
        {
            try
            {
                using (var db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("hash", entity.Hash);
                    param.Add("updateDate", entity.UpdateDate);
                    db.Execute("UpdateUserPasswordRecoveryByEmail", param, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserPasswordRecovery GetUserPasswordRecoveryByEmail(string email)
        {
            try
            {
                using (var db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("email", email);
                    return db.QueryFirstOrDefault<UserPasswordRecovery>("GetUserPasswordRecoveryByEmail", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserPasswordRecovery GetUserPasswordRecoveryByHash(string hash)
        {
            try
            {
                using (var db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("hash", hash);
                    return db.QueryFirstOrDefault<UserPasswordRecovery>("GetUserPasswordRecoveryByHash", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
