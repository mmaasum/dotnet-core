using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class GridFiltriMasterRepository : Repository<GridFiltriMaster> , IGridFiltriMasterRepository
    {
        public GridFiltriMasterRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<GridFiltriMaster>> FindAndOrderByAccessLevelDescendingThenByNameAscendingAsync(Expression<Func<GridFiltriMaster, bool>> predicate)
        {
            //return await Context.GridFiltriMaster
            //    .Where(predicate)
            //    .OrderByDescending(x => x.GridfilmaAccessLevel)
            //    .ThenBy(x => x.GridfilmaNomeOrder)
            //    .ToListAsync();

            return null;
        }
    }
}