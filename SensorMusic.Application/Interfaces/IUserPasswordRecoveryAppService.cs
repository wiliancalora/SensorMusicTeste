using SensorMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Application.Interfaces
{
    public interface IUserPasswordRecoveryAppService : IAppServiceBase<UserPasswordRecovery>
    {
        string UserGenerateHash(string email);
        void ResetPassword(string hash, string newPassword);
    }
}
