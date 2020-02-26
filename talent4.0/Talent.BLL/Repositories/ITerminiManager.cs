using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.DataModel.DataModels;

namespace Talent.BLL.Repositories
{
    public interface ITerminiManager
    {
        Task<IEnumerable<TerminiDto>> GetAllAsync();
        Task<IEnumerable<TerminiDto>> FindListAsync(string clientid, int counter);
        Task<IEnumerable<TipiTermineDto>> FindByTipiTermineListAsync(string cliId);

        Task<TerminiDto> FindAsync(string termini, string cliId);

        Task<TerminiDto> FindNextTerminiAsync(TerminiDto terminiDto);

        Task<string> InsertAsync(TerminiDto terminiDto);
        Task<string> UpdateAsync(TerminiDto terminiDto);
        Task<string> DeleteAsync(string termini);


        Task<IEnumerable<TerminiDto>> GetAllTerminiBySinonimoData(string[] sinonimoArray, string termini, string cliId);

        Task<IEnumerable<LastAnalysisDto>> GetLastAnalysisInfoData(string cliId, string uteId);
    }
}