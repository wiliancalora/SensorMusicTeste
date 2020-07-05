using SensorMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Interfaces.Repositories
{
    public interface IUserPasswordRecoveryRepository : IRepositoryBase<UserPasswordRecovery>
    {
        UserPasswordRecovery GetUserPasswordRecoveryByEmail(string email);
        UserPasswordRecovery GetUserPasswordRecoveryByHash(string hash);
    }
}
