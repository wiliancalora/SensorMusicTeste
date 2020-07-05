using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using SensorMusic.Application.Interfaces;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Services;
using SensorMusic.Services.Models;

namespace SensorMusic.Services.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/[controller]")]
    public class UserPasswordRecoveryController : Controller
    {
        private readonly IUserPasswordRecoveryAppService _userPasswordRecoveryAppService;
        readonly ILogger<SpotifyController> logger;

        public UserPasswordRecoveryController(
                                                ILogger<SpotifyController> log,
                                                IUserPasswordRecoveryAppService userPasswordRecoveryAppService)
        {
            logger = log;
            _userPasswordRecoveryAppService = userPasswordRecoveryAppService;
        }

        [AllowAnonymous]
        [Route("AddPasswordRecovery")]
        [HttpPost]
        public ActionResult Post(string email)
        {
            try
            {
                logger.LogInformation("Action Post :: UserPasswordRecoveryController -> execute"
                           + DateTime.Now.ToLongTimeString());


                var hash = _userPasswordRecoveryAppService.UserGenerateHash(email);
                return StatusCode(StatusCodes.Status200OK, hash);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }


        [AllowAnonymous]
        [Route("Reset")]
        [HttpPost]
        public ActionResult Reset(string hash, string newPassword)
        {
            try
            {
                _userPasswordRecoveryAppService.ResetPassword(hash, newPassword);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
