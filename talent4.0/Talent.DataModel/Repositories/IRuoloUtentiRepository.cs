using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface IRuoloUtentiRepository : IRepository<RuoliUtenti>
    {
        IEnumerable<SPAuthRole> GetAllAuthHavingRole(string roleName, string clientId);
        Task<UserRoleDetails> GetUserRoleDetails(string id);

        Task<IEnumerable<string>> GetAllRoleLanguageAsync();
    }
}
