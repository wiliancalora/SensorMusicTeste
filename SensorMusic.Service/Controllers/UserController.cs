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
    public class UserController : Controller
    {
        private readonly IUserRegisterAppService _userRegisterAppService;
        readonly ILogger<UserController> logger;

        public UserController(ILogger<UserController> log,
                              IUserRegisterAppService userRegisterAppService)
        {
            logger = log;
            _userRegisterAppService = userRegisterAppService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Post([FromBody] UserModel user)
        {
            try
            {
                logger.LogInformation("Action Post :: UserController -> execute"
                       + DateTime.Now.ToLongTimeString());


                List<UserNotes> notes = new List<UserNotes>();
                foreach (var item in user.Notes)
                {
                    notes.Add(new UserNotes { Note = item.Note });
                }

                _userRegisterAppService.AddUserRegister(
                    new User
                    {
                        Email = user.Email,
                        Password = user.Password
                    },
                    new Profile
                    {
                        Name = user.Name,
                        HomeTown = user.HomeTown
                    },
                    notes
                );
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
