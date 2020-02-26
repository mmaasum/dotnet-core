using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.BLL.Repositories;
using Talent.Common.Enums;
using Talent.DataModel;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class MultiLanguageManager : IMultiLanguageManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public MultiLanguageManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TalentMenu>> GetAllMenuAsync(SupportedLanguage language)
        {
            // Fetching data from dal.
            //var data = await wrapper.MultiLanguageRepo.GetAllMenu(x => x.TntmenuLingua.Equals(langName));
            // Returning the retrieved data to controller end
            return null;
        }

        public async Task<IEnumerable<UtentiMenuDmo>> GetMenuOfUserAsync(SupportedLanguage language, string uteId, string cliId)
        {
            // Fetching data from dal.
            var data = await _unitOfWork.Users.GetMenuDataOfUserAsync(language, uteId, cliId);
            // Returning the retrieved data to controller end
            return data;
        }
    }
}