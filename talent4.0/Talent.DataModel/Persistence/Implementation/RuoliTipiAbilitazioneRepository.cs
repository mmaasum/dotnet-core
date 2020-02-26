using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class RuoliTipiAbilitazioneRepository : Repository<RuoliTipiAbilitazione>, IRuoliTipiAbilitazioneRepository
    {
        public RuoliTipiAbilitazioneRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        /// <summary>
        ///     Update the synced auth related to a role and all the user-auth who are having that role. (if confirmation is yes)
        /// </summary>
        /// <purpose>
        ///     To change the defined auth list for a role.
        ///     To change the defined auth list for each user who are having this role. ( It happens only when userAuthChangedConfirmation is 1(YES)).
        /// </purpose>
        /// <param name="roleAuthList">AuthList having the role </param>
        /// <param name="userAuthChangedConfirmation">Defines either the user auth will changed according the role-auth changing value</param>
        /// <returns>Activity Message</returns>
        public async Task<string> UpdateRuoliTipiAbilitazione(List<RuoliTipiAbilitazione> roleAuthList, int userAuthChangedConfirmation)
        {
            return null;
            //try
            //{
            //    var roleName = roleAuthList[0].RuoltipabRuolo;
            //    var clientId = roleAuthList[0].RuoltipabCliId;

            //    var removableRoleAuthList = await Context.RuoliTipiAbilitazione
            //                             .Where(c => c.RuoltipabRuolo == roleName
            //                                    && c.RuoltipabCliId == clientId)
            //                             .ToListAsync();

            //    if (userAuthChangedConfirmation != 0)
            //    {

            //        // To get the list of auth which were exists earlier but removed in this changes.
            //        var removedAuthList = removableRoleAuthList.Select(c => c.RuoltipabUteabProcedura)
            //                                        .Except(roleAuthList.Select(c => c.RuoltipabUteabProcedura))
            //                                        .ToList();
            //        // To get the list of auth which are newly added in this changes.
            //        var newlyAddedAuthList = roleAuthList.Select(c => c.RuoltipabUteabProcedura)
            //                                        .Except(removableRoleAuthList.Select(c => c.RuoltipabUteabProcedura))
            //                                        .ToList();
            //        // To get the list of auth which are remain same at earlier and in this changes.
            //        var nonChangedAuthList = removableRoleAuthList.Select(c => c.RuoltipabUteabProcedura)
            //                                        .Intersect(roleAuthList.Select(c => c.RuoltipabUteabProcedura))
            //                                        .ToList();


            //        // User list which are having the changed role.
            //        var updatableUtentiList = await Context.Utenti.Where(c => c.UteRuolo == roleName && c.UteCliId == clientId).ToListAsync();

            //        // Loop to change the user-auth of every user who are having the changed role.
            //        foreach (var _updatableUtentiList in updatableUtentiList)
            //        {
            //            // Retrieving the Ute Id from the list.
            //            var updatableUteId = _updatableUtentiList.UteId;

            //            // Loop to bring the necessary changed to the user-auth of specific Utenti
            //            foreach (var _nonChangedAuthName in nonChangedAuthList)
            //            {
            //                var recordCount = await Context.UtentiAbilitazioni
            //                                  .Where(c => c.UteabUteId == updatableUteId
            //                                            && c.UteabProcedura == _nonChangedAuthName
            //                                            && c.UteabCliId == clientId)
            //                                  .CountAsync();
            //                if (recordCount == 0)
            //                {
            //                    UtentiAbilitazioni utentiAbilitazioni = returnUtentiAbilitazioniObject(updatableUteId, _nonChangedAuthName, "S", clientId);
            //                    Context.Set<UtentiAbilitazioni>().Add(utentiAbilitazioni);
            //                }
            //                else
            //                {
            //                    var updatableRow = await Context.UtentiAbilitazioni
            //                                       .Where(c => c.UteabUteId == updatableUteId && c.UteabProcedura == _nonChangedAuthName
            //                                                && c.UteabCliId == clientId)
            //                                       .FirstOrDefaultAsync();
            //                    updatableRow.UteabAbilitato = "S";
            //                    Context.Entry(updatableRow).State = EntityState.Modified;
            //                }
            //            }

            //            // Loop to bring the necessary changed to the user-auth of specific Utenti
            //            foreach (var _newlyAddedAuthList in newlyAddedAuthList)
            //            {
            //                var recordCount = await Context.UtentiAbilitazioni
            //                                  .Where(c => c.UteabUteId == updatableUteId
            //                                            && c.UteabProcedura == _newlyAddedAuthList
            //                                            && c.UteabCliId == clientId)
            //                                   .CountAsync();
            //                if (recordCount == 0)
            //                {
            //                    UtentiAbilitazioni utentiAbilitazioni =
            //                                       returnUtentiAbilitazioniObject(updatableUteId, _newlyAddedAuthList, "S", clientId);
            //                    Context.Set<UtentiAbilitazioni>().Add(utentiAbilitazioni);
            //                }
            //                else
            //                {
            //                    var updatableRow = await Context.UtentiAbilitazioni
            //                                       .Where(c => c.UteabUteId == updatableUteId && c.UteabProcedura == _newlyAddedAuthList
            //                                                && c.UteabCliId == clientId)
            //                                       .FirstOrDefaultAsync();
            //                    updatableRow.UteabAbilitato = "S";
            //                    Context.Entry(updatableRow).State = EntityState.Modified;
            //                }
            //            }

            //            // Loop to bring the necessary changed to the user-auth of specific Utenti
            //            foreach (var _removedAuthList in removedAuthList)
            //            {
            //                var recordCount = await Context.UtentiAbilitazioni
            //                                  .Where(c => c.UteabUteId == updatableUteId
            //                                            && c.UteabProcedura == _removedAuthList
            //                                            && c.UteabCliId == clientId)
            //                                  .CountAsync();
            //                if (recordCount != 0)
            //                {
            //                    var updatableRow = await Context.UtentiAbilitazioni
            //                                        .Where(c => c.UteabUteId == updatableUteId && c.UteabProcedura == _removedAuthList
            //                                                 && c.UteabCliId == clientId)
            //                                        .FirstOrDefaultAsync();
            //                    updatableRow.UteabAbilitato = "N";
            //                    Context.Entry(updatableRow).State = EntityState.Modified;
            //                }
            //            }
            //        }

            //    }

            //    // Delete all the existing auth of role 
            //    foreach (var _removableRoleAuth in removableRoleAuthList)
            //    {
            //        Context.Set<RuoliTipiAbilitazione>().Remove(_removableRoleAuth);
            //    }

            //    // Adding the changed auth to the role.
            //    foreach (var _roleAuth in roleAuthList)
            //    {
            //        Context.Set<RuoliTipiAbilitazione>().Add(_roleAuth);
            //    }
            //    await Context.SaveChangesAsync();
            //    return "Ok";
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    // Throwing Exception to business logic layer.
            //    throw;
            //}
        }


        /// <summary>
        ///     Creating a utenti_abilitazioni object based on the provided attribute value.
        /// </summary>
        /// <param name="uteId"></param>
        /// <param name="authName"></param>
        /// <param name="abilitato"></param>
        /// <param name="clientId"></param>
        /// <returns>Utenti Abilitazioni Object</returns>
        private UtentiAbilitazioni returnUtentiAbilitazioniObject(string uteId, string authName, string abilitato, string clientId)
        {
            // Creating new object
            UtentiAbilitazioni utentiAbilitazioni = new UtentiAbilitazioni();
            // Assigning the defined value.
            utentiAbilitazioni.UteabUteId = uteId;
            utentiAbilitazioni.UteabProcedura = authName;
            utentiAbilitazioni.UteabAbilitato = abilitato;
            utentiAbilitazioni.UteabInsTimestamp = DateTime.Now;
            utentiAbilitazioni.UteabInsUteId = "alessio.ciardini";
            utentiAbilitazioni.UteabModTimestamp = DateTime.Now; ;
            utentiAbilitazioni.UteabModUteId = "alessio.ciardini";
            utentiAbilitazioni.UteabCliId = clientId;
            // Returning the object to business logic layer(bll)
            return utentiAbilitazioni;
        }
    }
}
