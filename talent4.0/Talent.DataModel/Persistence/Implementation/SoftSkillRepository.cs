using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;
using System.Linq;

namespace Talent.DataModel.Persistence.Implementation
{
    public class SoftSkillRepository : Repository<SoftskillsCompetenzeDescr>, ISoftSkillRepository
    {
        public SoftSkillRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<ViewSoftSkillWsResult>> GetSavedWsResultByRisIdAndLanguageAsync(int risId, string langName)
        {
            try
            {
                var result = await (from sstwr in Context.SoftskillsTestWsResult
                              join ssp in Context.SoftskillsProfili
                                  on sstwr.SsktestresProfilo equals ssp.SskprofIdPlay
                              where ssp.SskprofLingua == langName && sstwr.SsktestresRisId == risId
                              select new ViewSoftSkillWsResult
                              {
                                  SsktestresPlayField1 = sstwr.SsktestresPlayField1,
                                  SsktestresPlayField2 = sstwr.SsktestresPlayField2,
                                  SsktestresPlayField3 = sstwr.SsktestresPlayField3,
                                  SsktestresPlayField4 = sstwr.SsktestresPlayField4,
                                  SskprofProfilo = ssp.SskprofProfilo,
                                  SskprofIdPlay = ssp.SskprofIdPlay,
                                  SskprofDescrizione = ssp.SskprofDescrizione
                              }).ToListAsync();
                
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SPSchedulazioneGetSchedulazioni>> GetScheduleListFromSPAsync(string codiceProcesso)
        {
            try
            {
                var logs = await Context.SPSchedulazioneGetSchedulazionis
                        .FromSql($"Exec sp_schedulazione_get_schedulazioni {codiceProcesso}")
                        .ToListAsync();

                return logs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
