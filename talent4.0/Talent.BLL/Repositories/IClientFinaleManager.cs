using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Talent.BLL.DTO;

namespace Talent.BLL.Repositories
{
    public interface IClientFinaleManager
    {
        Task<IEnumerable<AziendeClientiFinaleDto>> GetAllData(int clifinAzId);
        Task<int> InsertData(AziendeClientiFinaleDto aziendeClientiFinaleDto);
        Task<int> UpdateData(AziendeClientiFinaleDto aziendeClientiFinaleDto);

        Task<AziendeClientiFinaleDto> FindByClifinIdData(int clifinId);

        Task<IEnumerable<AziendeClientiFinaleOptimizedDto>> GetFindAllByOptimizedAziendeClienteFinale(ClaimsPrincipal User, int azId);
    }
}