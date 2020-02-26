using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talent.Common.Enums;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.DataModel.Repositories
{
    public interface IUsersRepository : IRepository<Utenti>
    {
        Task<IEnumerable<string>> GetUtentiAbilitazioneListAsync(string uteId, string uteCliId);

        Task<IEnumerable<V_AuthUtenti>> GetAllAuthHavingUtenti(string uteId, string uteCliId);

        Task<IEnumerable<ClientOptimizedDmo>> GetClientListByUteIdAsync(string uteId);

        int CountFindByUtenti(Expression<Func<Utenti, bool>> predicate);


        Task<TalentUserProfiles> FindByUserProfileAsync(Expression<Func<TalentUserProfiles, bool>> predicate);




        Task<IEnumerable<UtentiMenuDmo>> GetMenuDataOfUserAsync(SupportedLanguage language, string uteId, string cliId);

    }
}
