using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface IMasterFilterUtentiRepository :IRepository<TalentFiltriPagineUtenti>
    {
        Task<IEnumerable<MasterFilterCustomDto>> GetFilterListByUtentiAsync(string uteId, string pageName);
    }
}