using System;
using System.Threading.Tasks;
using Application;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LaunchpadChallenge.Controllers
{
    [Route("api/SpaceXLaunchpads")]
    [ApiController]
    public class SpaceXLaunchpadController : ControllerBase
    {
        private ISpaceXLaunchpadService launchpadService;
        private readonly ILogger logger;

        public SpaceXLaunchpadController(ISpaceXLaunchpadService launchpadService, ILogger<SpaceXLaunchpadController> logger)
        {
            this.launchpadService = launchpadService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpaceXLaunchpadInformation([FromQuery]LaunchpadFilter filter)
        {
            try
            {
                logger.LogDebug("A request for launch pad information has been made."); //Not the most useful, just using to show an example.
                var launchpads = await launchpadService.GetLaunchpads(filter);
                return Ok(launchpads);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unhandled exception occured getting the launchpad information for SpaceX");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}