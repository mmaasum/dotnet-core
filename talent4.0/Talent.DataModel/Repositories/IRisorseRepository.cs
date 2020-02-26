using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface IRisorseRepository : IRepository<Risorse>
    {
        Task<string> LaunchRisorseSP(string richId, string cvInviati, string clientId);
        Task<IEnumerable<MatchingRisorse>> GetRisInfoByRichIdAsync(string richId, string cliId);

        Task<IEnumerable<MatchingRisorse>> MatchingRichiesteByRisIdList(string richid, string cliId,
            int[] richlistRisIdList);
    }
}