using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.DataModel.Models;

namespace Talent.BLL.Repositories
{
    public interface IOperazioniManager
    {
        Task<IEnumerable<LogOperazioniDto>> GetAllLogOperazioniData();
        Task<IEnumerable<LogOperazioniDto>> GetAllLogOperazioniDataByCliId(string cliId, int counter);
        Task<int> LogOperazioniInsert(LogOperazioniDto logOperazioniDto);
    }
}
