using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {

        private readonly IUtilityManager _utilityManager;
        private readonly IEmailManager _emailManager;
        private readonly ISurveyManager _surveyManager;

        public SurveyController(ISurveyManager surveyManager, IUtilityManager utilityManager, IEmailManager emailManager)
        {
            _surveyManager = surveyManager;
            _utilityManager = utilityManager;
            _emailManager = emailManager;
        }




     

        /// <summary>
        ///     TO send survey invitation to specific mail and keep the record.
        /// </summary>
        /// <purpose>
        ///     An invitation link will be shared to speicic mai , through that the mail receiver will be able to take part in a survey.
        /// </purpose>
        /// <param name="invitationDto">Dto object having the first name , last name and mail address of the receiver.</param>
        /// <returns>general confirmation message</returns>
        //     POST: api/Survey/invite
        [HttpPost]
        [Route("Invite")]
        public IActionResult Invitation([FromBody] InvitationDto invitationDto)
        {
            try
            {

                if (invitationDto == null)
                {
                    return NotFound();
                }

                // Retrieving the mail body along with the invitation link.
                var mailBody = _surveyManager.GenerateInvitationMailBody(invitationDto);

                List<string> emailList = invitationDto.Email.Split(';').ToList<string>();
                emailList.Reverse();
                // Sending Invitation to the specific resource mail
                foreach (var email in emailList)
                {
                    // Initiating the mail address
                    _emailManager.To.Add(email);
                }

                // Sending Invitation to the specific resource mail
                _emailManager.Subject = "Talent_Survey_Form";
                _emailManager.Body = mailBody.ToString();
                var info = _emailManager.Send();
                if(info != "success")
                {
                    var result = new
                    {
                        error = "error",
                        error_type = "",
                        message = info
                    };
                    return BadRequest(result);
                }

                // Storing data regarding Survey invitation
                //Database tables aren't ready yet.

                return Ok();
            }
            catch (Exception x)
            {
                var result = new
                {
                    error = x.StackTrace,
                    error_type = x.InnerException,
                    message = x.Message
                };
                return BadRequest(result);
            }
        }

        /// <summary>
        ///  
        ///     Send mail having the Survey feedback & keep Record in DB.
        /// </summary>
        /// <param name="surveyFromDto"></param>
        /// <returns></returns>
        // POST: api/Survey/survey
        [HttpPost]
        [Route("survey")]
        public IActionResult FormSubmit([FromBody] SurveyFormDto surveyFromDto)
        {
            try
            {
                if (surveyFromDto == null)
                {
                    return NotFound();
                }
                // Retrieving the mail body along with the questions and provided feedback. 
                var mailBody = _surveyManager.GenerateSurveyMailBody(surveyFromDto);

                List<string> emailList = surveyFromDto.Email.Split(';').ToList<string>();
                emailList.Reverse();
                // Sending Invitation to the specific resource mail
                foreach (var email in emailList)
                {
                    // Initiating the mail address
                    _emailManager.To.Add(email);
                }

                // Sending mail to that specific person's mail by whom the survey feedback is provided.
                _emailManager.Subject = "Talent_Survey_Form";
                _emailManager.Body = mailBody.ToString();
                _emailManager.Send();

                // Storing data regarding Survey feedback.
                //Database tables aren't ready yet!
                return Ok();
            }
            catch (Exception x)
            {
                var result = new
                {
                    error = x.StackTrace,
                    error_type = x.InnerException,
                    message = x.Message
                };
                // Returning Exception object.
                return BadRequest(result);
            }
        }






        [HttpPost]
        [Route("TestEmail")]
        public IActionResult TestEmail([FromBody] EmailDto emailDto) 
        {
            try
            {
                // Retrieving the dto object that contain the mail address and mail body
                // which is required to send the mail to the specific risorse.

                // Initiating the recipient email address
                _emailManager.To.Add(emailDto.To);
                // Initiating the recipient email address
                _emailManager.Cc.Add(emailDto.CC);
                // Initiating the sender email address
                _emailManager.From = emailDto.From;
                // Initiating the mail subject
                _emailManager.Subject = emailDto.Sub;
                // Initiating the mail body
                _emailManager.Body = emailDto.Body;
                // Sending the mail to the specific recipient
                var status = _emailManager.Send();
                //// creating the azioni object passing the related details and description.
                //var azioniDto = _talentBLLWrapper.UtilityBll.GetAzioniDtoObject(User, "email", "send hard skill invitation");
                //// logging the activity record by the user.
                //_talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);
                return Ok(new { status = status });
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = _utilityManager.ReturnErrorObj(x, User, "Send Hard skill invitation");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }



    }


    public class EmailDto
    {
        public string From { get; set; }
        // first name of the surveyor
        public string To { get; set; }
        // last name of the surveyor
        public string CC { get; set; }
        // langIndex defines the index of the selected language by the surveyor
        public string Sub { get; set; }
        public string Body { get; set; }
        public IFormFile Attachment { get; set; }
    }

}
