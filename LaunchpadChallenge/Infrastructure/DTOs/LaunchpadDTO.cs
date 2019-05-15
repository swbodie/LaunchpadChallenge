using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTOs
{
    public class LaunchpadDTO
    {
        public int padid { get; set; }
        public string id { get; set; }
        public string full_name { get; set; }
        public string status { get; set; }
        public LaunchpadLocationDTO location { get; set; }
        public IEnumerable<string> vehicles_launched { get; set; }
        public int attempted_launches { get; set; }
        public int successful_launches { get; set; }
        public string wikipedia { get; set; }
        public string details { get; set; }

        public Launchpad ToDomain()
        {
            return Launchpad.Reconstitute(this.id, this.full_name, this.status);
        }
    }
}
