using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TalentFiltriPagineCampiRepository : Repository<TalentFiltriPagineCampi>, ITalentFiltriPagineCampiRepository
    {
        public TalentFiltriPagineCampiRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<TalentFiltriPagineCampi>> GetFieldsDescrByPageDal(string pageName, string langName, string fieldType)
        {
            if (fieldType == "filter")
            {
                var data = await (
                          from masterFilterField in Context.TalentFiltriPagineCampi
                          join masterFilterFieldDetails in Context.TalentFiltriPagineCampiDescr
                          on masterFilterField.TntfilFiltropagcampoCodice equals masterFilterFieldDetails.TntfilFiltropagcampodescrFiltropagcampoCodice
                          into masterFilterFieldDetailsN
                          from masterFilterFieldDetails in masterFilterFieldDetailsN.DefaultIfEmpty()
                          where masterFilterField.TntfilFiltropagcampoAttivo == "S"
                             && masterFilterField.TntfilFiltropagcampoPagina == pageName
                             && masterFilterFieldDetails.TntfilFiltropagcampodescrLingua == langName
                          select new TalentFiltriPagineCampi
                          {
                              TntfilFiltropagcampoCodice = masterFilterField.TntfilFiltropagcampoCodice,
                              TntfilFiltropagcampoPagina = masterFilterFieldDetails.TntfilFiltropagcampodescrDescrizione,
                              TntfilFiltropagcampoCampoTabellaDb = masterFilterField.TntfilFiltropagcampoCampoTabellaDb,
                              TntfilFiltropagcampoTipo = masterFilterField.TntfilFiltropagcampoTipo,
                              TntfilFiltropagcampoAttivo = masterFilterField.TntfilFiltropagcampoAttivo,
                              TntfilFiltropagcampoSoloFiltro = masterFilterField.TntfilFiltropagcampoSoloFiltro,
                              TntfilFiltropagcampoFiltroOrdineVis = masterFilterField.TntfilFiltropagcampoFiltroOrdineVis,
                              TntfilFiltropagcampoSortOrdineVis = masterFilterField.TntfilFiltropagcampoSortOrdineVis
                          }
                      ).ToListAsync();

                // Returning the retrieved data to business logic layer(bll)
                return data;
            }
            else
            {
                var data = await (
                          from masterFilterField in Context.TalentFiltriPagineCampi
                          join masterFilterFieldDetails in Context.TalentFiltriPagineCampiDescr
                          on masterFilterField.TntfilFiltropagcampoCodice equals masterFilterFieldDetails.TntfilFiltropagcampodescrFiltropagcampoCodice
                          into masterFilterFieldDetailsN
                          from masterFilterFieldDetails in masterFilterFieldDetailsN.DefaultIfEmpty()
                          where masterFilterField.TntfilFiltropagcampoAttivo == "S"
                             && masterFilterField.TntfilFiltropagcampoPagina == pageName
                             && masterFilterField.TntfilFiltropagcampoSoloFiltro == "N"
                              && masterFilterFieldDetails.TntfilFiltropagcampodescrLingua == langName
                          select new TalentFiltriPagineCampi
                          {
                              TntfilFiltropagcampoCodice = masterFilterField.TntfilFiltropagcampoCodice,
                              TntfilFiltropagcampoPagina = masterFilterFieldDetails.TntfilFiltropagcampodescrDescrizione,
                              TntfilFiltropagcampoCampoTabellaDb = masterFilterField.TntfilFiltropagcampoCampoTabellaDb,
                              TntfilFiltropagcampoTipo = masterFilterField.TntfilFiltropagcampoTipo,
                              TntfilFiltropagcampoAttivo = masterFilterField.TntfilFiltropagcampoAttivo,
                              TntfilFiltropagcampoSoloFiltro = masterFilterField.TntfilFiltropagcampoSoloFiltro,
                              TntfilFiltropagcampoFiltroOrdineVis = masterFilterField.TntfilFiltropagcampoFiltroOrdineVis,
                              TntfilFiltropagcampoSortOrdineVis = masterFilterField.TntfilFiltropagcampoSortOrdineVis
                          }
                      ).ToListAsync();

                // Returning the retrieved data to business logic layer(bll)
                return data;
            }
        }
    }
}