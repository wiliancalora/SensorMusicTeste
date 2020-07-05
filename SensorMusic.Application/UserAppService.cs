using SensorMusic.Application.Interfaces;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Application
{
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        readonly IUserService _userService;

        public UserAppService(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        public User Login(string email, string password)
        {
            return _userService.Login(email, password);
        }

        public User GetUserByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }
    }
}
