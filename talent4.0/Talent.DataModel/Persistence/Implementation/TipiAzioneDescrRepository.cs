using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TipiAzioneDescrRepository : Repository<TipiAzioneDescr>, ITipiAzioneDescrRepository
    {
        public TipiAzioneDescrRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }


    }
}