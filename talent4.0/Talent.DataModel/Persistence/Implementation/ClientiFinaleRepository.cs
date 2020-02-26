using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Talent.DataModel.Persistence.Implementation
{
    public class ClientiFinaleRepository :Repository<AziendeClientiFinali> , IClientiFinaleRepository
    {
        public ClientiFinaleRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<ViewAziendeClientiFinali>> GetAllAziendeClientiFinaleAsync(int clifinAzId)
        {
            // Implementing the try-catch block.
            try
            {
                // Fetching data from database.
                // Joining the aziende client finale with aziende to retrieve the az_social reg value.
                var result = await (from acf in Context.AziendeClientiFinali
                              join az in Context.Aziende
                              on acf.ClifinAzId equals az.AzId
                              where acf.ClifinAzId == clifinAzId
                              // Declaring new object of View aziende client finale object. 
                              // Here the object is required as retrieved data are coming from joining number of tables.
                              select new ViewAziendeClientiFinali
                              {
                                  // Assingning retrieved data to this object.
                                  ClifinId = acf.ClifinId,
                                  ClifinAzId = acf.ClifinAzId,
                                  ClifinLuogoLavoro = acf.ClifinLuogoLavoro,
                                  ClifinIndirizzo = acf.ClifinIndirizzo,
                                  ClifinLocationLat = acf.ClifinLocationLat,
                                  ClifinLocationLong = acf.ClifinLocationLong,
                                  ClifinInsTimestamp = acf.ClifinInsTimestamp,
                                  ClifinInsUteId = acf.ClifinInsUteId,
                                  ClifinModTimestamp = acf.ClifinModTimestamp,
                                  ClifinModUteId = acf.ClifinModUteId,
                                  ClifinRaggMezziPubblici = acf.ClifinRaggMezziPubblici,
                                  ClifinNomeClienteFinale = acf.ClifinNomeClienteFinale,
                                  ClifinCliId = acf.ClifinCliId,
                                  AzRagSociale = az.AzRagSociale
                              }).ToListAsync();
                // Returning the result to business logic layer.
                return result;
            }
            catch (Exception ex)
            {
                // throwing an exception if there's any.
                throw;
            }
        }
    }
}