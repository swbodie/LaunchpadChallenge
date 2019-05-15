using Application.Interfaces;
using Domain;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class SpaceXLaunchpadService : ISpaceXLaunchpadService
    {
        private ISpaceXLaunchpadRepository launchpadRepository;
        private readonly ILogger logger;

        public SpaceXLaunchpadService(ISpaceXLaunchpadRepository launchpadRepository, ILogger<SpaceXLaunchpadService> logger)
        {
            this.launchpadRepository = launchpadRepository;
            this.logger = logger;
        }

        public async Task<IEnumerable<Launchpad>> GetLaunchpads(LaunchpadFilter launchpadFilter)
        {
            logger.LogDebug("Retrieving launchpad information from SpaceX Api.");
            var launchpads = await launchpadRepository.GetLaunchpads();

            logger.LogDebug("Returning filtered results.");
            return launchpadFilter.Filter(launchpads);
        }
    }
}
