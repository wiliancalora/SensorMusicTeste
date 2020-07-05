using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces;
using SensorMusic.Domain.Interfaces.Repositories;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public User Login(string email, string password)
        {
            return _repository.Login(email, password);
        }

        public User GetUserByEmail(string email)
        {
            return _repository.GetUserByEmail(email);
        }
    }
}
