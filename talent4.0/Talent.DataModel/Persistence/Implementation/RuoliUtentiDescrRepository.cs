using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class RuoliUtentiDescrRepository : Repository<RuoliUtentiDescr>, IRuoliUtentiDescrRepository
    {
        public RuoliUtentiDescrRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }


    }
}