using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTOs
{
    public class LaunchpadLocationDTO
    {
        public string name { get; set; }
        public string region { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
