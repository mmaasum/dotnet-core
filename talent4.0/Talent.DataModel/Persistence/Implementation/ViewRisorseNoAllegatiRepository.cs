using Talent.DataModel.DataModels;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class ViewRisorseNoAllegatiRepository 
        : Repository<ViewRisorseNoAllegati>, IViewRisorseNoAllegatiRepository
    {
        public ViewRisorseNoAllegatiRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}