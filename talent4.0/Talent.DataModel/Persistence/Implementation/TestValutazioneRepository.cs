using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TestValutazioneRepository : Repository<TestValutazione>, ITestValutazioneRepository
    {
        public TestValutazioneRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<TestValutazione>> GetAllTestValutazioneBasedOnCompetenzeAsync(string competenza, string clientId)
        {
            var result = await (from tv in Context.TestValutazione
                                join tc in (from o in Context.TestCompetenze
                                            where o.TscompCompetenza == competenza && o.TscompCliId == clientId
                                            select o)
                                    on tv.TsvalTitolo equals tc.TscompTest
                                select new TestValutazione
                                {
                                    TsvalTitolo = tv.TsvalTitolo,
                                    TsvalLink = tv.TsvalLink
                                }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<TestValutazione>> GetTestValutazioneDataByTypeDataAsync(int risId, string clientId, string type)
        {
            try
            {
                IEnumerable<TestValutazione> data = null;
                var risorse = await Context.Risorse.Where(c => c.RisId == risId).FirstOrDefaultAsync();
                switch (type)
                {
                    case "optional":
                        var xResult = await (
                                        from tc in Context.TestCompetenze
                                        join tv in Context.TestValutazione
                                        on tc.TscompTest equals tv.TsvalTitolo
                                        where tv.TsvalAttivo == "S" && tc.TscompCliId == clientId
                                                && (tc.TscompCompetenza == risorse.RisCompetenza2 || tc.TscompCompetenza == risorse.RisCompetenza3)
                                        select new TestValutazione
                                        {
                                            TsvalTitolo = tv.TsvalTitolo,
                                            TsvalLink = tv.TsvalLink
                                        }
                                      ).ToListAsync();

                        var yResult = await (
                                        from tv in Context.TestValutazione
                                        where tv.TsvalAttivo == "S" && tv.TsvalCliId == clientId
                                        select new TestValutazione
                                        {
                                            TsvalTitolo = tv.TsvalTitolo,
                                            TsvalLink = tv.TsvalLink
                                        }
                                     ).ToListAsync();

                        var zResult = await (
                                        from tc in Context.TestCompetenze
                                        join tv in Context.TestValutazione
                                        on tc.TscompTest equals tv.TsvalTitolo
                                        where tc.TscompCliId == clientId && tc.TscompCompetenza == risorse.RisCompetenza1
                                        select new TestValutazione
                                        {
                                            TsvalTitolo = tv.TsvalTitolo,
                                            TsvalLink = tv.TsvalLink
                                        }
                                     ).ToListAsync();

                        data = xResult.Union(yResult.Except(zResult)).ToList();
                        return data;
                    case "mandatory":
                        data = await (
                                   from tc in Context.TestCompetenze
                                   join tv in Context.TestValutazione
                                   on tc.TscompTest equals tv.TsvalTitolo
                                   where tv.TsvalAttivo == "S" && tc.TscompCliId == clientId && tc.TscompCompetenza == risorse.RisCompetenza1
                                   select new TestValutazione
                                   {
                                       TsvalTitolo = tv.TsvalTitolo,
                                       TsvalLink = tv.TsvalLink
                                   }
                                ).ToListAsync();
                        return data;

                    default:
                        return data;

                }
            }
            catch (Exception ex)
            {
                // Throwing Exception to business logic layer.
                throw;
            }
        }
    }
}