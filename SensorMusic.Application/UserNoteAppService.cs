using SensorMusic.Application.Interfaces;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Application
{
    public class UserNoteAppService : AppServiceBase<UserNotes>, IUserNoteAppService
    {
        readonly IUserNoteService _userNoteService;

        public UserNoteAppService(IUserNoteService userNoteService) : base(userNoteService)
        {
            _userNoteService = userNoteService;
        }

    }
}
