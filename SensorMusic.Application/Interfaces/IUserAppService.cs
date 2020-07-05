using SensorMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Application.Interfaces
{
    public interface IUserAppService : IAppServiceBase<User>
    {
        User Login(string email, string password);
        User GetUserByEmail(string email);
    }
}
