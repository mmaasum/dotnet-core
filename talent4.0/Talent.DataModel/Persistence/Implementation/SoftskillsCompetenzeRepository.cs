using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class SoftskillsCompetenzeRepository : Repository<SoftskillsCompetenze>, ISoftskillsCompetenzeRepository
    {
        public SoftskillsCompetenzeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }


    }
}