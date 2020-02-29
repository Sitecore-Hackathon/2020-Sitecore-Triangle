using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Triangle.Feature.HackathonTeam
{
    public struct Template
    {
        public struct HackathonRegistration
        {
            public static readonly ID TemplateId = new ID("{A074FD11-61F7-41C0-8EEF-0F3D6A64784D}");

            public struct Fields
            {
                public static readonly string FieldnameTitle = "Title";
                public static readonly string FieldnameDescription = "Description";

                public static readonly ID FieldTeamName = new ID("{2EE24B7E-A58D-48AB-9009-F356DA19F08F}");
                public static readonly string FieldnameTeamName = "TeamName";
                public static readonly ID FieldTeamDescription = new ID("{85164794-BCAE-41CF-B1F2-034AAB94205E}");
                public static readonly string FieldnameTeamDescription = "TeamDescription";
                public static readonly string FieldnameMem1Caption = "Mem1Caption";
                public static readonly string FieldnameMem2Caption = "Mem2Caption";
                public static readonly string FieldnameMem3Caption = "Mem3Caption";
                public static readonly string FieldnameFirstname = "Firstname";
                public static readonly string FieldnameLastname = "Lastname";

                public static readonly string FieldnameFacebook = "Facebook";
                public static readonly string FieldnameLinkedIn = "LinkedIn";
                public static readonly string FieldnameTwitter = "Twitter";

                public static readonly string FieldnameErrorMessage = "ErrorMessage";
                public static readonly string FieldnameValidationErrorMessage = "ValidationErrorMessage";
                public static readonly string FieldnameThankYou = "ThankYou";
                public static readonly string FieldnameParticipantPath = "ParticipantPath";

                public static readonly string FieldnameEndDate = "EndDate";
                public static readonly string FieldnameRegistrationEndMessage = "RegistrationEndMessage";


            }
        }

        public struct Participant
        {
            public static readonly ID TemplateId = new ID("{81DB1A9A-66D0-42D6-8226-792C193E2417}");

            public struct Fields
            {
                public static readonly string FieldnameTeamName = "TeamName";
                public static readonly string FieldnameTeamDescription = "TeamDescription";
                public static readonly string FieldnameYear = "Year";

                public static readonly string FieldnameFirstname = "Firstname";
                public static readonly string FieldnameLastname = "Lastname";
                public static readonly string FieldnameFacebook = "Facebook";
                public static readonly string FieldnameLinkedIn = "LinkedIn";
                public static readonly string FieldnameTwitter = "Twitter";

                public static readonly string FieldnameMem2Firstname = "Mem2Firstname";
                public static readonly string FieldnameMem2Lastname = "Mem2Lastname";
                public static readonly string FieldnameMem2Facebook = "Mem2Facebook";
                public static readonly string FieldnameMem2LinkedIn = "Mem2LinkedIn";
                public static readonly string FieldnameMem2Twitter = "Mem2Twitter";

                public static readonly string FieldnameMem3Firstname = "Mem3Firstname";
                public static readonly string FieldnameMem3Lastname = "Mem3Lastname";
                public static readonly string FieldnameMem3Facebook = "Mem3Facebook";
                public static readonly string FieldnameMem3LinkedIn = "Mem3LinkedIn";
                public static readonly string FieldnameMem3Twitter = "Mem3Twitter";
            }
        }

        public struct RegistrationThankYou
        {
            public struct Fields
            {
                public static readonly string FieldnameThankYouMessage = "ThankYouMessage";
            }
        }

    }
}