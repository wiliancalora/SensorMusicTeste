using SensorMusic.Domain.DTO;
using SensorMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SensorMusic.Application.Interfaces
{
    public interface IOpenWeathermapAppService
    {
        Task<OpenWeathermapTemperature> GetTemperature(string hometown);
    }
}
