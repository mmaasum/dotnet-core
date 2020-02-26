using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class RuoloUtentiRepository : Repository<RuoliUtenti>, IRuoloUtentiRepository
    {
        public RuoloUtentiRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public IEnumerable<SPAuthRole> GetAllAuthHavingRole(string roleName, string clientId)
        {
            try
            {
                // Retrieving all auth list along with the rolename, it is assigned to.
                var logs = Context.SPAuthRoles.
                                    FromSql($"Exec sp_auth_role {roleName}, {clientId}");
                // Returning the retrieved data to business logic layer(bll)
                return logs;
            }
            catch (Exception ex)
            {
                // Throwing Exception to business logic layer.
                throw;
            }
        }

        public async Task<UserRoleDetails> GetUserRoleDetails(string id)
        {
            return null;
            //try
            //{
            //    // Custom class UserRoleDetails is made to get the Join query Object.
            //    // Getting the related details of a role using join.
            //    var logs = await
            //            (from a in Context.TipiAbilitazioneDescr
            //             from b in Context.TipiAbilitazione
            //             from c in Context.RuoliTipiAbilitazione
            //             where c.RuoltipabRuolo == id &&
            //                     c.RuoltipabUteabProcedura == b.TipoabilitProcedura &&
            //                     a.TabildescrProcedura == b.TipoabilitProcedura &&
            //                     a.TabildescrLingua == "ENG"
            //             select new UserRoleDetails
            //             {
            //                 TabildescrDescrizione = a.TabildescrDescrizione,
            //                 TabildescrProcedura = "false"
            //             }).FirstOrDefaultAsync();

            //    // Returning the retrieved data to business logic layer(bll)
            //    return logs;
            //}
            //catch (Exception ex)
            //{
            //    // Throwing Exception to business logic layer.
            //    throw;
            //}
        }

        public async Task<IEnumerable<string>> GetAllRoleLanguageAsync()
        {
            var languages = await Context.RuoliUtentiDescr
                .Where(a => !String.IsNullOrEmpty(a.RuolodescrLingua))
                .Select(a => a.RuolodescrLingua)
                .Distinct()
                .ToListAsync();

            return languages;
        }
    }
}
