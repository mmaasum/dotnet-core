using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;

namespace Talent.BLL.DTO
{
    public class InvitationDto
    {
        public string FirstName;
        public string SurName;
        public string Email;
    }

    public class SurveyFormDto
    {
        public string[] Feedback;
        public string[] Questions;
        public string Email;
    }


    public class HardSkillInvitationDto
    {
        public string Email;
        public string EmailBody;
    }
}
