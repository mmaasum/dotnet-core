using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class RichiesteListaRisorseRepository : Repository<RichiesteListaRisorse>, IRichiesteListaRisorseRepository
    {
        public RichiesteListaRisorseRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}