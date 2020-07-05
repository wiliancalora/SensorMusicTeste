using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Entities
{
    public class UserPasswordRecovery:BaseEntity
    {
        public string Email { get; set; }
        public string Hash { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
