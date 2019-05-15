using Application.Interfaces;
using Domain;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class SpaceXLaunchpadService : ISpaceXLaunchpadService
    {
        private ISpaceXLaunchpadRepository launchpadRepository;

        public SpaceXLaunchpadService(ISpaceXLaunchpadRepository launchpadRepository)
        {
            this.launchpadRepository = launchpadRepository;
        }

        public async Task<IEnumerable<Launchpad>> GetLaunchpads()
        {
            return await launchpadRepository.GetLaunchpads();
        }
    }
}
