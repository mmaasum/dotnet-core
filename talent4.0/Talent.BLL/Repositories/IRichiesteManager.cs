using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL.Repositories
{
    public interface IRichiesteManager
    {
        Task<IEnumerable<RichiesteDto>> GetAllAsync();
        Task<IEnumerable<RichiesteDto>> FindAllByCliIdAsync(string cliId, int counter);
        Task<RichiesteDetailDto> FindByRichIdAsync(string richid);
        Task<string> InsertAsync(ClaimsPrincipal User, RichiesteDto richiesteDto);
        Task<string> UpdateAsync(ClaimsPrincipal User, RichiesteDto richiesteDto);
        Task<string> DeleteAsync(string richid);
        Task<string> CloneAsync(string richid);

        Task<IEnumerable<MatchingRisorse>> MatchingRichiesteAsync(string richid, string cliId, int status);


        Task<IEnumerable<MatchingRisorse>> GetMatchingRichiesteListByRisIdAsync(string richid, string cliId, int[] richlistRisIdList);


        Task<IEnumerable<CittaDto>> GetAllCittaByCliIdAsync(string clientid);
        Task<IEnumerable<CompetenzaDto>> GetAllCompetenzaByCliIdAsync(string clientid);


        Task<int> CountFindByRichlistRisorseAsync(string richId, int risId, string cliId);
        Task<int> InsertRichlistRisorseAsync(RichiesteListaRisorseDto richiesteListaRisorseDto, ClaimsPrincipal User);
        Task<int> UpdateRichlistRisorseAsync(RichiesteListaRisorseDto richiesteListaRisorseDto);

        Task<IEnumerable<StatiRichiesteListaRisorseDescr>> GetStatiRichListRisDescrAsync(string langName);


        Task<int> CountFindByTalentRichlistRisorseAsync(string richId, int risId, ClaimsPrincipal User);
        Task<int> InsertTalentRichlistRisorseAsync(RichiesteListaRisorseDto richiesteListaRisorseDto, ClaimsPrincipal User);
        Task<int> UpdateTalentRichlistRisorseAsync(RichiesteListaRisorseDto richiesteListaRisorseDto, ClaimsPrincipal User);

    }
}