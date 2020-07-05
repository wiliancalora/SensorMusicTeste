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
    public class ProfileRepository : RepositoryBase<Profile>, IProfileRepository
    {
        public ProfileRepository(IConfiguration configuration) : base(configuration) { }

        public override void Insert(Profile entity)
        {
            try
            {
                using (var db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("idUser", entity.IdUser);
                    param.Add("name", entity.Name);
                    param.Add("hometown", entity.HomeTown);
                    db.QueryFirstOrDefault<Profile>("AddProfile", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override Profile GetById(Int64 id)
        {
            try
            {
                using (var db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("idUser", id);
                    return db.QueryFirstOrDefault<Profile>("GetProfileByIdUser", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
