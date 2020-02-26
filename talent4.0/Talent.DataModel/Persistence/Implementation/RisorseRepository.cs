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
    public class RisorseRepository : Repository<Risorse>, IRisorseRepository
    {
        public RisorseRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public Task<IEnumerable<MatchingRisorse>> GetRisInfoByRichIdAsync(string richId, string cliId)
        {
            try
            {
                var richlistRisIdList = (from ris in Context.Risorse
                        join rich in (from o in Context.RichiesteListaRisorse
                                where o.RichlistRichId == richId
                                select o)
                            on ris.RisId equals rich.RichlistRisId
                        select ris.RisId
                    ).ToArray();


                var iResult = MatchingRichiesteByRisIdList(richId, cliId, richlistRisIdList);

                // Returning the result to business logic layer.
                return iResult;
            }
            catch (Exception ex)
            {
                // Throwing Exception to business logic layer.
                throw;
            }
        }

        public async Task<string> LaunchRisorseSP(string richId, string cvInviati, string clientId)
        {
            try
            {

                var query = "Exec sp_ricerca_richiesta_query "
                            + ReturnData(richId) + " , "
                            + ReturnData(cvInviati) + " , "
                            + " 'S', 'A' , 'filippo.giunti' , 100 " + " , "
                            + ReturnData(clientId) + " , "
                            + " 'S' ";

                var logs = await Context.SPLaunchRisorse.FromSql(query).ToListAsync();
                // Retrieving all auth list along with the rolename, it is assigned to.
                //var logs = Context.SPLaunchRisorse.FromSql($"Exec sp_ricerca_richiesta_query {richId},{cvInviati},'S','A','filippo.giunti',100,{clientId},'S'");
                // Returning the retrieved data to business logic layer(bll)

                //return logs[0].result;
                return "ok";
            }
            catch (Exception ex)
            {
                // Throwing Exception to business logic layer.
                throw;
            }
        }

        // This is duplicate function from richieste repository
        public async Task<IEnumerable<MatchingRisorse>> MatchingRichiesteByRisIdList(string richid, string cliId, int[] richlistRisIdList)
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
                        matchingRisorse.Candidates = risInfo.RisNome;
                        // Setting the skills based on the concatanation of risorse info.
                        //matchingRisorse.Skills = risInfo.RisCompetenza1 + "," + risInfo.RisCompetenza2 + "," + risInfo.RisCompetenza3;
                        matchingRisorse.Skills = risInfo.RisCognome;
                        matchingRisorse.Status = status;



                        //// Declaring the grade and assigning empty string by default.
                        //var grade = "";
                        //try
                        //{
                        //    // trying to fetech the grade following some matching criteria if exists.
                        //    grade = Context.RichiesteListaRisorse.Where(c =>
                        //               c.RichlistRichId == richid &&
                        //               c.RichlistCliId == cliId &&
                        //               c.RichlistRisId == risInfo.RisId).
                        //               Select(c => c.RichlistVoto).First().ToString();
                        //}
                        //catch { }
                        //matchingRisorse.Grade = grade;

                        ////var actionTaken = "";
                        //try
                        //{
                        //    // trying to fetech the grade following some matching criteria if exists.
                        //    var actionTaken
                        //        = (
                        //            from rls in Context.RichiesteListaRisorse
                        //            join trls in Context.TalentRichiesteListaRisorse
                        //            on rls.RichlistRisId equals trls.TrichlistRisId
                        //            where rls.RichlistRichId == richid && rls.RichlistCliId == cliId
                        //                && risInfo.RisId == trls.TrichlistRisId
                        //            select trls.TrichlistStato
                        //        ).ToArray();

                        //    // Setting the grade
                        //    matchingRisorse.ActionTaken = Int32.Parse(actionTaken[0]);
                        //}
                        //catch
                        //{
                        //    matchingRisorse.ActionTaken = 0;
                        //}

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


        private string ReturnData(string data)
        {
            if (data == "null" || data == null)
            {
                return "null";
            }
            else
            {
                return "'" + data + "'";
            }
        }
    }
}