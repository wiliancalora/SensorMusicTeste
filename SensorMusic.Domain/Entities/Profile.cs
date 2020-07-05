using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Entities
{
    public class Profile : BaseEntity
    {
        public Int64 IdUser { get; set; }
        public string Name { get; set; }
        public string HomeTown { get; set; }
    }
}
