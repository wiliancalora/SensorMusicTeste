using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.DTO
{
    public class OpenWeathermapTemperature
    {
        public Main main { get; set; }

    }
    public class Main
    {
        public double temp { get; set; }
    }

}
