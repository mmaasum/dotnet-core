using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class StatiTermineDescrRepository : Repository<StatiTermineDescr>, IStatiTermineDescrRepository
    {
        public StatiTermineDescrRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}