using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace Talent.DataModel.Persistence.Implementation
{
    public class SediAziendeRepository : Repository<SediAziende>, ISediAziendeRepository
    {
        public SediAziendeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<ViewSediAziende>> GetAllSediAziendeDal(string clientId)
        {
            try
            {
                // Fetching data from database by Joining
                var result = await (
                                from s in Context.SediAziende
                                join a in Context.Aziende
                                on s.AzsedeAzId equals a.AzId
                                where s.AzsedeCliId == clientId
                                // Creating new object to hold the join table data.
                                select new ViewSediAziende
                                {
                                    AzRagSociale = a.AzRagSociale,
                                    AzsedeId = s.AzsedeId,
                                    AzsedeAzId = s.AzsedeAzId,
                                    AzsedeAttiva = s.AzsedeAttiva,
                                    AzsedeDescr = s.AzsedeDescr,
                                    AzsedeIndirizzo = s.AzsedeIndirizzo,
                                    AzsedeCitta = s.AzsedeCitta,
                                    AzsedeCap = s.AzsedeCap,
                                    AzsedeLocationLat = s.AzsedeLocationLat,
                                    AzsedeLocationLong = s.AzsedeLocationLong,
                                    AzsedeIndic = s.AzsedeIndic,
                                    AzsedeIndicColloquio = s.AzsedeIndicColloquio,
                                    AzsedeInsTimestamp = s.AzsedeInsTimestamp,
                                    AzsedeInsUteId = s.AzsedeInsUteId,
                                    AzsedeModTimestamp = s.AzsedeModTimestamp,
                                    AzsedeModUteId = s.AzsedeModUteId,
                                    AzsedeCliId = s.AzsedeCliId,
                                }
                            ).ToListAsync();
                // Returning the retrieved data to business logic layer(bll).
                return result;
            }
            catch (Exception ex)
            {
                // Throwing Exception to business logic layer.
                throw;
            }
        }
    }
}