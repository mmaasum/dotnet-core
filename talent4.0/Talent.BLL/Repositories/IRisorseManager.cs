using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Talent.BLL.DTO;

namespace Talent.BLL.Repositories
{
    public interface IRisorseManager
    {
        Task<IEnumerable<RisorseDto>> GetAllAsync(string clientId, int nextCount);
        Task<RisorseDto> GetDetailAsync(int risId);
        Task<RisorseCvInfo> GetCvInfoAsync(int risId);

        Task<string> LaunchRisorseSPBl(string richId, string cvInviati, string clientId);


        Task<IEnumerable<RisorseDto>> GetRisInfoByRisNomeCognomeAsync(string risnome, string risCognome, string clientId);

        Task<string> InsertAsync(ClaimsPrincipal User, RisorseDto risorseDto);
        Task<string> UpdateAsync(ClaimsPrincipal User, RisorseDto risorseDto);

        Task<string> UploadCvAsync(string clientId, int risId, IFormFile file);
        Task<string> ScanCVAsync(string clientId, int risId);


        Task<IEnumerable<RisInfoStatusDto>> GetRisInfoByRichIdAsync(ClaimsPrincipal User, string richId);
    }
}