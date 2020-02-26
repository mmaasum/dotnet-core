using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Talent.BLL.DTO;

namespace Talent.BLL.Repositories
{
    public interface IHardSkillManager
    {
        Task<IEnumerable<TestRisultatiDto>> GetHardSkillAsync(int risId);
        Task<IEnumerable<TestCompetenzeDto>> GetAllCompetenzaAsync(string clientId);
        Task<IEnumerable<TestValutazioneDto>> GetAllTestValutazioneAsync(string competenza, string clientId);
        Task<IEnumerable<TestValutazioneDto>> GetTestValutazioneDataByTypeAsync(int risId, string clientId, string type);

        Task<HardSkillInvitationDto> SendHardSkillInvitationAsync(string[] titoloList, int risId, string clientId);

        Task<IEnumerable<ModelliEmailDto>> GetMailModelAsync(ClaimsPrincipal User, string langName);
    }
}