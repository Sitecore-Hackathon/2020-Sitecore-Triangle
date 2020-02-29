using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Install.Framework;
using Sitecore.XA.Foundation.IOC.Pipelines.IOC;
using System.Web.Services.Description;
using Triangle.Feature.HackathonTeam.Controllers;
using Triangle.Feature.HackathonTeam.Repositories;


namespace Triangle.Feature.HackathonTeam.Pipelines
{
    public class RegisterHackathonTeamServices : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IHackathonTeamRepository, HackathonTeamRepository>();
            serviceCollection.AddTransient<HackathonTeamController>();
        }
    }
}