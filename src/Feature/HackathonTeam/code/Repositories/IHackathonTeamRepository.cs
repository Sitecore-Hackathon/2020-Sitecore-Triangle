using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using Sitecore.XA.Foundation.RenderingVariants.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triangle.Feature.HackathonTeam.Models;
using HTM = Triangle.Feature.HackathonTeam.Models;

namespace Triangle.Feature.HackathonTeam.Repositories
{
    public interface IHackathonTeamRepository : IVariantsRepository
    {
        bool IsValid(Models.HackathonTeam hackathonTeam);

        bool CreateParticipant(Models.HackathonTeam hackathonTeam);

        RegistrationThankYou GetRegistrationThankYouModel();
        
    }
}