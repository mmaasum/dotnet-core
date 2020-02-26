
using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface ITerminiRepository : IRepository<Termini>
    {
        Task<IEnumerable<string>> GetAllKeywordLanguageAsync();

        Task<IEnumerable<LastAnalysisDto>> GetLastAnalysisInfoDal(string cliId, string uteId);
    }
}