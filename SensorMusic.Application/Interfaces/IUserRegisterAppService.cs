using SensorMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Application.Interfaces
{
    public interface IUserRegisterAppService 
    {
        void AddUserRegister(User user, Profile profile, List<UserNotes> userNotes);
    }
}
