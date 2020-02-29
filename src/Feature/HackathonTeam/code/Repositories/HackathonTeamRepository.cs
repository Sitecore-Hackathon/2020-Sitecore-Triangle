using Sitecore;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.XA.Foundation.Abstractions;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using Sitecore.XA.Foundation.RenderingVariants.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triangle.Feature.HackathonTeam.Models;

namespace Triangle.Feature.HackathonTeam.Repositories
{
    public class HackathonTeamRepository : VariantsRepository, IHackathonTeamRepository
    {
        private readonly string External_Text = "external";
        public override IRenderingModelBase GetModel()
        {
            string dataSource = RenderingContext.Current.Rendering.DataSource;
            Item contextItem = Context.Database.GetItem(dataSource);

            Models.HackathonTeam model = GetHackathonTeam(contextItem, Context);

            FillBaseProperties(model);

            return model;
            
        }

        public bool IsValid(Models.HackathonTeam hackathonTeam)
        {
            return true;
        }

        public bool CreateParticipant(Models.HackathonTeam hackathonTeam)
        {
            bool isCreatedParticipant = true;
            try
            {

            
                if (!string.IsNullOrEmpty(hackathonTeam.ParticipantPathGuid))
                {
                    Sitecore.Data.Database database = Sitecore.Data.Database.GetDatabase("master");
                    TemplateItem templateParticipant = database.GetTemplate(Template.Participant.TemplateId);
                    Item participantParent = database.GetItem(hackathonTeam.ParticipantPathGuid);

                    //we should not use admin... but this is just for hackathon purpose
                    Sitecore.Security.Accounts.User someUser = Sitecore.Security.Accounts.User.FromName(@"sitecore\admin", false);
                    using (new Sitecore.Security.Accounts.UserSwitcher(someUser))
                    {
                        Item participant = participantParent.Add(hackathonTeam.TeamMember.TeamName, templateParticipant);
                        if(participant != null)
                        {
                            try
                            {
                                participant.Editing.BeginEdit();

                                participant[Template.Participant.Fields.FieldnameTeamName] = hackathonTeam.TeamMember.TeamName;
                                participant[Template.Participant.Fields.FieldnameTeamDescription] = hackathonTeam.TeamMember.TeamDescription;
                                participant[Template.Participant.Fields.FieldnameYear] = System.DateTime.Today.Year.ToString();

                                participant[Template.Participant.Fields.FieldnameFirstname] = hackathonTeam.TeamMember.Mem1Firstname;
                                participant[Template.Participant.Fields.FieldnameLastname] = hackathonTeam.TeamMember.Mem1Lastname;
                                participant[Template.Participant.Fields.FieldnameFacebook] = this.GetValueForGeneralLinkRaw(hackathonTeam.TeamMember.Mem1FacebookURL, External_Text);
                                participant[Template.Participant.Fields.FieldnameLinkedIn] = this.GetValueForGeneralLinkRaw(hackathonTeam.TeamMember.Mem1LinkedInURL, External_Text);
                                participant[Template.Participant.Fields.FieldnameTwitter] = this.GetValueForGeneralLinkRaw(hackathonTeam.TeamMember.Mem1TwitterURL, External_Text);

                                participant[Template.Participant.Fields.FieldnameMem2Firstname] = hackathonTeam.TeamMember.Mem2Firstname;
                                participant[Template.Participant.Fields.FieldnameMem2Lastname] = hackathonTeam.TeamMember.Mem2Lastname;
                                participant[Template.Participant.Fields.FieldnameMem2Facebook] = this.GetValueForGeneralLinkRaw(hackathonTeam.TeamMember.Mem2FacebookURL, External_Text);
                                participant[Template.Participant.Fields.FieldnameMem2LinkedIn] = this.GetValueForGeneralLinkRaw(hackathonTeam.TeamMember.Mem2LinkedInURL, External_Text);
                                participant[Template.Participant.Fields.FieldnameMem2Twitter] = this.GetValueForGeneralLinkRaw(hackathonTeam.TeamMember.Mem2TwitterURL, External_Text);

                                participant[Template.Participant.Fields.FieldnameMem3Firstname] = hackathonTeam.TeamMember.Mem3Firstname;
                                participant[Template.Participant.Fields.FieldnameMem3Lastname] = hackathonTeam.TeamMember.Mem3Lastname;
                                participant[Template.Participant.Fields.FieldnameMem3Facebook] = this.GetValueForGeneralLinkRaw(hackathonTeam.TeamMember.Mem3FacebookURL, External_Text);
                                participant[Template.Participant.Fields.FieldnameMem3LinkedIn] = this.GetValueForGeneralLinkRaw(hackathonTeam.TeamMember.Mem3LinkedInURL, External_Text);
                                participant[Template.Participant.Fields.FieldnameMem3Twitter] = this.GetValueForGeneralLinkRaw(hackathonTeam.TeamMember.Mem3TwitterURL, External_Text);

                                participant.Editing.EndEdit();
                            }
                            catch
                            {
                                participant.Editing.CancelEdit();
                            }
                        }
                    }
                }
            

            }
            catch (Exception ex)
            {
                
                isCreatedParticipant = false;
            }
            return isCreatedParticipant;
        }

