using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Entities
{
    public class UserNotes : BaseEntity
    {
        public Int64 IdUser { get; set; }
        public string Note { get; set; }
    }
}
