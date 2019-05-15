using Application;
using Application.Interfaces;
using Autofac;
using Infrastructure;
using Infrastructure.Interfaces;

namespace LaunchpadChallenge
{
    public class DependencyInjectionModule : Module
    {
        public DependencyInjectionModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SpaceXLaunchpadService>().As<ISpaceXLaunchpadService>();
            builder.RegisterType<SpaceXLaunchpadRetrievalService>().As<ISpaceXLaunchpadRepository>();
        }
    }
}
