using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.DataModel.Models;
using Talent.DataModel.DataModels;


namespace Talent.BLL.Repositories
{
    public interface IRoleManager
    {
        Task<IEnumerable<RuoliUtentiDto>> GetAllUserRolesData();
        Task<IEnumerable<RuoliUtentiDto>> GetAllUserRolesDataByClientId(string clientId);
        Task<UserRoleDetails> GetUserRoleDetailsData(string id);
        Task<IEnumerable<RuoliTipiAbilitazioneDto>> GetAllAuthByRoleData(string roleName, string clientId);

        IEnumerable<SPAuthRoleDto> GetAllAuthHavingRoleData(string roleName, string clientId);
        Task<string> UpdateRoleAuthData(List<RuoliTipiAbilitazioneDto> ruoliTipiAbilitazioneDtoList, int userAuthChangedConfirmation);

        Task<int> GetCountUtentiByRuoloData(string roleName, string cliId);
        Task<int> GetCountAuthByRoleData(string roleName, string cliId);
        
        Task<string> InsertRuoloData(RuoliUtentiDto ruoliUtentiDto);
        Task<string> UpdateRuoloData(RuoliUtentiDto ruoliUtentiDto, string roleName);
        Task<string> DeleteRuoloData(string rulo, string cliId);


        //////////////////////////////////////////////////////////

        Task<IEnumerable<object>> GetActiveUserForRoleData(string roleName, string cliId);
        Task<IEnumerable<object>> GetActiverPermissionForRoleData(string roleName, string cliId);

        Task<string> ManageInsertRoleData(ViewRuoloUtentiDto viewRuoloUtentiDto);
        Task<ViewRuoloUtentiDto> GetRoleDetailsData(ViewRuoloUtentiDto viewRuoloUtentiDto);
        Task<string> ManageUpdateRoleData(ViewRuoloUtentiDto viewRuoloUtentiDto);


    }
}
