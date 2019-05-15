using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaunchpadChallenge.Controllers
{
    [Route("api/SpaceXLaunchpads")]
    [ApiController]
    public class SpaceXLaunchpadController : ControllerBase
    {
        private ISpaceXLaunchpadService launchpadService;

        public SpaceXLaunchpadController(ISpaceXLaunchpadService launchpadService)
        {
            this.launchpadService = launchpadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpaceXLaunchpadInformation([FromQuery]LaunchpadFilter filter)
        {
            var launchpads = await launchpadService.GetLaunchpads(filter);
            return Ok(launchpads);
        }
    }
}