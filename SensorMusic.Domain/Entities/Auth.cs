using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Entities
{
    public class Auth:BaseEntity
    {
        public string user { get; set; }
        public string password { get; set; }
    }
}
