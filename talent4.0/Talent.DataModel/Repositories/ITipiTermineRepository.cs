using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.Common.Enums;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface ITipiTermineRepository : IRepository<TipiTermine>
    {
        Task<IEnumerable<TipiTermineDescr>> GetAllTerminiTypeWithExtraAsync(SupportedLanguage language, string ClientId);
    }
}