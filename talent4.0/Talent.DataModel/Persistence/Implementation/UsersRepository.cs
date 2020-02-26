using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talent.Common.Enums;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class UsersRepository : Repository<Utenti>, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public int CountFindByUtenti(Expression<Func<Utenti, bool>> predicate)
        {
            try
            {
                // Fetching data from database.
                var logs = Context.Utenti.Count(predicate);
                // Returning the retrieved data to business logic layer(bll)
                return logs;
            }
            catch (Exception ex)
            {
                // Throwing Exception to business logic layer.
                throw;
            }
        }

        public async Task<TalentUserProfiles> FindByUserProfileAsync(Expression<Func<TalentUserProfiles, bool>> predicate)
        {
            try
            {
                // Fetching data from database.
                var logs = await Context.TalentUserProfiles.Where(predicate).FirstOrDefaultAsync();
                // Returning the retrieved data to business logic layer(bll)
                return logs;
            }
            catch (Exception ex)
            {
                // Throwing Exception to business layer.
                throw;
            }
        }

        public async Task<IEnumerable<UtentiMenuDmo>> GetMenuDataOfUserAsync(SupportedLanguage language, string uteId, string cliId)
        {
            // Here only those menus are being retreived which
            // prefixes are 'Talent', status are active and having the provided language name, ute id and client id
            var log = await (from t1 in Context.UtentiAbilitazioni
                       join t2 in Context.TalentPagine
                        on t1.UteabProcedura equals t2.TntfilUteabProcedura
                       join t3 in Context.TalentMenu
                        on t2.TntfilPaginaCodice equals t3.TntmenuTntfilPaginaCodice
                       join t4 in Context.TalentMenuDescr
                        on t3.TntmenuId equals t4.TntmenudescrTntmenuId

                       where t2.TntfilUteabProcedura.StartsWith("Talent") &&
                               t1.UteabUteId == uteId &&
                               t1.UteabCliId == cliId &&
                               t1.UteabAbilitato == "S" &&
                               t3.TntmenuAttivo == true &&
                               t4.TntmenudescrLingua == language.ToString() &&
                               t4.TntmenudescrTntmenuCliId == cliId

                       select new UtentiMenuDmo
                       {
                           TntmenuId = t3.TntmenuId,
                           TntmenuNome = t4.TntmenudescrDescrizione,
                           TntmenuLivello = t3.TntmenuLivello,
                           TntmenuRouterlink = t2.TntfilPaginaUrl,
                           TntmenuParentid = t3.TntmenuParentid,
                           TntmenuLingua = t4.TntmenudescrLingua,
                           TntmenuHasubmenu = t3.TntmenuHasubmenu,
                           TntmenuIsdefault = t3.TntmenuIsdefault,
                           TntmenuAttivo = t3.TntmenuAttivo,
                           TntmenuOrdinamento = t3.TntmenuOrdinamento,
                           TntmenuUteabProcedura = t1.UteabProcedura,
                       }).Distinct().ToListAsync();

            ////// Retrieving the parent menu list, which will belongs the others sub-menus.

            var result = await (from x in Context.TalentMenu
                          join y in Context.TalentMenuDescr
                          on new { X1 = x.TntmenuId, X2 = x.TntmenuCliId } equals new { X1 = y.TntmenudescrTntmenuId, X2 = y.TntmenudescrTntmenuCliId }
                          where y.TntmenudescrLingua == language.ToString() &&
                             x.TntmenuParentid == null &&
                             x.TntmenuCliId == cliId

                          select new UtentiMenuDmo
                          {
                              TntmenuId = x.TntmenuId,
                              TntmenuNome = y.TntmenudescrDescrizione,
                          }).ToListAsync();
            //var parentmenulist = Context.TalentMenu.Where(c => c.TntmenuLingua == langName && c.TntmenuParentid == null).ToList();
            ////// Integrating the parent menu list and clild/sub-menu list into single table.
            var data = result.Union(log).ToList();

            return data;
        }

        public async Task<IEnumerable<V_AuthUtenti>> GetAllAuthHavingUtenti(string uteId, string uteCliId)
        {
            return null;
            //try
            //{
            //    // rertrieving the auth data by joining with utenti
            //    List<V_AuthUtenti> logs = await (
            //                                from t1 in Context.TipiAbilitazione
            //                                join t2 in
            //                                (
            //                                    from ua in Context.UtentiAbilitazioni
            //                                    where ua.UteabUteId == uteId && ua.UteabCliId == uteCliId && ua.UteabAbilitato == "S"
            //                                    select new { ua.UteabProcedura, ua.UteabUteId }
            //                                )
            //                            on t1.TipoabilitProcedura equals t2.UteabProcedura into authUtenti
            //                                                                from subT2 in authUtenti.DefaultIfEmpty()
            //                                                                    //where t1.TipoabilitProcedura.StartsWith("Talent")
            //                                                                select new V_AuthUtenti { TipoabilitProcedura = t1.TipoabilitProcedura, UteabUteId = subT2.UteabUteId }
            //                                                              ).ToListAsync();

            //    // Returning the retrieved data to business logic layer(bll).
            //    return logs;
            //}
            //catch (Exception ex)
            //{
            //    // Throwing Exception to business logic layer.
            //    throw;
            //}
        }

        public async Task<IEnumerable<ClientOptimizedDmo>> GetClientListByUteIdAsync(string uteId)
        {
            try
            {
                // Fetching data from database followed by checking the active status and order by modified time descending
                var result = await (
                                from a in Context.Utenti
                                join b in Context.Clienti
                                on a.UteCliId equals b.CliId
                                where a.UteId == uteId
                                select new ClientOptimizedDmo
                                {
                                    CliId = a.UteCliId,
                                    CliNome = b.CliNome
                                }
                             ).ToListAsync();
                // Returning the retrieved data to business logic layer(bll)
                return result;
            }
            catch (Exception ex)
            {
                // Throwing Exception to business logic layer.
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetUtentiAbilitazioneListAsync(string uteId, string uteCliId)
        {
            try
            {
                // Declaring an emtry string list.
                List<string> logs = new List<string>();
                // Assigning the retreived data into the list by fetching from db.
                logs = await Context.UtentiAbilitazioni
                                    .Where(c => c.UteabUteId == uteId 
                                            && c.UteabAbilitato == "S"
                                            && c.UteabCliId == uteCliId 
                                            && c.UteabProcedura.StartsWith("talent"))
                                    .OrderByDescending(c => c.UteabProcedura)
                                    .Select(c => c.UteabProcedura)
                                    .ToListAsync();

                // Returning the retrieved data to business logic layer(bll)
                return logs;
            }
            catch (Exception ex)
            {
                // Throwing Exception to business logic layer.
                throw;
            }
        }
    }
}
