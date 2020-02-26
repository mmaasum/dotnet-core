using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TalentFiltriPagineRepository : Repository<TalentFiltriPagine>, ITalentFiltriPagineRepository
    {
        public TalentFiltriPagineRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

    }
}