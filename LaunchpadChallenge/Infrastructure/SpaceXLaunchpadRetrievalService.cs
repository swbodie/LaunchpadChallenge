using Domain;
using Infrastructure.DTOs;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class SpaceXLaunchpadRetrievalService : ISpaceXLaunchpadRepository
    {
        private readonly RestClient client;
        private readonly ILogger logger;

        public SpaceXLaunchpadRetrievalService(string apiUrl, ILogger<SpaceXLaunchpadRetrievalService> logger)
        {
            this.client = new RestClient(apiUrl);
            this.logger = logger;
        }

        public async Task<IEnumerable<Launchpad>> GetLaunchpads()
        {
            var request = new RestRequest("launchpads", Method.GET);

            logger.LogDebug($"Executing GET request to SpaceX Launchpad API: {client.BaseUrl + request.Resource}");
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                logger.LogError($"Failed to successfully call the SpaceX API: {response.ErrorMessage}");
                throw new Exception(response.ErrorMessage);
            }

            var spaceXLaunchpads = JsonConvert.DeserializeObject<IEnumerable<LaunchpadDTO>>(response.Content);

            return spaceXLaunchpads.Select(lp => lp.ToDomain());
        }
    }
}
