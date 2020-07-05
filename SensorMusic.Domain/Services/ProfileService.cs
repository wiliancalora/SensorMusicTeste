using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces;
using SensorMusic.Domain.Interfaces.Repositories;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Services
{
    public class ProfileService : ServiceBase<Profile>, IProfileService
    {
        readonly IProfileRepository _repository;

        public ProfileService(IProfileRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
