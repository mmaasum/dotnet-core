using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TalentGriglieCampiRepository :Repository<TalentGriglieCampi>, ITalentGriglieCampiRepository
    {
        public TalentGriglieCampiRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<TalentGriglieCampi>> GetGridFieldsDescrByPageDal(string gridName, string langName)
        {
            var data = await (
                from masterGridField in Context.TalentGriglieCampi
                join masterGridFieldDescr in Context.TalentGriglieCampiDescr
                    on masterGridField.TntgcNomeCampo equals masterGridFieldDescr.TntgcNomeCampo
                    into masterGridFieldDescrN
                from masterGridFieldDescr in masterGridFieldDescrN.DefaultIfEmpty()
                where masterGridField.TntgcTntgridNomeGriglia == gridName
                      && masterGridFieldDescr.TntgcLingua == langName
                      && masterGridField.TntgcAttivo == "S"
                select new TalentGriglieCampi
                {
                    TntgcNomeCampo = masterGridField.TntgcNomeCampo,
                    TntgcTntgridNomeGriglia = masterGridField.TntgcTntgridNomeGriglia,
                    TntgcDescrizione = masterGridFieldDescr.TntgcDescrizione,
                    TntgcNomeCampoDb = masterGridField.TntgcNomeCampoDb
                }
            ).ToListAsync();

            // Returning the retrieved data to business logic layer(bll)
            return data;
        }
    }
}