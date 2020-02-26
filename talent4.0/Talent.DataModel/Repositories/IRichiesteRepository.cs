using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface IRichiesteRepository : IRepository<Richieste>
    {
        Task<IEnumerable<StatiRichiesteListaRisorseDescr>> GetStatiRichListRisDescrAsync(string langName);
        Task<string> InsertRichieste(Richieste richieste);
        Task<IEnumerable<MatchingRisorse>> MatchingRichieste(string richId, string cliId);

        Task<IEnumerable<MatchingRisorse>> MatchingRichiesteByRisIdList(string richId, string cliId,
            int[] richlistRisIdList);
    }
}