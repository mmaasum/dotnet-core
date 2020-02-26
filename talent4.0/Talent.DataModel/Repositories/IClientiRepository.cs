using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface IClientiRepository : IRepository<Clienti>
    {
        Task<IEnumerable<ParametriGenerali>> FindByGeneralParamListAsync(Expression<Func<ParametriGenerali, bool>> predicate);
    }
}
