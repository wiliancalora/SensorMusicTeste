using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorMusic.Services.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserNotesModel> Notes { get; set; }
        public string HomeTown { get; set; }
    }
}
