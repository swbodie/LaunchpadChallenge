using Domain;
using Infrastructure.DTOs;
using Infrastructure.Interfaces;
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

        public SpaceXLaunchpadRetrievalService()
        {
            this.client = new RestClient("https://api.spacexdata.com/v2/");
        }

        public async Task<IEnumerable<Launchpad>> GetLaunchpads()
        {
            var request = new RestRequest("launchpads", Method.GET);

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //TODO: log
                throw new Exception(response.ErrorMessage);
            }

            var spaceXLaunchpads = JsonConvert.DeserializeObject<IEnumerable<LaunchpadDTO>>(response.Content);

            return spaceXLaunchpads.Select(lp => lp.ToDomain());
        }
    }
}
