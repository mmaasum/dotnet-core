using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TestCompetenzeRepository : Repository<TestCompetenze>, ITestCompetenzeRepository
    {
        public TestCompetenzeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}