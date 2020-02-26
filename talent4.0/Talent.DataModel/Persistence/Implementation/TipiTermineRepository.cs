using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Talent.Common.Enums;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TipiTermineRepository : Repository<TipiTermine>, ITipiTermineRepository
    {
        public TipiTermineRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<TipiTermineDescr>> GetAllTerminiTypeWithExtraAsync(SupportedLanguage language, string ClientId)
        {
            var types = await Context.TipiTermineDescr
                .Where(a => a.TipterdescrLingua.Equals(language.ToString()) && a.TipterdescrTipterCliId.Equals(ClientId))
                .OrderBy(a => a.TipterdescrTipoTermine)
                .ToListAsync();

            return types;
        }
    }
}