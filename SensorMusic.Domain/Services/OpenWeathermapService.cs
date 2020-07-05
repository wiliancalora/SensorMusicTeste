
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using SensorMusic.Domain.DTO;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SensorMusic.Domain.Services
{
    public class OpenWeathermapService : IOpenWeathermapService
    {
        public async Task<OpenWeathermapTemperature> GetTemperatureAsync(string hometown)
        {
            using (var client = new HttpClient())
            {
                string clientId = "86ca034e6ee6ba2894e6168baff4f118";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var url = "http://api.openweathermap.org/data/2.5/weather?" + $"q={hometown}&appid={clientId}&units=metric";

                var request = await client.GetAsync(url);
                var response = await request.Content.ReadAsStringAsync();
                var temperature = JsonConvert.DeserializeObject<OpenWeathermapTemperature>(response);

                return temperature;
            }
        }
    }

}
