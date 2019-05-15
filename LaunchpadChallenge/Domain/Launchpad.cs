using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Launchpad
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Status { get; private set; }

        private Launchpad() { }

        public static Launchpad Reconstitute (string id, string name, string status)
        {
            return new Launchpad()
            {
                Id = id,
                Name = name,
                Status = status
            };
        }
    }
}
