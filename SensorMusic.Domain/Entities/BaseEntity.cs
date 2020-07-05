using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.Entities
{
    public abstract class BaseEntity : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
