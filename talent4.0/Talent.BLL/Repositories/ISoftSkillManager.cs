using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.BLL.DTO;

namespace Talent.BLL.Repositories
{
    public interface ISoftSkillManager
    {
        Task<IEnumerable<SPSchedulazioneGetSchedulazioniDto>> GetScheduleAsync(string codiceProcesso);
        Task<IEnumerable<SoftskillsCompetenzeDescrDto>> GetFindSkillDataByLangAsync(string languageName);

        Task<int> InsertSoftSkillTestWSResultAsync(GetWSResultDto getWSResultDto);
        Task<string> GetSoftSkillProfileDescriptionAsync(string richId);

        Task<IEnumerable<int>> PostSoftSkillProfileAsync(string[] skillDescriptionArray);
        Task<IEnumerable<ViewSoftSkillWsResultDto>> GetSavedWsResultByRisIdAsync(int risId, string langName);
    }
}
