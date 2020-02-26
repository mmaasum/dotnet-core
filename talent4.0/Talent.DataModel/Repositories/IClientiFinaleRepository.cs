using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface IClientiFinaleRepository : IRepository<AziendeClientiFinali>
    {
        Task<IEnumerable<ViewAziendeClientiFinali>> GetAllAziendeClientiFinaleAsync(int clifinAzId);
    }
}