using Talent.BLL.DTO;

namespace Talent.BLL.Repositories
{
    public interface ISurveyManager
    {
        /// <summary>
        /// Creaing a mail content along with the invitation link
        /// </summary>
        /// <param name="invitationDto"></param>
        /// <returns>Mail Content</returns>
        string GenerateInvitationMailBody(InvitationDto invitationDto);

        /// <summary>
        /// Creaing a content including the form questions and provided feedback by the resource.
        /// </summary>
        /// <param name="surveyDto"></param>
        /// <returns>Mail Content</returns>
        string GenerateSurveyMailBody(SurveyFormDto surveyDto);
    }
}