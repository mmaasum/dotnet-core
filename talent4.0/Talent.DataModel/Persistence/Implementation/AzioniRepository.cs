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
    public class AzioniRepository : Repository<Azioni>, IAzioniRepository
    {
        public AzioniRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }


        public async Task<IEnumerable<string>> GetAllTipiAzioneData()
        {
            try
            {
                // Fetching data from database.
                var logs = await Context.TipiAzione.OrderBy(c=> c.TipazioneTipoAzione).Select(c=> c.TipazioneTipoAzione).ToListAsync();
                // Returning the retrieved data to business logic layer(bll)
                return logs;
            }
            catch (Exception ex)
            {
                // Throwing Exception to business layer.
                throw;
            }
        }

        public async Task<Azioni> FindByAzioniAsync(Expression<Func<Azioni, bool>> predicate, int noOfSkip)
        {
            try
            {
                // Fetching data from database.
                var logs = await Context.Azioni.Where(predicate).OrderByDescending(x => x.AzioneInsTimestamp)
                                    .Skip(noOfSkip).Take(1).SingleOrDefaultAsync();
                // Returning the retrieved data to business logic layer(bll)
                return logs;
            }
            catch (Exception ex)
            {
                // Throwing Exception to business layer.
                throw;
            }
        }
    }
}
