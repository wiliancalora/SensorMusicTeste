using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using SensorMusic.Application.Interfaces;
using SensorMusic.Domain.Services;
using SensorMusic.Services.Models;

namespace SensorMusic.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SpotifyController : Controller
    {
        private readonly ISpotifyAppService _spotifyAppService;
        private readonly IOpenWeathermapAppService _openWeathermapAppService;
        readonly ILogger<SpotifyController> logger;

        public SpotifyController(   ILogger<SpotifyController> log,
                                    ISpotifyAppService spotifyAppService,
                                    IOpenWeathermapAppService openWeathermapAppService
                                )
        {
            logger = log;
            _spotifyAppService = spotifyAppService;
            _openWeathermapAppService = openWeathermapAppService;
        }

        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            try
            {
                StringValues values;
                this.Request.Headers.TryGetValue("Authorization", out values);

                logger.LogInformation("Action Get :: SpotifyController -> execute"
                            + DateTime.Now.ToLongTimeString() + " token:" + values.ToString().Replace("Bearer ", ""));


                var idUser = TokenService.ReadTokenReturnValue(values.ToString().Replace("Bearer ", ""), "IdUser");

                var hometown = TokenService.ReadTokenReturnValue(values.ToString().Replace("Bearer ", ""), "Hometown");

                var temperature = await Task.Run(() => _openWeathermapAppService.GetTemperature(hometown));
                var temp = temperature.main.temp;
                string genre = "";

                if (temp > 30)
                {
                    genre = "dancehall";
                }
                else if (temp >= 15 && temp <= 30)
                {
                    genre = "pop";
                }
                else if (temp >= 10 && temp <= 14)
                {
                    genre = "rock";
                }else
                {
                    genre = "classical";
                }

                var list = await Task.Run(() => _spotifyAppService.GetPlayListAsync(genre));

                if (list != null)
                {
                    return StatusCode(StatusCodes.Status200OK, list);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
