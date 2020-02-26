using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface ITalentGriglieCampiUtentiRepository : IRepository<TalentGriglieCampiUtenti>
    {
        Task<IEnumerable<TalentGriglieCampiUtenti>> GetJoinTalentGridFieldsUserListAsync(string uteId, string cliId,
            string gridName, string langName);

        Task<string> GetSpecificFieldDescription(string fieldName, string langName);
    }
}