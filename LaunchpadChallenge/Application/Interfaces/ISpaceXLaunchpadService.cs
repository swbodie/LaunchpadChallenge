using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISpaceXLaunchpadService
    {
        Task<IEnumerable<Launchpad>> GetLaunchpads(LaunchpadFilter filter);
    }
}
