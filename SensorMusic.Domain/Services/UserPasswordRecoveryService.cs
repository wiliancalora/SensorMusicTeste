using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces;
using SensorMusic.Domain.Interfaces.Repositories;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Services
{
    public class UserPasswordRecoveryService : ServiceBase<UserPasswordRecovery>, IUserPasswordRecoveryService
    {
        readonly IUserPasswordRecoveryRepository _repository;

        public UserPasswordRecoveryService(IUserPasswordRecoveryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public UserPasswordRecovery GetUserPasswordRecoveryByEmail(string email)
        {
            return _repository.GetUserPasswordRecoveryByEmail(email);
        }

        public UserPasswordRecovery GetUserPasswordRecoveryByHash(string hash)
        {
            return _repository.GetUserPasswordRecoveryByHash(hash);

        }
    }
}
