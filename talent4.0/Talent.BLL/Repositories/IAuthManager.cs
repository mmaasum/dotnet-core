using System.Threading.Tasks;
using Talent.BLL.DTO;

namespace Talent.BLL.Repositories
{
    public interface IAuthManager
    {
        Task<bool> Has5ConsecutiveFailedAttemptsWithin5Miniutes(string userId);
        Task<LoginUserResponseDto> ValidateUserAsync(UserLoginDto userLoginDto);
        Task LockUser(string userId);
    }
}
