using Sitecore.XA.Foundation.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Triangle.Feature.HackathonTeam.Repositories;

namespace Triangle.Feature.HackathonTeam.Controllers
{
    public class HackathonTeamController : StandardController
    {
        private string _token_FirstName = "--firstname--";
        private string _token_LastName = "--lastname--";
        private string _token_TeamName = "--teamname--";
        protected IHackathonTeamRepository _HackathonTeamRepository { get; set; }

        public HackathonTeamController(IHackathonTeamRepository hackathonTeamRepository)
        {
            this._HackathonTeamRepository = hackathonTeamRepository;
        }

        [HttpGet]
        public ActionResult GetHackathonTeamRegistration()
        {
            var renderingModel = this._HackathonTeamRepository.GetModel();
            return View("~/Views/Hackathon/HackathonTeam/HackathonTeamRegistration.cshtml", renderingModel);
        }

        [HttpPost]
        public ActionResult HackathonTeamRegistration(Models.HackathonTeam hackathonTeam)
        {
            //Validate input
            bool isValid = this._HackathonTeamRepository.IsValid(hackathonTeam);

            if (isValid)
            {
                //create participants
                if(this._HackathonTeamRepository.CreateParticipant(hackathonTeam))
                {
                    TempData["Teamname"] = hackathonTeam.TeamMember.TeamName;
                    TempData["firstname"] = hackathonTeam.TeamMember.Mem1Firstname;
                    TempData["lastname"] = hackathonTeam.TeamMember.Mem1Lastname;
                    Response.Redirect(hackathonTeam.ResponseThankYou);
                }
            }

            return null;
        }

        [HttpGet]
        public ActionResult DisplayThankYou()
        {
            //create temp data so that it can be access on other action methods. 
            string teamName = TempData["Teamname"] != null ? TempData["Teamname"].ToString() : string.Empty;
            string lastName = TempData["lastname"] != null ? TempData["lastname"].ToString() : string.Empty;
            string firstName = TempData["firstname"] != null ? TempData["firstname"].ToString() : string.Empty;
            Models.RegistrationThankYou model = null;

            if (string.IsNullOrEmpty(teamName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName))
            {
                Response.Redirect("/");
            }
            else
            {
                model = this._HackathonTeamRepository.GetRegistrationThankYouModel();

                model.ThankYouMessage = model.ThankYouMessage.Replace(_token_FirstName, firstName);
                model.ThankYouMessage = model.ThankYouMessage.Replace(_token_LastName, lastName);
                model.ThankYouMessage = model.ThankYouMessage.Replace(_token_TeamName, teamName);

                
            }
            return View("~/Views/Hackathon/HackathonTeam/HackathonTeamThankYou.cshtml", model);
        }


        protected override object GetModel()
        {
            return _HackathonTeamRepository.GetModel();
        }

    }
}