using SensorMusic.Application.Interfaces;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SensorMusic.Domain.Services.Util;

namespace SensorMusic.Application
{
    public class UserRegisterAppService : IUserRegisterAppService
    {
        readonly IUserAppService _userAppService;
        readonly IUserNoteAppService _userNoteAppService;
        readonly IProfileAppService _profileAppService;


        public UserRegisterAppService(
                                      IUserAppService userAppService,
                                      IUserNoteAppService userNoteAppService,
                                      IProfileAppService profileAppService) 
        {
            _userAppService = userAppService;
            _userNoteAppService = userNoteAppService;
            _profileAppService = profileAppService;
        }

        public void AddUserRegister(User user, Profile profile, List<UserNotes> userNotes)
        {

            //verificar se já existe o usuário
            var userBD = _userAppService.GetUserByEmail(user.Email);

            if(userBD != null)
            {
                throw new Exception("Usuário existente.");
            }

            user.Password = Encryptor.GenerateHashMd5(user.Password);

            user.CreateDate = DateHour.GetDateTimeServer();
            _userAppService.Insert(user);

            profile.IdUser = user.IdUser;

            _profileAppService.Insert(profile);

            userNotes.All(c => { c.IdUser = user.IdUser; return true; });
            userNotes.All(c => { c.Note = Encryptor.Encrypt(c.Note); return true; });

            foreach (var note in userNotes)
            {
                _userNoteAppService.Insert(note);
            }
            
        }
       
    }
}
