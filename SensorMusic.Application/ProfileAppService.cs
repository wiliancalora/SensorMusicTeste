using SensorMusic.Application.Interfaces;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Application
{
    public class ProfileAppService : AppServiceBase<Profile>, IProfileAppService
    {
        readonly IProfileService _profileService;

        public ProfileAppService(IProfileService profileService) : base(profileService)
        {
            _profileService = profileService;
        }

       
    }
}
