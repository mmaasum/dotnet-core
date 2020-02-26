using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.DataModel.Models;

namespace Talent.BLL.Repositories
{
    public interface IUsersManager
    {
        Task<IEnumerable<UtentiDto>> GetAllActiveUsers();
        Task<IEnumerable<UtentiDto>> GetAllUtentiDataByCliId(string cliId);
        Task<UtentiDto> GetUtentiDetail(string cliId, string uteId);

        Task<string> Insert(UtentiDto utentiDto, List<UtentiAbilitazioniDto> userAuthDtoList);
        Task<string> Update(UtentiDto utentiDto, List<UtentiAbilitazioniDto> userAuthDtoList);
        Task<string> Delete(string uteId, string uteCliId);

        Task<IEnumerable<V_AuthUtenti>> GetAllAuthHavingUtentiData(string uteId, string uteCliId);
        Task<IEnumerable<string>> UserAuthList(string uteId, string uteCliId);

        

        Task<IEnumerable<ClientDto>> GetClientListByUteIdData(string uteId);
        Task<IEnumerable<UtentiOptimizedDto>> GetOptimizedUtentiListData(string cliId, string userStatus);

        Task<IEnumerable<UtentiOptimizedDto>> GetAllUtentiByRole(string clientId, string role);

        Task<bool> HasSamePassForSameUsername(string userId, string password);
        bool IsValidPass(string password);


        Task<TalentUserProfileDto> FindUserProfileData(string uteId, string cliId);
    }
}
