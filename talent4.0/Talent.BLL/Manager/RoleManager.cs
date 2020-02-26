using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.DataModel;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class RoleManager : IRoleManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private RuoliUtenti GetRuoliUtentiObject(ViewRuoloUtentiDto viewRuoloUtentiDto)
        {
            RuoliUtenti ruoliUtenti = new RuoliUtenti();
            ruoliUtenti.Ruolo = viewRuoloUtentiDto.Ruolo;
            ruoliUtenti.RuoloInsTimestamp = DateTime.Now;
            ruoliUtenti.RuoloInsUteId = viewRuoloUtentiDto.RuoloInsUteId;

            ruoliUtenti.RuoloModTimestamp = DateTime.Now;
            ruoliUtenti.RuoloModUteId = viewRuoloUtentiDto.RuoloModUteId;
            ruoliUtenti.RuoloCliId = viewRuoloUtentiDto.RuoloCliId;
            ruoliUtenti.RuoloAbilitato = viewRuoloUtentiDto.RuoloAbilitato;
            ruoliUtenti.RuoloSystem = viewRuoloUtentiDto.RuoloSystem;

            return ruoliUtenti;
        }

        private RuoliUtentiDescr GetRuoliUtentiDescrObject(ViewRuoloUtentiDto viewRuoloUtentiDto)
        {
            RuoliUtentiDescr ruoliUtentiDescr = new RuoliUtentiDescr();


            ruoliUtentiDescr.RuolodescrRuolo = viewRuoloUtentiDto.Ruolo;
            ruoliUtentiDescr.RuolodescrInsTimestamp = DateTime.Now;
            ruoliUtentiDescr.RuolodescrModTimestamp = DateTime.Now;

            ruoliUtentiDescr.RuolodescrInsUteId = viewRuoloUtentiDto.RuoloInsUteId;
            ruoliUtentiDescr.RuolodescrModUteId = viewRuoloUtentiDto.RuoloModUteId;
            ruoliUtentiDescr.RuolodescrCliId = viewRuoloUtentiDto.RuoloCliId;


            ruoliUtentiDescr.RuolodescrDescrizione = viewRuoloUtentiDto.RuolodescrDescrizione;
            ruoliUtentiDescr.RuolodescrDescrizioneBreve = viewRuoloUtentiDto.RuolodescrDescrizioneBreve;
            ruoliUtentiDescr.RuolodescrDescrizioneEstesa = viewRuoloUtentiDto.RuolodescrDescrizioneEstesa;
            ruoliUtentiDescr.RuolodescrLingua = viewRuoloUtentiDto.RuolodescrLingua;

            return ruoliUtentiDescr;
        }

       
        public async Task<string> ManageUpdateRoleData(ViewRuoloUtentiDto viewRuoloUtentiDto)
        {
            var updatableRole = await _unitOfWork.RuoloUtenti.FirstOrDefaultAsync
                                (c=> c.Ruolo == viewRuoloUtentiDto.Ruolo);
            updatableRole.RuoloSystem = viewRuoloUtentiDto.RuoloSystem;
            updatableRole.RuoloAbilitato = viewRuoloUtentiDto.RuoloAbilitato;
            updatableRole.RuoloModTimestamp = DateTime.Now;
            updatableRole.RuoloModUteId = viewRuoloUtentiDto.RuoloModUteId;


            var updatableRoleDescr = await _unitOfWork.RuoliUtentiDescr.FirstOrDefaultAsync
                               (c => c.RuolodescrRuolo == viewRuoloUtentiDto.Ruolo
                                  && c.RuolodescrCliId == viewRuoloUtentiDto.RuoloCliId
                                  && c.RuolodescrLingua == viewRuoloUtentiDto.RuolodescrLingua);
            if (updatableRoleDescr == null)
            {
                RuoliUtentiDescr ruoliUtentiDescr = GetRuoliUtentiDescrObject(viewRuoloUtentiDto);
                _unitOfWork.RuoliUtentiDescr.Add(ruoliUtentiDescr);
            }
            else
            {
                updatableRoleDescr.RuolodescrDescrizioneBreve = viewRuoloUtentiDto.RuolodescrDescrizioneBreve;
                updatableRoleDescr.RuolodescrDescrizioneEstesa = viewRuoloUtentiDto.RuolodescrDescrizioneEstesa;
                updatableRoleDescr.RuolodescrDescrizione = viewRuoloUtentiDto.RuolodescrDescrizione;
                updatableRoleDescr.RuolodescrModTimestamp = DateTime.Now;
                updatableRoleDescr.RuolodescrModUteId = viewRuoloUtentiDto.RuoloModUteId;
            }

            await _unitOfWork.CompleteAsync();
            return "Ok";

        }

        public async Task<ViewRuoloUtentiDto> GetRoleDetailsData(ViewRuoloUtentiDto viewRuoloUtentiDto)
        {
            try
            {
                var data = await _unitOfWork.RuoliUtentiDescr.FirstOrDefaultAsync
                                (c => c.RuolodescrCliId == viewRuoloUtentiDto.RuoloCliId
                                   && c.RuolodescrRuolo == viewRuoloUtentiDto.Ruolo
                                   && c.RuolodescrLingua == viewRuoloUtentiDto.RuolodescrLingua
                                );


                if (data != null)
                {
                    viewRuoloUtentiDto.RuolodescrDescrizioneBreve = data.RuolodescrDescrizioneBreve;
                    viewRuoloUtentiDto.RuolodescrDescrizioneEstesa = data.RuolodescrDescrizioneEstesa;
                    viewRuoloUtentiDto.RuolodescrDescrizione = data.RuolodescrDescrizione;
                }
                else
                {
                    viewRuoloUtentiDto.RuolodescrDescrizioneBreve = null;
                    viewRuoloUtentiDto.RuolodescrDescrizioneEstesa = null;
                    viewRuoloUtentiDto.RuolodescrDescrizione = null;
                }

                return viewRuoloUtentiDto;

            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<string> ManageInsertRoleData(ViewRuoloUtentiDto viewRuoloUtentiDto)
        {

            var updatableRole = await _unitOfWork.RuoloUtenti.FirstOrDefaultAsync
                               (c => c.Ruolo == viewRuoloUtentiDto.Ruolo);
            if(updatableRole == null)
            {
                RuoliUtenti ruoliUtenti = GetRuoliUtentiObject(viewRuoloUtentiDto);
                _unitOfWork.RuoloUtenti.Add(ruoliUtenti);

                RuoliUtentiDescr ruoliUtentiDescr = GetRuoliUtentiDescrObject(viewRuoloUtentiDto);
                _unitOfWork.RuoliUtentiDescr.Add(ruoliUtentiDescr);

                await _unitOfWork.CompleteAsync();
                return "Ok";
            }
            else
            {
                return "L01351_roleExist";
            }
        }



        public async Task<IEnumerable<object>> GetActiveUserForRoleData(string roleName, string cliId)
        {
            try
            {
                var query = "SELECT DISTINCT(uteab_ute_id) FROM utenti_abilitazioni LEFT JOIN utenti ON utenti_abilitazioni.uteab_ute_id = utenti.ute_id WHERE utenti.ute_attivo = 'S' and uteab_abilitato = 'S' and uteab_procedura IN (SELECT[ruoltipab_uteab_procedura] FROM [talent_ruoli_tipi_abilitazione] WHERE [ruoltipab_ruolo] = '" + roleName + "' and [ruoltipab_uteab_abilitato] = 'n' and [ruoltipab_cli_id] = '"+ cliId + "')";
                var data = await _unitOfWork.GenericQuery.FindDataFromRawQueryAsync(query, "active_user_by_role");
                var datas = data;
              
               
                return datas;
                //return await _unitOfWork.RuoliTipiAbilitazione.CountAsync(x => x.RuoltipabRuolo.Equals(roleName) && x.RuoltipabCliId.Equals(cliId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<object>> GetActiverPermissionForRoleData(string roleName, string cliId)
        {
            try
            {
                var query = "Select ruoltipab_uteab_procedura As uteab_ute_id from talent_ruoli_tipi_abilitazione  Where ruoltipab_ruolo = '"+ roleName +"' AND ruoltipab_uteab_abilitato = 'S'and ruoltipab_cli_id = '"+ cliId +"' Order by ruoltipab_uteab_procedura";
                var data = await _unitOfWork.GenericQuery.FindDataFromRawQueryAsync(query, "active_user_by_role");
                var datas = data;

                return datas;
                //return await _unitOfWork.RuoliTipiAbilitazione.CountAsync(x => x.RuoltipabRuolo.Equals(roleName) && x.RuoltipabCliId.Equals(cliId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rulo"></param>
        /// <param name="cliId"></param>
        /// <returns></returns>
        public async Task<string> DeleteRuoloData(string rulo, string cliId)
        {
            // Retreiving the deletable object.
            var role = await _unitOfWork.RuoloUtenti.FirstOrDefaultAsync(x =>
                                                        x.Ruolo == rulo
                                                        && x.RuoloCliId.Equals(cliId));

            _unitOfWork.RuoloUtenti.Remove(role);
            int resId = await _unitOfWork.CompleteAsync();
            return role.Ruolo ;
        }

        public async Task<IEnumerable<RuoliTipiAbilitazioneDto>> GetAllAuthByRoleData(string roleName, string clientId)
        {
            try
            {
                var ruoloTipiAbilitazioneList = await _unitOfWork.RuoliTipiAbilitazione.FindAsync(c => c.RuoltipabRuolo.Equals(roleName) && c.RuoltipabCliId.Equals(clientId));
                var dtoList = _mapper.Map<List<RuoliTipiAbilitazione>, List<RuoliTipiAbilitazioneDto>>(ruoloTipiAbilitazioneList.ToList());
                return dtoList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SPAuthRoleDto> GetAllAuthHavingRoleData(string roleName, string clientId)
        {
            try
            {
                var logs = _unitOfWork.RuoloUtenti.GetAllAuthHavingRole(roleName, clientId);
                List<SPAuthRoleDto> roleAuthDtoList = _mapper.Map<List<SPAuthRole>, List <SPAuthRoleDto>>(logs.ToList());
                return roleAuthDtoList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RuoliUtentiDto>> GetAllUserRolesData()
        {
            try
            {
                var userRoles =  await _unitOfWork.RuoloUtenti.GetAllAsync();
                var distinctRoles = userRoles.Distinct().OrderBy(c => c.Ruolo);
                return _mapper.Map<List<RuoliUtenti>, List<RuoliUtentiDto>>(distinctRoles.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RuoliUtentiDto>> GetAllUserRolesDataByClientId(string clientId)
        {
            try
            {
                var userRoles = await _unitOfWork.RuoloUtenti.FindAsync(x => x.RuoloCliId.Equals(clientId));
                var distinctRoles = userRoles.Distinct().OrderBy(c => c.Ruolo);
                return _mapper.Map<List<RuoliUtenti>, List<RuoliUtentiDto>>(distinctRoles.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetCountAuthByRoleData(string roleName, string cliId)
        {
            try
            {
                return await _unitOfWork.RuoliTipiAbilitazione.CountAsync(x => x.RuoltipabRuolo.Equals(roleName) && x.RuoltipabCliId.Equals(cliId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetCountUtentiByRuoloData(string roleName, string cliId)
        {
            try
            {
                return await _unitOfWork.Users.CountAsync(x => x.UteRuolo.Equals(roleName) && x.UteCliId.Equals(cliId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserRoleDetails> GetUserRoleDetailsData(string id)
        {
            try
            {
                return await _unitOfWork.RuoloUtenti.GetUserRoleDetails(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> InsertRuoloData(RuoliUtentiDto ruoliUtentiDto)
        {
            RuoliUtenti ruoliUtenti = _mapper.Map<RuoliUtentiDto, RuoliUtenti>(ruoliUtentiDto);
            _unitOfWork.RuoloUtenti.Add(ruoliUtenti);
            await _unitOfWork.CompleteAsync();
            return "Ok";
        }

        public async Task<string> UpdateRoleAuthData(List<RuoliTipiAbilitazioneDto> ruoliTipiAbilitazioneDtoList, int userAuthChangedConfirmation)
        {
            List<RuoliTipiAbilitazione> roleAuthList = _mapper.Map<List<RuoliTipiAbilitazioneDto>, List<RuoliTipiAbilitazione>>(ruoliTipiAbilitazioneDtoList);
            await _unitOfWork.RuoliTipiAbilitazione.UpdateRuoliTipiAbilitazione(roleAuthList, userAuthChangedConfirmation);
            return "Ok";
        }

        public async Task<string> UpdateRuoloData(RuoliUtentiDto ruoliUtentiDto, string roleName)
        {
            ruoliUtentiDto.RuoloModTimestamp = DateTime.Now;

            RuoliUtenti updatableRuolo = await _unitOfWork.RuoloUtenti
                                                .FirstOrDefaultAsync(x =>
                                                         x.Ruolo == roleName
                                                         && x.RuoloCliId.Equals(ruoliUtentiDto.RuoloCliId));

            // deleting the existing record.
            _unitOfWork.RuoloUtenti.Remove(updatableRuolo);
            
            var ruoliUtenti = _mapper.Map<RuoliUtentiDto, RuoliUtenti>(ruoliUtentiDto);
            _unitOfWork.RuoloUtenti.Add(ruoliUtenti);

            await _unitOfWork.CompleteAsync();

            return ruoliUtenti.Ruolo;
        }
    }
}
