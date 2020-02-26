using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class ClientiRepository : Repository<Clienti>, IClientiRepository
    {
        public ClientiRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<ParametriGenerali>> FindByGeneralParamListAsync(Expression<Func<ParametriGenerali, bool>> predicate)
        {
            try
            {
                var logs = await (Context.ParametriGenerali.Where(predicate).ToListAsync());
                return logs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
