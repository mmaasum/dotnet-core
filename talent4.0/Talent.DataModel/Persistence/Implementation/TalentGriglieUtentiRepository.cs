using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TalentGriglieUtentiRepository : Repository<TalentGriglieUtenti>, ITalentGriglieUtentiRepository
    {
        public TalentGriglieUtentiRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

    }
}