using SensorMusic.Application.Interfaces;
using SensorMusic.Domain.DTO;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SensorMusic.Application
{
    public class OpenWeathermapAppService : IOpenWeathermapAppService
    {
        readonly IOpenWeathermapService _openWeathermapService;

        public OpenWeathermapAppService(IOpenWeathermapService openWeathermapService)
        {
            _openWeathermapService = openWeathermapService;
        }

        public Task<OpenWeathermapTemperature> GetTemperature(string hometown)
        {
            return _openWeathermapService.GetTemperatureAsync(hometown);
        }
    }
}
