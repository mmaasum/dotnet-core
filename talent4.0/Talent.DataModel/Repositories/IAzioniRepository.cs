using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface IAzioniRepository : IRepository<Azioni>
    {
        Task<Azioni> FindByAzioniAsync(Expression<Func<Azioni, bool>> predicate, int noOfSkip);

        Task<IEnumerable<string>> GetAllTipiAzioneData();
    }
}
