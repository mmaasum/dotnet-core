using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.Common.Enums;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL.Repositories
{
    public interface IMultiLanguageManager
    {
        Task<IEnumerable<TalentMenu>> GetAllMenuAsync(SupportedLanguage language);

        Task<IEnumerable<UtentiMenuDmo>> GetMenuOfUserAsync(SupportedLanguage language, string uteId, string cliId);
    }
}