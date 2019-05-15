using Application;
using Application.Interfaces;
using Autofac;
using Infrastructure;
using Infrastructure.Interfaces;

namespace LaunchpadChallenge
{
    public class DependencyInjectionModule : Module
    {
        private string SpaceXApiUrl { get; set; }

        public DependencyInjectionModule(string spacexApiUrl)
        {
            this.SpaceXApiUrl = spacexApiUrl;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SpaceXLaunchpadService>().As<ISpaceXLaunchpadService>();

            // To illustrate the challenges requirment of changing the implementation of how the launchpad data is retrieved,
            // I have added two different implementations you can switch between. You may do so below by switching between the commented registrations.
            builder.RegisterType<SpaceXLaunchpadRetrievalService>().As<ISpaceXLaunchpadRepository>().WithParameter("apiUrl", SpaceXApiUrl);
            //builder.RegisterType<SpaceXLaunchpadDatabaseService>().As<ISpaceXLaunchpadRepository>();
        }
    }
}
