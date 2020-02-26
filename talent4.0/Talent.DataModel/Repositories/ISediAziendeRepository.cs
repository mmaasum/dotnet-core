using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface ISediAziendeRepository : IRepository<SediAziende>
    {
        Task<IEnumerable<ViewSediAziende>> GetAllSediAziendeDal(string clientId);
    }
}