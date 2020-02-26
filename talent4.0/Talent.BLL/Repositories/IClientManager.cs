using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Talent.BLL.DTO;

namespace Talent.BLL.Repositories
{
    public interface IClientManager
    {
        Task<IEnumerable<ClientDto>> GetAllClientDataAsync();
        Task<IEnumerable<ClientDto>> GetAllClientDataByUteIdAsync(string uteId);
        Task<ClientDto> GetClientDataByClientId(string cliId, string secretKey);
    }
}
