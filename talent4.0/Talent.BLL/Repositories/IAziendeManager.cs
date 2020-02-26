using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.BLL.DTO;

namespace Talent.BLL.Repositories
{
    public interface IAziendeManager
    {
        Task<IEnumerable<AziendeDto>> GetAllAziendeData();
        Task<IEnumerable<AziendeDto>> GetAziendeListByCliIdAsync(string azCliId, int counter);
        Task<AziendeDto> FindByAziendeAsync(int azid, string azCliId);
        Task<IEnumerable<OptimizedAziendeDto>> GetOptimizedAziendeListByCliIdAsync(string azCliId);
        Task<int> InsertAziende(AziendeDto aziendeDto);
        Task<int> UpdateAziende(AziendeDto aziendeDto);
        Task<IEnumerable<SediAziendeDto>> AziendeDetails(int azId, string cliId);

        Task<IEnumerable<TipiAziendaDto>> GetAllTipiAziendaData(string cliId);


        Task<AziendeDto> FindBySiglaRichiestaData(int azid, string azCliId, string azSiglaRichiesta);
    }
}