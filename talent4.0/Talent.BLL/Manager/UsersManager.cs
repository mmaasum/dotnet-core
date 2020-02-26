using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.Common.Enums;
using Talent.DataModel;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class UsersManager : IUsersManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> Delete(string uteId, string uteCliId)
        {
            // Retreiving the deletable object.
            var utenti = await _unitOfWork.Users.FirstOrDefaultAsync(c => c.UteId.Equals(uteId) && c.UteCliId.Equals(uteCliId));
            // Updating the status as inactive rather than delete.
            utenti.UteAttivo = "N";
            // Passing data to dal.
            int iUteId = await _unitOfWork.CompleteAsync();
            // Returning the recently deleted utenti id.
            return uteId;
        }

        public async Task<TalentUserProfileDto> FindUserProfileData(string uteId, string cliId)
        {
            try
            {
                // Fetching from dal.
                TalentUserProfiles userProfile = await _unitOfWork.Users.FindByUserProfileAsync
                                        (x => x.TauseUteId.Equals(uteId)
                                           && x.TauseCliId.Equals(cliId));

                TalentUserProfileDto userProfileDto = _mapper.Map<TalentUserProfiles, TalentUserProfileDto>(userProfile);
                // Returning the retrieved data to controller end.
                return userProfileDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<V_AuthUtenti>> GetAllAuthHavingUtentiData(string uteId, string uteCliId)
        {
            try
            {
                var data = await _unitOfWork.Users.GetAllAuthHavingUtenti(uteId, uteCliId);
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }


        

        public async Task<IEnumerable<UtentiOptimizedDto>> GetAllUtentiByRole(string clientId, string role)
        {
            // Retrieving the data from dal.
            var users = await _unitOfWork.Users.FindAsync(x => x.UteCliId.Equals(clientId) && x.UteRuolo.Equals(role));
            
            users = users.OrderByDescending(c => c.UteAttivo).ThenBy(c => c.UteNome).ToList();
            // Mapping data to dto list and then returning to controller end.
            var usersDtoList = _mapper.Map<List<Utenti>, List<UtentiOptimizedDto>>(users.ToList());

            return usersDtoList;
        }

        public async Task<IEnumerable<UtentiDto>> GetAllActiveUsers()
        {
            try
            {
                // Fething from dal.
                var users = (await _unitOfWork.Users.FindAsync(c => c.UteAttivo == "S"))
                                .OrderByDescending(c => c.UteAttivo).ThenBy(c=> c.UteNome)
                                .ToList()
                                .Take(500);
                var usersDtoList = _mapper.Map<List<Utenti>, List<UtentiDto>>(users.ToList());

                return usersDtoList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UtentiDto>> GetAllUtentiDataByCliId(string cliId)
        {
            // Fetching from dal.
            var users = await _unitOfWork.Users.FindAsync(x => x.UteCliId.Equals(cliId) && x.UteAttivo == "S");
            users = users.OrderByDescending(c => c.UteAttivo).ThenBy(c => c.UteId).ToList();
            var usersDtoList = _mapper.Map<List<Utenti>, List<UtentiDto>>(users.ToList());

            return usersDtoList;
        }

        public async Task<IEnumerable<ClientDto>> GetClientListByUteIdData(string uteId)
        {
            // See GetAllClientDataByUteIdAsync of ClientManager.
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UtentiOptimizedDto>> GetOptimizedUtentiListData(string cliId, string userStatus)
        {
            var users = new List<Utenti>();
            if (userStatus == "A")
            {
                users = (await _unitOfWork.Users.FindAsync(x => x.UteCliId.Equals(cliId))).OrderByDescending(c=> c.UteAttivo).ThenBy(c=> c.UteId).ToList(); 
            }
            else
            {
                users = (await _unitOfWork.Users.FindAsync(x => x.UteCliId.Equals(cliId) && x.UteAttivo.Equals(userStatus))).OrderByDescending(c => c.UteAttivo).ThenBy(c => c.UteId).ToList();
            }
            var usersDtoList = _mapper.Map<List<Utenti>, List<UtentiOptimizedDto>>(users);
            return usersDtoList;
        }

        public async Task<UtentiDto> GetUtentiDetail(string cliId, string uteId)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.UteCliId.Equals(cliId) && x.UteId.Equals(uteId));
            var userDto = _mapper.Map<Utenti, UtentiDto>(user);
            return userDto;
        }

        public async Task<bool> HasSamePassForSameUsername(string userId, string password)
        {
            var users = await _unitOfWork.Users.FindAsync(u => u.UteId.Equals(userId) && u.UtePassword.Equals(password));
            return users.Count() > 0 ? true : false;
        }

        public async Task<string> Insert(UtentiDto utentiDto, List<UtentiAbilitazioniDto> userAuthDtoList)
        {
            try
            {
                // Model class mapping from UtentiDto to Utenti.
                var utenti = _mapper.Map<UtentiDto, Utenti>(utentiDto);
                utenti.UteAttivo = "S";
                utenti.UteModUteId = utentiDto.UteInsUteId;
                utenti.UteInsTimestamp = DateTime.Now;
                utenti.UteModTimestamp = DateTime.Now;

                // Setting some default value which aren't belonges to dto object.
                utenti.UteTipoClientEmail = "outlook";
                utenti.UteRicerchePortaliMaxNum = 0;
                utenti.UteDeveloper = "N";
                utenti.UteLimiteMaxSms = 0;
                utenti.UteModalitaDebug = "";

                // Initialazing the UtentiAbilitazioni.
                List<UtentiAbilitazioni> userAuthList = new List<UtentiAbilitazioni>();

                // Loop to map from UtentiAbilitazioniDto to UtentiAbilitazioni.
                foreach (var userAuthDto in userAuthDtoList)
                {
                    if (userAuthDto.UteabAbilitato == "S")
                    {
                        // Model class mapping from UtentiAbilitazioniDto to UtentiAbilitazioni.
                        var utentiAbilitazioni = _mapper.Map<UtentiAbilitazioniDto, UtentiAbilitazioni>(userAuthDto);
                        utentiAbilitazioni.UteabUteId = utenti.UteId;
                        utentiAbilitazioni.UteabInsUteId = utenti.UteInsUteId;
                        utentiAbilitazioni.UteabModUteId = utenti.UteInsUteId;
                        utentiAbilitazioni.UteabProcedura = userAuthDto.TipoabilitProcedura;
                        utentiAbilitazioni.UteabInsTimestamp = DateTime.Now;
                        utentiAbilitazioni.UteabModTimestamp = DateTime.Now;
                        utentiAbilitazioni.UteabCliId = utenti.UteCliId;
                        // Adding the mapped object into the list.
                        userAuthList.Add(utentiAbilitazioni);
                    }
                }

                // Passing the data to dal.
                _unitOfWork.Users.Add(utenti);
                _unitOfWork.UtentiAbilitazioni.AddRange(userAuthList);
                // Returning the recently inserted utenti id.
                await _unitOfWork.CompleteAsync();
                return utenti.UteId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool IsValidPass(string password)
        {
            bool result = password.All(c => Char.IsLetterOrDigit(c) || c == '_' || c == '.' || c == '-');
            if (result == false)
            {
                return result;
            }

            var regexItem1 = new Regex("[.]");
            var regexItem2 = new Regex("[_]");
            var regexItem3 = new Regex("[-]");
            bool isValidPassword = false;

            if (password.Any(char.IsLower) && password.Any(char.IsUpper)
                       && password.Any(char.IsDigit))
            {
                if (password.Length >= 8 && password.Length <= 10)
                {
                    if (regexItem1.IsMatch(password) || regexItem2.IsMatch(password) || regexItem3.IsMatch(password))
                    {
                        isValidPassword = true;
                    }
                }
            }

            return isValidPassword;
        }

        public async Task<string> Update(UtentiDto utentiDto, List<UtentiAbilitazioniDto> userAuthDtoList)
        {
            // Model class mapping from UtentiDto to Utenti.
            var utenti = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.UteId.Equals(utentiDto.UteId) && u.UteCliId.Equals(utentiDto.UteCliId));

            _mapper.Map(utentiDto, utenti);

            utenti.UteModTimestamp = DateTime.Now;
            // Setting null for empty string of role.
            if (utenti.UteRuolo == "")
            {
                utenti.UteRuolo = null;
            }

            // Initialazing the UtentiAbilitazioni.
            List<UtentiAbilitazioni> userAuthList = new List<UtentiAbilitazioni>();

            // Loop to map from UtentiAbilitazioniDto to UtentiAbilitazioni.
            foreach (var userAuthDto in userAuthDtoList)
            {
                // Model class mapping from UtentiAbilitazioniDto to UtentiAbilitazioni.
                var utentiAbilitazioni = _mapper.Map<UtentiAbilitazioniDto, UtentiAbilitazioni>(userAuthDto);

                utentiAbilitazioni.UteabInsUteId = utenti.UteModUteId;
                utentiAbilitazioni.UteabModUteId = utenti.UteModUteId;
                utentiAbilitazioni.UteabInsTimestamp = DateTime.Now;
                utentiAbilitazioni.UteabModTimestamp = DateTime.Now;
                utentiAbilitazioni.UteabProcedura = userAuthDto.TipoabilitProcedura;
                utentiAbilitazioni.UteabUteId = utenti.UteId;
                utentiAbilitazioni.UteabCliId = utenti.UteCliId;
                // Adding the mapped object into the list.
                userAuthList.Add(utentiAbilitazioni);
            }

            foreach (var _userAuth in userAuthList)
            {
                // Checking whether this authentication is already exist for this user/utenti or not.
                var records = await _unitOfWork.UtentiAbilitazioni.
                                    FindAsync(c => c.UteabUteId == _userAuth.UteabUteId && c.UteabProcedura == _userAuth.UteabProcedura
                                                && c.UteabCliId == _userAuth.UteabCliId);

                // If doesn't exists and the authentication is checked then that auth is added for that utenti.
                if (records.Count() == 0 && _userAuth.UteabAbilitato == "S")
                {
                    _unitOfWork.UtentiAbilitazioni.Add(_userAuth);
                }
                else
                {
                    // If exist, then update the status and modified time of that auth for that utenti.
                    if (records.Count() != 0)
                    {
                        var updatableRow = await _unitOfWork.UtentiAbilitazioni
                                        .FirstOrDefaultAsync(c => c.UteabUteId == _userAuth.UteabUteId 
                                                && c.UteabProcedura == _userAuth.UteabProcedura
                                                && c.UteabCliId == _userAuth.UteabCliId);
                        updatableRow.UteabAbilitato = _userAuth.UteabAbilitato;                        
                    }
                }
            }

            await _unitOfWork.CompleteAsync();
            // Returning the recently updated utenti id.
            return utentiDto.UteId;
        }

        public async Task<IEnumerable<string>> UserAuthList(string uteId, string uteCliId)
        {
            try
            {
                var data = await _unitOfWork.Users.GetAllAuthHavingUtenti(uteId, uteCliId);

                List<string> auths = new List<string>();
                foreach (var item in data)
                {
                    if (!string.IsNullOrEmpty(item.UteabUteId))
                    {
                        auths.Add(item.TipoabilitProcedura);
                    }
                }
                return auths;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
