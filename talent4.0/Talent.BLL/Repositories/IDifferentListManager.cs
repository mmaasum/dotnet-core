using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.Common.Enums;

namespace Talent.BLL.Repositories
{
    public interface IDifferentListManager
    {
        // Azioni related
        Task<IEnumerable<KeyValuePairDto>> GetAllAzioniTypeCategoryDescriptionAsync(SupportedLanguage language);
        Task<IEnumerable<KeyValuePairDto>> GetAllAzioniTypeDescriptionAsync(SupportedLanguage language);


        // Termini(keyword) related
        Task<IEnumerable<KeyValuePairDto>> GetAllTerminiStateAsync(SupportedLanguage language);
        Task<IEnumerable<KeyValuePairDto>> GetAllTerminiLanguageAsync();
        Task<IEnumerable<KeyValuePairDto>> GetAllTerminiTypeAsync(SupportedLanguage language, string ClientId);


        // Ruolo(Role) related
        Task<IEnumerable<KeyValuePairDto>> GetAllRuoloCodesAsync(string ClientId);
        Task<IEnumerable<KeyValuePairDto>> GetAllRuoloNameAsync(SupportedLanguage language, string ClientId);
        Task<IEnumerable<KeyValuePairDto>> GetAllRuoloLanguageAsync();
        
    }
}