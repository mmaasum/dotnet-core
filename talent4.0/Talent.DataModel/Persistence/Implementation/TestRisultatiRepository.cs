using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TestRisultatiRepository : Repository<TestRisultati>, ITestRisultatiRepository
    {
        public TestRisultatiRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}