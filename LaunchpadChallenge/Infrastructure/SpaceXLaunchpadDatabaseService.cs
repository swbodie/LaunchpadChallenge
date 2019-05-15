using AutoFixture;
using Domain;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    // The purpose of this class is to illustrate the replacement of the retrieval of the lauchpad data with minimal code changes.
    // To test this please find the dependcy injection module and replace the implementation of ISpaceXLaunchpadRepository to this class.
    // The service is named database service for that point but it is just using autofixture to return fake data.
    public class SpaceXLaunchpadDatabaseService : ISpaceXLaunchpadRepository
    {
        private Fixture fixture;

        public SpaceXLaunchpadDatabaseService()
        {
            this.fixture = new Fixture();
        }
        
        public Task<IEnumerable<Launchpad>> GetLaunchpads()
        {
            return Task.FromResult<IEnumerable<Launchpad>>(fixture.CreateMany<Launchpad>());
        }
    }
}
