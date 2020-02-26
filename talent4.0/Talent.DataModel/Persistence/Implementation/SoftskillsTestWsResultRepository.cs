using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class SoftskillsTestWsResultRepository : Repository<SoftskillsTestWsResult>, ISoftskillsTestWsResultRepository
    {
        public SoftskillsTestWsResultRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}