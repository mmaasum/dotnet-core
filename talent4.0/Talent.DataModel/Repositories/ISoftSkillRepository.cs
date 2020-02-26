using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface ISoftSkillRepository : IRepository<SoftskillsCompetenzeDescr>
    {
        Task<IEnumerable<SPSchedulazioneGetSchedulazioni>> GetScheduleListFromSPAsync(string codiceProcesso);
        Task<IEnumerable<ViewSoftSkillWsResult>> GetSavedWsResultByRisIdAndLanguageAsync(int risId, string langName);
    }
}
