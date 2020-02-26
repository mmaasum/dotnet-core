using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface ITestValutazioneRepository :IRepository<TestValutazione>
    {
        Task<IEnumerable<TestValutazione>> GetAllTestValutazioneBasedOnCompetenzeAsync(string competenza,
            string clientId);

        Task<IEnumerable<TestValutazione>> GetTestValutazioneDataByTypeDataAsync(int risId, string clientId,
            string type);
    }
}