using Application;
using Application.Interfaces;
using AutoFixture;
using Domain;
using LaunchpadChallenge.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Api
{
    [TestFixture]
    class SpaceXLaunchpadControllerTests
    {
        private Fixture fixture;
        private Mock<ISpaceXLaunchpadService> mockedLaunchpadService;
        private Mock<ILogger<SpaceXLaunchpadController>> mockedLogger;

        private SpaceXLaunchpadController controller;

        [SetUp]
        public void Setup()
        {
            this.fixture = new Fixture();
            this.mockedLaunchpadService = new Mock<ISpaceXLaunchpadService>();
            this.mockedLogger = new Mock<ILogger<SpaceXLaunchpadController>>();

            controller = new SpaceXLaunchpadController(mockedLaunchpadService.Object, mockedLogger.Object);
        }

        [Test]
        public void GetSpaceXLaunchpadInformation_ReturnsOkayWithContent_WhenValidRequest()
        {
            mockedLaunchpadService.Setup(x => x.GetLaunchpads(It.IsAny<LaunchpadFilter>())).ReturnsAsync(fixture.CreateMany<Launchpad>());
            var response = controller.GetSpaceXLaunchpadInformation(new LaunchpadFilter()).Result;
            mockedLaunchpadService.Verify(x => x.GetLaunchpads(It.IsAny<LaunchpadFilter>()), Times.Once);

            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public void GetSpaceXLaunchpadInformation_Returns500_WhenUnhandledExceptionOccurs()
        {
            mockedLaunchpadService.Setup(x => x.GetLaunchpads(It.IsAny<LaunchpadFilter>())).ThrowsAsync(new Exception("Something bad happend!"));
            var response = controller.GetSpaceXLaunchpadInformation(new LaunchpadFilter()).Result;

            Assert.IsInstanceOf<StatusCodeResult>(response);
            Assert.AreEqual(((StatusCodeResult)response).StatusCode, 500);
        }
    }
}
