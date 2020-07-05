using SensorMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Interfaces.Services
{
    public interface IUserPasswordRecoveryService : IServiceBase<UserPasswordRecovery>
    {
        UserPasswordRecovery GetUserPasswordRecoveryByEmail(string email);
        UserPasswordRecovery GetUserPasswordRecoveryByHash(string hash);
    }
}
