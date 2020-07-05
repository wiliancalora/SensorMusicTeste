using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SensorMusic.Application.Interfaces;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Services;
using SensorMusic.Domain.Services.Util;
using SensorMusic.Services.Models;

namespace SensorMusic.Services.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserAppService _userAppService;
        readonly ILogger<AuthController> logger;

        public AuthController(
                                ILogger<AuthController> log,
                                IUserAppService userAppService)
        {
            logger = log;
            _userAppService = userAppService;
        }

        [ApiVersion("1.0")]
        [AllowAnonymous]
        [HttpPost]
        [Route("auth")]
        public async Task<ActionResult<dynamic>> Autentication([FromBody] AuthModel auth)
        {
            logger.LogInformation("Action Autentication :: AuthController -> execute"
                       + DateTime.Now.ToLongTimeString());


            var user = _userAppService.Login(auth.user, Encryptor.GenerateHashMd5(auth.password));

            if (user == null)
            {
                var result = new ObjectResult(new { erro = "User or password incorret" });
                result.StatusCode = 401;
                return result;
            }

            // Gera o Token
            var token = TokenService.GenerateToken(new User {IdUser = user.IdUser, Hometown = user.Hometown });

            // Retorna os dados
            return new
            {
                token = token
            };
        }
    }
}
