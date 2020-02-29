using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Triangle.Feature.HackathonTeam.Models
{
    public class HackathonTeam : VariantsRenderingModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string TeamName { get; set; }

        public string TeamDescription { get; set; }

        public string Mem1Caption { get; set; }
        public string Mem2Caption { get; set; }
        public string Mem3Caption { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }

        public ParticipantTeam TeamMember { get; set; }

        public string ResponseErrorMessage { get; set; }
        public string ResponseValidationErrorMessage { get; set; }

        public string ResponseThankYou { get; set; }

        public string ParticipantPath { get; set; }
        public string ParticipantPathGuid { get; set; }

        public DateTime RegistraionEndDate { get; set; }
        public string RegistraionEndMessage { get; set; }

    }

    public class ParticipantTeam
    {
        public string TeamName { get; set; }

        public string TeamDescription { get; set; }

        public Int32 Year { get; set; }
        public string Mem1Firstname { get; set; }
        public string Mem1Lastname { get; set; }
        public string Mem1FacebookURL { get; set; }
        public string Mem1LinkedInURL { get; set; }
        public string Mem1TwitterURL { get; set; }

        public string Mem2Firstname { get; set; }
        public string Mem2Lastname { get; set; }
        public string Mem2FacebookURL { get; set; }
        public string Mem2LinkedInURL { get; set; }
        public string Mem2TwitterURL { get; set; }

        public string Mem3Firstname { get; set; }
        public string Mem3Lastname { get; set; }
        public string Mem3FacebookURL { get; set; }
        public string Mem3LinkedInURL { get; set; }
        public string Mem3TwitterURL { get; set; }
    }
}