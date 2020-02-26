using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Talent.BLL.DTO;

namespace Talent.BLL.Repositories
{
    public interface IContattiManager
    {
        Task<IEnumerable<TipiContattoDto>> GetAllTipiContattoDataByCliIdAsync(string contCliId);

        Task<ContattiDto> FindByContattiAsync(int contId);
        Task<int> InsertAsync(ContattiDto contattiDto);
        Task<int> UpdateAsync(ContattiDto contattiDto);


        Task<IEnumerable<ContattiOptimizedDto>> GetFindByAllContattiByContAzSedeIdAsync(ClaimsPrincipal User, int contAzSedeId);
        Task<IEnumerable<ContattiOptimizedDto>> FindAllContattiByContAzIdAsync(ClaimsPrincipal User, int azId);
    }
}