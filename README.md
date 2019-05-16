# LaunchpadChallenge
SpaceX Launchpad Challenge

## Running the project
- Clone the repo to your local machine and debug the project.
- This should bring up the swagger page for you to easily test out the launchpad filter method.
- If you aren't directed to the page you can find the swagger location here: https://localhost:44385/swagger/index.html

### Filtering the launchpad results
A filter object can be supplied to the get request for filtering by Id, Name, and Status.
If you supply an empty filter object you will receive  all results from the Space X API.

There are also two other options you may supply:
- ExactMatch: setting this to false will act as a contains for all filter fields. Setting this to true will require an exact match on the filter.
- UseDisjunction: setting this to true will act as an OR for all of the filters requiring only one of the filters to match for returning. Setting this value to false will require all filters to match on the launchpad to return 

### Running the unit tests
The unit test project is using nunit as the testing framework. You may need to install the nunit test adapter extension to be able to see these tests in you test runner. https://github.com/nunit/docs/wiki/Visual-Studio-Test-Adapter

### Logging considerations
The logging that I have added is just a console log with the consideration that this is just to illustrate an implementation of a logger. Ideally this would be logged to some other location such as a file or application insights.

### Changing the data source
As an example to changing out data source I have included another mocking implementation of ISpaceXRepository, SpaceXLaunchpadDatabaseService, which can be swapped out with the current implementation SpaceXLaunchpadRetrievalService in the dependency  injection module.

### Other considerations
While there was little business logic that was needed in this application I chose to include a rather slim domain project to show how I generally structure projects. I don't think this was necessary in this project but wanted to include it to showcase that this is where that logic may live if it was needed.
