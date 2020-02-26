using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class SoftskillsProfiliRepository : Repository<SoftskillsProfili>, ISoftskillsProfiliRepository
    {
        public SoftskillsProfiliRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }


    }
}