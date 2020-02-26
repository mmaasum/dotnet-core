using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talent.BLL.DTO;

namespace Talent.BLL.Repositories
{
    public interface IUtilityManager
    {
        Task<Object> ReturnErrorObj(Exception ex, ClaimsPrincipal User, string desc);
        void GenerateLogOperazioniDto(ClaimsPrincipal User, string desc, string details);

        AzioniDto GetAzioniDtoObject(ClaimsPrincipal User, string azioniTipo, string azioniDesc);
        string GetTranslatedData(string langName, string fileName, string queryToken);
    }
}
