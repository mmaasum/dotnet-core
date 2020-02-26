using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TipiAzioneCategoriaDescrRepository 
        : Repository<TipiAzioneCategoriaDescr>, ITipiAzioneCategoriaDescrRepository
    {
        public TipiAzioneCategoriaDescrRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }


    }
}