        public RegistrationThankYou GetRegistrationThankYouModel()
        {
            string dataSource = RenderingContext.Current.Rendering.DataSource;
            Item contextItem = Context.Database.GetItem(dataSource);
            RegistrationThankYou model = GetRegistrationThankYouModel(contextItem);
            return model;
        }

        private string GetValueForGeneralLinkRaw(string Url, string linkType)
        {
            return "<link linktype=\"" + linkType + "\" url=\"" + Url + "\" />";

        }

        private Models.HackathonTeam GetHackathonTeam(Item item, IContext context)
        {
            Models.HackathonTeam hackathonTeam = null;
            if (item != null)
            {
                hackathonTeam = new Models.HackathonTeam();
                if (!string.IsNullOrEmpty(item.Fields[Template.HackathonRegistration.Fields.FieldnameTitle].Value))
                {
                    hackathonTeam.Title = item.Fields[Template.HackathonRegistration.Fields.FieldnameTitle].Value;
                }
                if (!string.IsNullOrEmpty(item.Fields[Template.HackathonRegistration.Fields.FieldnameDescription].Value))
                {
                    hackathonTeam.Description = item.Fields[Template.HackathonRegistration.Fields.FieldnameDescription].Value;
                }

                if (!string.IsNullOrEmpty(item.Fields[Template.HackathonRegistration.Fields.FieldnameTeamName].Value))
                {
                    hackathonTeam.TeamName = item.Fields[Template.HackathonRegistration.Fields.FieldnameTeamName].Value;
                }
                if (!string.IsNullOrEmpty(item.Fields[Template.HackathonRegistration.Fields.FieldnameTeamDescription].Value))
                {
                    hackathonTeam.TeamDescription = item.Fields[Template.HackathonRegistration.Fields.FieldnameTeamDescription].Value;
                }
                hackathonTeam.Mem1Caption = item.Fields[Template.HackathonRegistration.Fields.FieldnameMem1Caption].Value;
                hackathonTeam.Mem2Caption = item.Fields[Template.HackathonRegistration.Fields.FieldnameMem2Caption].Value;
                hackathonTeam.Mem3Caption = item.Fields[Template.HackathonRegistration.Fields.FieldnameMem3Caption].Value;
                hackathonTeam.Firstname = item.Fields[Template.HackathonRegistration.Fields.FieldnameFirstname].Value;
                hackathonTeam.Firstname = item.Fields[Template.HackathonRegistration.Fields.FieldnameLastname].Value;
                hackathonTeam.Facebook = item.Fields[Template.HackathonRegistration.Fields.FieldnameFacebook].Value;
                hackathonTeam.LinkedIn = item.Fields[Template.HackathonRegistration.Fields.FieldnameLinkedIn].Value;
                hackathonTeam.Twitter = item.Fields[Template.HackathonRegistration.Fields.FieldnameTwitter].Value;

                hackathonTeam.ResponseErrorMessage = item.Fields[Template.HackathonRegistration.Fields.FieldnameErrorMessage].Value;
                hackathonTeam.ResponseValidationErrorMessage = item.Fields[Template.HackathonRegistration.Fields.FieldnameValidationErrorMessage].Value;

                LinkField linkField = item.Fields[Template.HackathonRegistration.Fields.FieldnameThankYou];

                string thankYouResponse = string.Empty;
                switch (linkField.LinkType.ToLower())
                {
                    case "internal":
                        thankYouResponse = linkField.TargetItem != null ? Sitecore.Links.LinkManager.GetItemUrl(linkField.TargetItem) : string.Empty;
                        break;
                    case "external":
                        thankYouResponse = linkField.Url;
                        break;
                }

                hackathonTeam.ResponseThankYou = thankYouResponse;

                hackathonTeam.ParticipantPath = item.Fields[Template.HackathonRegistration.Fields.FieldnameParticipantPath].Value;
                if(!string.IsNullOrEmpty(hackathonTeam.ParticipantPath))
                {
                    hackathonTeam.ParticipantPathGuid = context.Database.GetItem(hackathonTeam.ParticipantPath).ID.Guid.ToString();
                }

                if(item.Fields[Template.HackathonRegistration.Fields.FieldnameEndDate] != null)
                {
                    DateField registrationEndDate = item.Fields[Template.HackathonRegistration.Fields.FieldnameEndDate];

                    string dateTimeString = registrationEndDate.Value;
                    hackathonTeam.RegistraionEndDate = Sitecore.DateUtil.IsoDateToDateTime(dateTimeString);
                    hackathonTeam.RegistraionEndMessage = item.Fields[Template.HackathonRegistration.Fields.FieldnameRegistrationEndMessage].Value;

                }
                

            }


            return hackathonTeam;
        }

        private RegistrationThankYou GetRegistrationThankYouModel(Item item)
        {
            RegistrationThankYou registrationThankYou = null;
            if(item != null)
            {
                registrationThankYou = new RegistrationThankYou();

                if (!string.IsNullOrEmpty(item.Fields[Template.RegistrationThankYou.Fields.FieldnameThankYouMessage].Value))
                {
                    registrationThankYou.ThankYouMessage = item.Fields[Template.RegistrationThankYou.Fields.FieldnameThankYouMessage].Value;
                }
            }
            return registrationThankYou;
        }
    }
}