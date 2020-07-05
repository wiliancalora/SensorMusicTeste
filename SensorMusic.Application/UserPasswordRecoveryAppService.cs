using SensorMusic.Application.Interfaces;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces.Services;
using SensorMusic.Domain.Services.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Application
{
    public class UserPasswordRecoveryAppService : AppServiceBase<UserPasswordRecovery>, IUserPasswordRecoveryAppService
    {
        readonly IUserPasswordRecoveryService _userPasswordRecoveryService;
        readonly IUserAppService _userAppService;

        public UserPasswordRecoveryAppService(
                                              IUserPasswordRecoveryService userPasswordRecoveryService,
                                              IUserAppService userAppService
                                             ) : base(userPasswordRecoveryService)
        {
            _userPasswordRecoveryService = userPasswordRecoveryService;
            _userAppService = userAppService;
        }
       
        public string UserGenerateHash(string email)
        {
            //caso já tiver solicitado o password não gera novamente
            var userPasswordRecovery = GetUserPasswordRecoveryByEmail(email);
            if (userPasswordRecovery != null)
            {
                return userPasswordRecovery.Hash;
            }

            string hash = Guid.NewGuid().ToString().Replace("-","");

            Insert(new UserPasswordRecovery { Email = email, CreateDate = DateHour.GetDateTimeServer(), Hash = hash});

            return hash;
        }

        public UserPasswordRecovery GetUserPasswordRecoveryByEmail(string email)
        {
            return _userPasswordRecoveryService.GetUserPasswordRecoveryByEmail(email);
        }

        public UserPasswordRecovery GetUserPasswordRecoveryByHash(string hash)
        {
            return _userPasswordRecoveryService.GetUserPasswordRecoveryByHash(hash);
        }

        public void ResetPassword(string hash, string newPassword)
        {
            //caso já tiver solicitado o password não gera novamente
            var userPasswordRecovery = GetUserPasswordRecoveryByHash(hash);
            if (userPasswordRecovery == null)
            {
                throw new Exception("Not Hash");
            }

            var userBD = _userAppService.GetUserByEmail(userPasswordRecovery.Email);

            if(userBD == null)
            {
                throw new Exception("User not find");
            }

            DateTime dateHour = DateHour.GetDateTimeServer();
            Update(new UserPasswordRecovery {UpdateDate = dateHour, Hash = hash });

            userBD.Password = Encryptor.GenerateHashMd5(newPassword);
            userBD.UpdateDate = dateHour;

            _userAppService.Update(userBD);
        }
    }
}
