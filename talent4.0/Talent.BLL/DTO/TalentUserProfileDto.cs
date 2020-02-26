using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.Models;

namespace Talent.BLL.DTO
{
    public class TalentUserProfileDto
    {
        public string TauseUteId { get; set; }
        public string TauseDefaultLanguage { get; set; }
        public string TauseLandingPage { get; set; }
        public DateTime TauseInsTimestamp { get; set; }
        public string TauseInsUteId { get; set; }
        public DateTime TauseModTimestamp { get; set; }
        public string TauseModUteId { get; set; }
        public string TauseCliId { get; set; }


        public TalentUserProfileDto MapToDto(TalentUserProfiles talentUserProfiles)
        {
            TalentUserProfileDto talentUserProfileDto = new TalentUserProfileDto();
            talentUserProfileDto.TauseUteId = talentUserProfiles.TauseUteId;
            talentUserProfileDto.TauseDefaultLanguage = talentUserProfiles.TauseDefaultLanguage;
            talentUserProfileDto.TauseLandingPage = talentUserProfiles.TauseLandingPage;
            talentUserProfileDto.TauseCliId = talentUserProfiles.TauseCliId;
           
            return talentUserProfileDto;
        }
    }
}
