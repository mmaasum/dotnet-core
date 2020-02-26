using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Talent.DataModel.DataModels;

namespace Talent.DataModel.Persistence.Implementation
{
    public class RichiesteRepository : Repository<Richieste>, IRichiesteRepository
    {
        public RichiesteRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<StatiRichiesteListaRisorseDescr>> GetStatiRichListRisDescrAsync(string langName)
        {
            try
            {
                // Fetching data from database following order by inserted time descending.
                var data = await  (
                    from srlr in Context.StatiRichiesteListaRisorse
                    join srlrd in Context.StatiRichiesteListaRisorseDescr
                        on srlr.StarichlistStato equals srlrd.StarichlistdescrStato into srlrdN
                    from srlrd in srlrdN.DefaultIfEmpty()
                    where srlrd.StarichlistdescrLingua == langName &&
                          srlr.StarichlistWf >= 2

                    select new StatiRichiesteListaRisorseDescr
                    {
                        StarichlistdescrDescrizione = srlrd.StarichlistdescrDescrizione
                    }
                ).ToListAsync();

                // Returning the retrieved data to business logic layer(bll)
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        ///     Insert new richieste record into richieste table by fetching from bll
        /// </summary>
        /// <param name="richieste"></param>
        /// <returns></returns>
        public async Task<string> InsertRichieste(Richieste richieste)
        {
            try
            {
                var lastRIchId = Context.Richieste
                    .OrderByDescending(a => a.RichId)
                    .Select(c => c.RichId)
                    .First()
                    .ToString();

                richieste.RichId = GenerateFormattedRichId(lastRIchId, richieste);
                // Inserting in the database.
                Context.Set<Richieste>().Add(richieste);
                await Context.SaveChangesAsync();
                // Returning the recently inserted richieste id to business logic layer(bll)
                return richieste.RichId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Throwing Exception to business logic layer.
                throw;
            }

        }


        /// <summary>
        ///     To get the list custom Matching Risorse object following several condition.
        /// </summary>
        /// <param name="richid">provided rich_id selected by the user.</param>
        /// <param name="cliId">client id of the selected richieste</param>
        /// <param name="richlistRisIdList">provided ris_id list</param>
        /// <returns></returns>
        public Task<IEnumerable<MatchingRisorse>> MatchingRichieste(string richId, string cliId)
        {
            try
            {
                // Retrieving the ris_id list based on provided rich_id and client_id
                //var richlistRisIdList = Context.RichiesteListaRisorse.Where(c => c.RichlistRichId == richid && c.RichlistCliId == cliId).Select(c => c.RichlistRisId).ToArray();

                // Retrieving the ris_id list based on provided rich_id and client_id
                //      but only which are not assigned/rejected.
                var nonActionedRichlistRisIdList
                    = (
                        from rls in Context.RichiesteListaRisorse
                        join trls in Context.TalentRichiesteListaRisorse
                            on rls.RichlistRisId equals trls.TrichlistRisId
                            into ps
                        from p in ps.DefaultIfEmpty()
                        where rls.RichlistRichId == richId && rls.RichlistCliId == cliId
                        //&& p.TrichlistRichId == null
                        select rls.RichlistRisId
                    ).ToArray();


                // Passing the retrieved ris_id list along with the rich_id and client_id 
                var matchingRisorsesList = MatchingRichiesteByRisIdList(richId, cliId, nonActionedRichlistRisIdList);
                if (matchingRisorsesList == null)
                {
                    return null;
                }
                return matchingRisorsesList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Throwing Exception to business logic layer.
                throw;
            }
        }

        public async Task<IEnumerable<MatchingRisorse>> MatchingRichiesteByRisIdList(string richId, string cliId, int[] richlistRisIdList)
        {
            try
            {
                // Setting the default status.
                var status = "NO status found";
                // Declaring an empty list of custom Matching Risorse object
                List<MatchingRisorse> matchingRisorsesList = new List<MatchingRisorse>();

                // foreach loop in the provided ris_id list
                foreach (var _richlistRisId in richlistRisIdList)
                {
                    // Retrieving the risorse object based on the ris_id
                    var risInfo = await Context.Risorse.Where(c => c.RisId == _richlistRisId).FirstOrDefaultAsync();
                    if (risInfo != null)
                    {
                        // Counting the record from azione table following the matched with
                        // retrevied rid_id = azione_ris_id and some other conditiones.
                        var data1 = Context.Azioni.Where(c => c.AzioneRisId == risInfo.RisId && c.AzioneTipo == "invio_cv_a_cliente" && c.AzioneCliId == cliId).Distinct().Count();
                        if (data1 == 0)
                        {
                            // Counting the record of risorse following some criteria conditions.
                            // Here the time differece is being calculated in minutes , that's why 1400 is multiplied with the retreived day difference.
                            var data2 = Context.Risorse.Where(c => c.RisDataColloquio != null && c.RisId == risInfo.RisId && Convert.ToDateTime(c.RisDataColloquio).Subtract(DateTime.Now).Days * 1440 < 0).Distinct().Count();
                            status = "COLLOQUIATE";
                            if (data2 == 0)
                            {
                                // Counting the record of risorse matched with a set of conditions.
                                var data3 = Context.Risorse.Where(c => c.RisDataColloquio != null && c.RisId == risInfo.RisId).Count();
                                if (data3 != 0)
                                {
                                    // Setting the status
                                    status = "NON COLLOQUIATE";
                                }

                            }
                        }
                        else
                        {
                            status = "INVIATO CV";
                        }

                        // Creating an empty object of Matching Risorse
                        MatchingRisorse matchingRisorse = new MatchingRisorse();
                        // Setting the ris_id as the retrived ris_id
                        matchingRisorse.RisId = risInfo.RisId;
                        // Setting the candidates full name based on the retreived risorse info.
                        matchingRisorse.Candidates = risInfo.RisNome + "," + risInfo.RisCognome;
                        // Setting the skills based on the concatanation of risorse info.
                        matchingRisorse.Skills = risInfo.RisCompetenza1 + "," + risInfo.RisCompetenza2 + "," + risInfo.RisCompetenza3;
                        matchingRisorse.Status = status;



                        // Declaring the grade and assigning empty string by default.
                        var grade = "";
                        try
                        {
                            // trying to fetech the grade following some matching criteria if exists.
                            grade = Context.RichiesteListaRisorse.Where(c =>
                                       c.RichlistRichId == richId &&
                                       c.RichlistCliId == cliId &&
                                       c.RichlistRisId == risInfo.RisId).
                                       Select(c => c.RichlistVoto).First().ToString();
                        }
                        catch { }
                        matchingRisorse.Grade = grade;

                        //var actionTaken = "";
                        try
                        {
                            // trying to fetech the grade following some matching criteria if exists.
                            var actionTaken
                                = (
                                    from rls in Context.RichiesteListaRisorse
                                    join trls in Context.TalentRichiesteListaRisorse
                                    on rls.RichlistRisId equals trls.TrichlistRisId
                                    where rls.RichlistRichId == richId && rls.RichlistCliId == cliId
                                        && risInfo.RisId == trls.TrichlistRisId
                                    select trls.TrichlistStato
                                ).ToArray();

                            // Setting the grade
                            matchingRisorse.ActionTaken = Int32.Parse(actionTaken[0]);
                        }
                        catch
                        {
                            matchingRisorse.ActionTaken = 0;
                        }

                        // Adding the matching resorce object to the earlier declared list.
                        matchingRisorsesList.Add(matchingRisorse);
                    }
                }

                // Checking whether any data in the list.
                if (matchingRisorsesList == null)
                {
                    // if no data added in the list then returning a null value.
                    return null;
                }

                // if there is any data in the list then the list is returning back to the business layer 
                // following by the descending order by grade.
                return matchingRisorsesList.OrderByDescending(c => c.Grade).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Throwing Exception to business logic layer.
                throw;
            }
        }

        private string GenerateFormattedRichId(string lastRichId, Richieste richieste)
        {
            List<string> richIdTextArray = lastRichId.Split('-').ToList<string>();
            var lastRichIdSl = Int32.Parse(richIdTextArray[1]);

            //List<string> cloneRichIdTextArray = richieste.RichId.Split('-').ToList<string>();
            //var competenza = cloneRichIdTextArray[2];

            var competenza = "";
            try
            {
                competenza = Context.Competenze.Where
                    (c => c.Competenza.Equals(richieste.RichCompPrincipale)
                          && c.CompCliId.Equals(richieste.RichCliId))
                    .Select(c => c.CompRichSigla).FirstOrDefault().ToString();
            }
            catch { }

            var citta = "";
            try
            {
                citta = Context.Citta.Where
                    (c => c.Citta1.Equals(richieste.RichCitta)
                          && c.CittaCliId.Equals(richieste.RichCliId))
                    .Select(c => c.CittaTarga).FirstOrDefault().ToString();
            }
            catch { }



            string richId = DateTime.Now.Year.ToString() + "-" + (lastRichIdSl + 1).ToString("D4")
                            + "-" + competenza + "-" + citta
                            + "-" + richieste.RichAzId + "-"
                            + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            return richId;
        }
    }
}