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
    public class UserNoteRepository : RepositoryBase<UserNotes>, IUserNoteRepository
    {
        public UserNoteRepository(IConfiguration configuration) : base(configuration) { }

        public override void Insert(UserNotes userNotes)
        {
            try
            {
                using (var db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("idUser", userNotes.IdUser);
                    param.Add("note", userNotes.Note);
                    db.Execute("AddUserNote", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
