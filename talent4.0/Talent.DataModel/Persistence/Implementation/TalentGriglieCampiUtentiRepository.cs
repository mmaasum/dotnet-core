using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TalentGriglieCampiUtentiRepository : Repository<TalentGriglieCampiUtenti>, ITalentGriglieCampiUtentiRepository
    {
        public TalentGriglieCampiUtentiRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }


        public async Task<IEnumerable<TalentGriglieCampiUtenti>> GetJoinTalentGridFieldsUserListAsync(string uteId, string cliId, string gridName, string langName)
        {
            var data = await (
                          from masterGridUserField in Context.TalentGriglieCampiUtenti
                          join masterGridField in Context.TalentGriglieCampi
                          on masterGridUserField.TntgcuTntgcNomeCampo equals masterGridField.TntgcNomeCampo
                          //join masterGridFieldDescr in Context.TalentGriglieCampiDescr
                          //on masterGridField.TntgcNomeCampo equals masterGridFieldDescr.TntgcNomeCampo
                          where masterGridUserField.TntgcuUteId == uteId
                              && masterGridUserField.TntgcuCliId == cliId
                              && masterGridField.TntgcTntgridNomeGriglia == gridName
                              && masterGridField.TntgcAttivo == "S"
                          //&& masterGridFieldDescr.TntgcLingua == langName

                          select new TalentGriglieCampiUtenti
                          {
                              TntgcuId = masterGridUserField.TntgcuId,
                              TntgcuTntgcNomeCampo = masterGridUserField.TntgcuTntgcNomeCampo,
                              TntgcuTntfontNomeFont = masterGridUserField.TntgcuTntfontNomeFont,
                              TntgcuTntszFontDimensione = masterGridUserField.TntgcuTntszFontDimensione,

                              TntgcuOrdineVis = masterGridUserField.TntgcuOrdineVis,
                              TntgcuAllineamento = masterGridUserField.TntgcuAllineamento,
                              TntgcuMinSize = masterGridUserField.TntgcuMinSize,
                              TntgcuMaxSize = masterGridUserField.TntgcuMaxSize,
                              TntgcuAutoSize = masterGridUserField.TntgcuAutoSize,
                              //TntgcuFieldLabelDescription = masterGridFieldDescr.TntgcDescrizione
                          }
                        ).ToListAsync();

            // Fetching data from database.
            //var logs = await Context.TalentGriglieCampiUtenti
            //                        .Where(predicate)
            //                        .ToListAsync();
            // Returning the retrieved data to business logic layer(bll)
            return data;
        }

        public async Task<string> GetSpecificFieldDescription(string fieldName, string langName)
        {
            var data = await (
                from masterGridUserField in Context.TalentGriglieCampiUtenti
                join masterGridFieldDescr in Context.TalentGriglieCampiDescr
                    on masterGridUserField.TntgcuTntgcNomeCampo equals masterGridFieldDescr.TntgcNomeCampo
                    into masterGridFieldDescrN
                from masterGridFieldDescr in masterGridFieldDescrN.DefaultIfEmpty()
                where masterGridFieldDescr.TntgcNomeCampo == fieldName
                      && masterGridFieldDescr.TntgcLingua == langName
                select masterGridFieldDescr.TntgcDescrizione
            ).ToArrayAsync();

            if(data.Count() == 0)
            {
                return "Description Not Found In DB";
            }
            else
            {
                return data[0];
            }

            // Returning the retrieved data to business logic layer(bll)
           
        }
    }
}