using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface IRuoliTipiAbilitazioneRepository : IRepository<RuoliTipiAbilitazione>
    {
        Task<string> UpdateRuoliTipiAbilitazione(List<RuoliTipiAbilitazione> roleAuthList, int userAuthChangedConfirmation);
    }
}
