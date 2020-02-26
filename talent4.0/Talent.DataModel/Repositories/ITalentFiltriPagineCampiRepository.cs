using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface ITalentFiltriPagineCampiRepository : IRepository<TalentFiltriPagineCampi>
    {
        Task<IEnumerable<TalentFiltriPagineCampi>>
            GetFieldsDescrByPageDal(string pageName, string langName, string fieldType);
    }
}