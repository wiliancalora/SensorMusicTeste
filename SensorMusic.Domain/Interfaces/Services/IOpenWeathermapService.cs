using SensorMusic.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SensorMusic.Domain.Interfaces.Services
{
    public interface IOpenWeathermapService
    {
        Task<OpenWeathermapTemperature> GetTemperatureAsync(string hometown);
    }
}
