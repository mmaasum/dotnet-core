using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.BLL.Utilities;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.DataModel;

namespace Talent.BLL.Manager
{
    public class AuthManager : IAuthManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CommonBLL _cm = new CommonBLL();

        public AuthManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<bool> Has5ConsecutiveFailedAttemptsWithin5Miniutes(string userId)
        {
            int failedAtemptsCount = await FailedAttemptsWithinFiveMinutes(userId);
            return failedAtemptsCount > 5 ? true : false;
        }

        public async Task LockUser(string userId)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(a => a.UteId.Equals(userId));
            if (user != null)
            {
                // Setting the status as inactive.
                user.UteAttivo = "N";
                int iUteId = await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<LoginUserResponseDto> ValidateUserAsync(UserLoginDto userLoginDto)
        {
            // Declaring a new dto object.
            var dto = new LoginUserResponseDto();
            // Retreiving the user record that match with the parametered dto object attributes value.
            var dataUser = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.UteId == userLoginDto.UteId && x.UteCliId == userLoginDto.UteCliId);
            // Returning null dto if no record found.s
            if (dataUser == null)
            {
                return dto;
            }
            // Checking whether the password match the provided one.
            if (dataUser.UtePassword == userLoginDto.UtePassword)
            {
                // Setting empty string instead of null value.
                if (dataUser.UteRuolo == null)
                {
                    dataUser.UteRuolo = "";
                }

                // Initiaing the value into pre-declared dto object and then return to controller end.
                return new LoginUserResponseDto()
                {
                    UteAttivo = dataUser.UteAttivo,
                    UteRuolo = dataUser.UteRuolo,
                    UteId = dataUser.UteId,
                    UteNome = dataUser.UteNome,
                    Token = _cm.GenerateToken(dataUser),
                    UteMail = dataUser.UteMail,
                    userAuthList = (await _unitOfWork.Users.GetUtentiAbilitazioneListAsync(dataUser.UteId.ToString(), dataUser.UteCliId.ToString())).ToList()
                };
            }
            else
            {
                return dto;
            }
        }


        /// <summary>
        ///     To count the fail attemps within five minutes.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private async Task<int> FailedAttemptsWithinFiveMinutes(string userId)
        {
            //find out last successful atempt for this user ID
            var lastLogIn = await _unitOfWork.Azioni
                .FirstOrDefaultAsync(a => a.AzioneDettaglio01.Equals(userId) && a.AzioneDettaglio03.Equals("login_ok"));
            var lastSuccessLogId = Convert.ToInt32(lastLogIn?.AzioneId);

            int allFailedAtemptsCount = 0;


            //find out the failed attempt for this user id 
            //after last successful attempt and also
            //within last 5 minutes
            if (lastSuccessLogId > 0)
            {
                var fiveMiniutesAgo = DateTime.Now.AddMinutes(-5);
                var allFailedAttempts = await _unitOfWork.Azioni
                            .FindAsync(a => a.AzioneId > lastSuccessLogId
                                && a.AzioneDettaglio01.Equals(userId)
                                && a.AzioneInizio > fiveMiniutesAgo);

                allFailedAtemptsCount = allFailedAttempts.Count();                
            }
            return allFailedAtemptsCount;
        }
    }
}
