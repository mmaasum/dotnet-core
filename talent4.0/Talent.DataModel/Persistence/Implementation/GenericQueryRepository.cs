using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class GenericQueryRepository : IGenericQueryRepository
    {
        public ApplicationDbContext Context;
        public GenericQueryRepository(ApplicationDbContext context)
        {
            Context = context;
        }



        /// <summary>
        ///     Fetching search data from database 
        ///     based on the bll provided raw query and return data to bll.
        /// </summary>
        /// <param name="query">raw query statement</param>
        /// <returns>table data</returns>
        public async Task<IEnumerable<object>> FindDataFromRawQueryAsync(string query, string tableName)
        {
            IEnumerable<Object> data = null;

            try
            {
                switch (tableName)
                {
                    case "azioni":
                        return await Context.ViewAzioni.FromSql(query).ToListAsync();
                    case "log_operazioni":
                        return await Context.LogOperazioni.FromSql(query).ToListAsync();
                    case "visualizza_lista_operazioni":
                        return await Context.LogOperazioni.FromSql(query).ToListAsync();
                    case "utenti":
                        return await Context.Utenti.FromSql(query).ToListAsync();
                    case "sedi_aziende":
                        return await Context.ViewSediAziende.FromSql(query).ToListAsync();
                    case "v_risorse_no_allegati":
                        return await Context.ViewRisorseNoAllegati.FromSql(query).ToListAsync();
                    case "contatti":
                        return await Context.ViewContatti.FromSql(query).ToListAsync();
                    case "termini":
                        return await Context.ViewTermini.FromSql(query).ToListAsync();
                    case "gestione_termini":
                        return await Context.ViewTermini.FromSql(query).ToListAsync();
                    case "richieste":
                        return await Context.ViewRichieste.FromSql(query).ToListAsync();
                    case "aziende":
                        return await Context.Aziende.FromSql(query).ToListAsync();
                    case "aziende_clienti_finali":
                        return await Context.ViewAziendeClientiFinali.FromSql(query).ToListAsync();
                    case "ruoli_utenti":
                        return await Context.ViewRuoloUtenti.FromSql(query).ToListAsync();
                    case "gestione_ruoli":
                        return await Context.ViewRuoloUtenti.FromSql(query).ToListAsync();
                    case "row_count":
                        return await Context.TableRecordCount.FromSql(query).ToListAsync();
                    case "generic_search":
                        return await Context.GenericSearch.FromSql(query).ToListAsync();
                    case "content_first_letter":
                        return await Context.DynamicButton.FromSql(query).ToListAsync();
                    case "talent_griglie_utenti":
                        return await Context.TalentGriglieUtenti.FromSql(query).ToListAsync();
                    case "active_user_by_role":
                        return await Context.CustomDataClass.FromSql(query).ToListAsync();
                    default:
                        return data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            
        }

        public async Task<IEnumerable<SPSchedulazioneResiduoCv>> LaunchSpSchedulazioneResiduoCvDal(int schedulazioneId)
        {
            // Retrieving all auth list along with the rolename, it is assigned to.
            var logs = await Context.SPSchedulazioneResiduoCv
                .FromSql($"Exec Sp_schedulazione_residuo_cv {schedulazioneId}")
                .ToListAsync();

            // Returning the retrieved data to business logic layer(bll)
            return logs;
        }

        public async Task<int> LaunchSpSchedulazioneStartDal(int schedule_id)
        {
            // Retrieving all auth list along with the rolename, it is assigned to.
            var logs = await Context.StaticResult
                .FromSql($"Exec sp_schedulazione_start {schedule_id} Select 1 as result")
                .ToListAsync();

            // Returning the retrieved data to business logic layer(bll)
            return logs[0].result;
        }

        public async Task<int> LaunchSpSchedulazioneIncrementaCvScaricatiDal(int schedule_id)
        {
            // Retrieving all auth list along with the rolename, it is assigned to.
            var logs = await Context.StaticResult
                .FromSql($"Exec Sp_schedulazione_incrementa_cv_scaricati {schedule_id} Select 1 as result")
                .ToListAsync();

            // Returning the retrieved data to business logic layer(bll)
            return logs[0].result;
        }

        public async Task<int> LaunchSpSchedulazioneStopDal(int schedule_id, int new_cvs, int updated_cvs, int total_cvs, string exit_code)
        {
            // Retrieving all auth list along with the rolename, it is assigned to.
            var logs = await Context.StaticResult
                .FromSql($"Exec sp_schedulazione_stop {schedule_id},{new_cvs},{updated_cvs},{total_cvs},{exit_code} Select 1 as result")
                .ToListAsync();

            // Returning the retrieved data to business logic layer(bll)
            return logs[0].result;
        }

        public async Task<IEnumerable<SpItpFindResource>> LaunchSpItpFindResourceAsync
                                        (
                                            string cli_id, string name = null,
                                            string surname = null, string email = null,
                                            string phone = null, string date_of_birth = null,
                                            string cities = null, string keyword_skill1 = null,
                                            string indebug = null
                                        )
        {
            string query = "Exec Sp_itp_find_resource "
                           + ReturnData(name) + " , "
                           + ReturnData(surname) + " , "
                           + ReturnData(email) + " , "
                           + ReturnData(phone) + " , ";

            try
            {
                DateTime iDatetime = Convert.ToDateTime(date_of_birth);
                query += ReturnData(date_of_birth) + " , ";
            }
            catch
            {
                query += ReturnData(date_of_birth) + " , ";
            }

            query += ReturnData(cities) + " , "
                                        + ReturnData(keyword_skill1) + " , "
                                        + ReturnData(cli_id) + " , ";


            try
            {
                var iIndBug = int.Parse(indebug);
                query += iIndBug;
            }
            catch
            {
                query += ReturnData(indebug);
            }

            return await Context.SpItpFindResource.FromSql(query).ToListAsync();
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