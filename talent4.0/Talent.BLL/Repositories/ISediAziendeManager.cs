using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.BLL.DTO;

namespace Talent.BLL.Repositories
{
    public interface ISediAziendeManager
    {
        Task<IEnumerable<SediAziendeDto>> GetAllAsync(string clientId);
        Task<int> InsertAsync(SediAziendeDto sediAziendeDto);
        Task<int> UpdateAsync(SediAziendeDto sediAziendeDto);
        Task<IEnumerable<SediAziendeDto>> GetAllByAzSedeAzIdAsync(int azSedeAzId);

        Task<SediAziendeDto> FindBySedeIdAsync(int sedeId);
    }
}