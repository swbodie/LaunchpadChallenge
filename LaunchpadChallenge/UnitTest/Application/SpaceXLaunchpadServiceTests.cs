using Application;
using AutoFixture;
using Domain;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest.Application
{
    [TestFixture]
    class SpaceXLaunchpadServiceTests
    {
        private Fixture fixture;
        private Mock<ISpaceXLaunchpadRepository> mockedLaunchpadRepository;
        private Mock<ILogger<SpaceXLaunchpadService>> mockedLogger;

        private SpaceXLaunchpadService launchpadService;
        private List<Launchpad> launchpadTestData;

        [SetUp]
        public void Setup()
        {
            this.fixture = new Fixture();
            this.mockedLaunchpadRepository = new Mock<ISpaceXLaunchpadRepository>();
            this.mockedLogger = new Mock<ILogger<SpaceXLaunchpadService>>();

            launchpadService = new SpaceXLaunchpadService(mockedLaunchpadRepository.Object, mockedLogger.Object);

           launchpadTestData = new List<Launchpad>() { Launchpad.Reconstitute("pad_1", "Launchpad 1", "active"), Launchpad.Reconstitute("pad_2", "Launchpad 2", "retired") };
        }

        [Test]
        public void GetLaunchpads_CallsLaunchpadRepository()
        {
            var launchpads = launchpadService.GetLaunchpads(new LaunchpadFilter()).Result;
            mockedLaunchpadRepository.Verify(x => x.GetLaunchpads(), Times.Once);
        }

        [Test]
        public void GetLaunchpads_DoesNotFilterResults_WhenNoFilterParametersPresent()
        {
            mockedLaunchpadRepository.Setup(x => x.GetLaunchpads()).ReturnsAsync(fixture.CreateMany<Launchpad>(4));
            List<Launchpad> launchpads = launchpadService.GetLaunchpads(new LaunchpadFilter()).Result.ToList();
            Assert.AreEqual(launchpads.Count, 4);
        }

        [Test]
        public void GetLaunchpads_FilterResultsById_WhenFilterParametersPresent()
        {
            mockedLaunchpadRepository.Setup(x => x.GetLaunchpads()).ReturnsAsync(launchpadTestData);

            var filter = new LaunchpadFilter() { Id = "pad_1", ExactMatch = true };

            List<Launchpad> launchpads = launchpadService.GetLaunchpads(filter).Result.ToList();
            Assert.AreEqual(launchpads.Count, 1);
            Assert.IsTrue(launchpads.Any(x => x.Id == "pad_1"));
        }

        [Test]
        public void GetLaunchpads_FilterResultsByName_WhenFilterParametersPresent()
        {
            mockedLaunchpadRepository.Setup(x => x.GetLaunchpads()).ReturnsAsync(launchpadTestData);

            var filter = new LaunchpadFilter() { Name = "Launchpad 1", ExactMatch = true };

            List<Launchpad> launchpads = launchpadService.GetLaunchpads(filter).Result.ToList();
            Assert.AreEqual(launchpads.Count, 1);
            Assert.IsTrue(launchpads.Any(x => x.Name == "Launchpad 1"));
        }

        [Test]
        public void GetLaunchpads_FilterResultsByStatus_WhenFilterParametersPresent()
        {
            mockedLaunchpadRepository.Setup(x => x.GetLaunchpads()).ReturnsAsync(launchpadTestData);

            var filter = new LaunchpadFilter() { Status = "active", ExactMatch = true };

            List<Launchpad> launchpads = launchpadService.GetLaunchpads(filter).Result.ToList();
            Assert.AreEqual(launchpads.Count, 1);
            Assert.IsTrue(launchpads.Any(x => x.Status == "active"));
        }
    }
}
