using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Talent.DataModel.Models;

namespace Talent.BLL.Repositories
{
    public interface ISubscriberManager
    {
        Task<IEnumerable<Aziende>> GetAziendeByClientIdAsync(string cliId);
        Task<int> GetTokenValidationDataAsync(string username, string password);

        Task<string> TextFromFileAsync(IFormFile file);
    }
}