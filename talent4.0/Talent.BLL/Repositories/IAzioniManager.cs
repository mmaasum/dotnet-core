using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.DataModel.Models;

namespace Talent.BLL.Repositories
{
    public interface IAzioniManager
    {
        Task<int> AzioniInsert(AzioniDto azioniDto);

        Task<IEnumerable<string>> GetAllTipiAzione();
        Task<AzioniDto> GetAzioniData(string cliId, string uteId, int noOfSkip);
    }
}
