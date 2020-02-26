using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface ITalentGriglieCampiRepository : IRepository<TalentGriglieCampi>
    {
        Task<IEnumerable<TalentGriglieCampi>> GetGridFieldsDescrByPageDal(string gridName, string langName);
    }
}