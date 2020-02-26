using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface IGridFiltriMasterRepository : IRepository<GridFiltriMaster>
    {
        Task<IEnumerable<GridFiltriMaster>> FindAndOrderByAccessLevelDescendingThenByNameAscendingAsync(
            Expression<Func<GridFiltriMaster, bool>> predicate);
    }
}