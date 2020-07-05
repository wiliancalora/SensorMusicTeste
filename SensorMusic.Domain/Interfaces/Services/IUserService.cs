using SensorMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        User Login(string email, string password);
        User GetUserByEmail(string email);
    }
}
