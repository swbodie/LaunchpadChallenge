using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ISpaceXLaunchpadRepository
    {
        Task<IEnumerable<Launchpad>> GetLaunchpads();
    }
}
