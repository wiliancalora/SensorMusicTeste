using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Entities
{
    public class User : BaseEntity
    {
        public Int64 IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Hometown { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public List<UserNotes> Notes { get; set; }
    }
}
