using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Talent.DataModel.Persistence.Implementation
{
    public class MasterFilterUtentiRepository : Repository<TalentFiltriPagineUtenti>, IMasterFilterUtentiRepository
    {
        public MasterFilterUtentiRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }


        public async Task<IEnumerable<MasterFilterCustomDto>> GetFilterListByUtentiAsync(string uteId, string pageName)
        {
            var data = await (
                from masterFilter in Context.TalentFiltriPagine
                join masterFilterUtenti in Context.MasterFilterUtentiDmo
                    on masterFilter.TntfilFiltropagId equals masterFilterUtenti.TntfilFiltropaguteFiltropagId
                    into masterFilterUtentiN
                from masterFilterUtenti in masterFilterUtentiN.DefaultIfEmpty()
                where masterFilterUtenti.TntfilFiltropaguteUteId == uteId
                      && masterFilter.TntfilFiltropagPaginaCodice == pageName

                select new MasterFilterCustomDto
                {
                    TntfilFiltropagUteFiltroPagId = masterFilter.TntfilFiltropagId,
                    TntfilFiltropagUteId = masterFilterUtenti.TntfilFiltropaguteId,
                    TntfilFiltropagNomeCorto = masterFilter.TntfilFiltropagNomeCorto,
                    TntfilFiltropagUteOrdine = masterFilterUtenti.TntfilFiltropaguteOrdine,
                    TntfilFiltropagUteUteId = (masterFilterUtenti.TntfilFiltropaguteUteId ?? "").ToString(),
                    TntfilFiltropagUteButtonId = masterFilterUtenti.TntfilFiltropaguteBottone,
                    TntfilFiltropagUteButtonLabel = (masterFilterUtenti.TntfilFiltropaguteBottoneLabel ?? "").ToString(),
                    TntfilFiltropagUteDefault = masterFilterUtenti.TntfilFiltropaguteDefault
                }
            ).OrderBy(c => c.TntfilFiltropagUteButtonId).ToListAsync();

            // Returning the retrieved data to business logic layer(bll)
            return data;
        }
    }
}