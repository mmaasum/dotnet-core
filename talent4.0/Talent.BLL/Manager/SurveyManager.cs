using System;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.DataModel.DataModels;

namespace Talent.BLL.Manager
{
    public class SurveyManager : ISurveyManager
    {
        public string GenerateInvitationMailBody(InvitationDto invitationDto)
        {
            // Embedding the invited resource Name & Mail to the invation link.
            string invitationLink = AppSettingsDto.BaseDomainName + "/index.html?fName="
                                                                  + invitationDto.FirstName + "&lName="
                                                                  + invitationDto.SurName + "&email="
                                                                  + invitationDto.Email;

            // Concatenating some additional text to the mail body.
            string mailBody = "<br />Dear "
                              + invitationDto.FirstName + " "
                              + invitationDto.SurName + ",<br /><br />"
                              + "Please click the invitation link given below to have a survey form : <br />"
                              + "<a href='http://" + invitationLink + "'>Talent Survey Form</a>"
                              + "<br /><br /><b> N.B:  Please do not reply in this mail </b><br /><br /> Thanks, <br /> Talent Team";

            return mailBody;
        }

        /// <summary>
        /// Creaing a content including the form questions and provided feedback by the resource.
        /// </summary>
        /// <param name="surveyDto"></param>
        /// <returns>Mail Content</returns>
        public string GenerateSurveyMailBody(SurveyFormDto surveyDto)
        {
            // Static Option Array of survey form.
            string[] optionArray = {    "totalmente in disaccordo", "abbastanza in disaccordo",
                "abbastanza d’accordo", "totalmente d’accordo"
            };

            var mailContent = "";
            for (int i = 0; i < (surveyDto.Feedback.Length); i++)
            {
                mailContent +=
                    // Concatenating the question in the mail body.
                    "Q: " + surveyDto.Questions[i]
                          // Feedback 'TEXT' is being retreived from the Option Array and concatenating to the mail body.
                          + " : <b>" + optionArray[Int32.Parse(surveyDto.Feedback[i])]
                          + "</b><br />";
            }

            // Concatenating some additional text to the mail body.
            string mailBody =
                "<br />Dear User" + ",<br /><br /> <br/>"
                                  + "Here is your provided feedback : <br /> "
                                  + mailContent;

            return mailBody;
        }
    }
}