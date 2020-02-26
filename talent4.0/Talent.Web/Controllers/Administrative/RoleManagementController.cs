using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.Web.Helpers;

namespace Talent.Web.Controllers.Administrative
{
    [Route("api/[controller]")]
    public class RoleManagementController : ControllerBase
    {
        private readonly IAzioniManager _azioniManager;
        private readonly IUtilityManager _utilityManager;
        private readonly IRoleManager _roleManager;


        public RoleManagementController (IAzioniManager azioniManager, IUtilityManager utilityManager, IRoleManager roleManager)
        {
            _azioniManager = azioniManager;
            _utilityManager = utilityManager;
            _roleManager = roleManager;
        }


        [HttpPut]
        [Route("ManageUpdateRole")]
        public async Task<IActionResult> ManageUpdateRole([FromBody]ViewRuoloUtentiDto viewRuoloUtentiDto)
        {
            try
            {
                var categories = await _roleManager.ManageUpdateRoleData(viewRuoloUtentiDto);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(viewRuoloUtentiDto);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Update Role Data");
                return BadRequest(errorObj);
            }
        }



        [HttpPost]
        [Route("GetDetailsByObj")]
        public async Task<IActionResult> GetRoleDetails([FromBody]ViewRuoloUtentiDto viewRuoloUtentiDto)
        {
            try
            {
                var categories = await _roleManager.GetRoleDetailsData(viewRuoloUtentiDto);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get Role Details");
                return BadRequest(errorObj);
            }
        }

        [HttpPost]
        [Route("ManageInsertNewRole")]
        public async Task<IActionResult> ManageInsertNewRole([FromBody]ViewRuoloUtentiDto viewRuoloUtentiDto)
        {
            try
            {
                var categories = await _roleManager.ManageInsertRoleData(viewRuoloUtentiDto);
                if (categories == null)
                {
                    return NotFound();
                }

                if(categories == "L01351_roleExist")
                {
                    return BadRequest( new { code = "L01351_roleExist" });
                }
                return Ok(viewRuoloUtentiDto);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Add New Role");
                return BadRequest(errorObj);
            }
        }



        [HttpGet]
        [Route("GetActiveUserForRole/{roleName}/{cliId}")]
        public async Task<IActionResult> GetActiveUserForRole(string roleName, string cliId)
        {
            try
            {
                var categories = await _roleManager.GetActiveUserForRoleData(roleName, cliId);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Count Utenti based on Ruolo");
                return BadRequest(errorObj);
            }
        }


        [HttpGet]
        [Route("GetActiverPermissionForRole/{roleName}/{cliId}")]
        public async Task<IActionResult> GetActiverPermissionForRole(string roleName, string cliId)
        {
            try
            {
                var categories = await _roleManager.GetActiverPermissionForRoleData(roleName, cliId);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Count Utenti based on Ruolo");
                return BadRequest(errorObj);
            }

        }

        ///////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        ///     To count the utenti that belong to the provided role.
        /// </summary>
        /// <purpose>
        ///     While updating the auth list of a role, user may update all the auth settings of those utenti who're having that role.  
        ///     This is why user need to know the number of utenti is being affected throgh this changes.
        /// </purpose>
        /// <param name="roleName">Role that need to be udpated with it's auth list.</param>
        /// <param name="cliId">client id of the logged in user/utenti</param>
        /// <returns>A integer that defines the number of user.</returns>
        /// GET: api/RoleManagement/GetCountUtentiByRole/roleName/cliId
        [HttpGet]
        [Route("GetCountUtentiByRole/{roleName}/{cliId}")]
        public async Task<IActionResult> GetCountUtentiByRole(string roleName, string cliId)
        {
            try
            {
                var categories = await _roleManager.GetCountUtentiByRuoloData(roleName, cliId);
                if (categories == 0)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Count Utenti based on Ruolo");
                return BadRequest(errorObj);
            }
         
        }



        /// <summary>
        ///     Update the synced auth list against a role
        /// </summary>
        /// <purpose>
        ///     To change the defined auth list for a role.
        ///     To change the defined auth list for each user who are having this role. ( It happens only when userAuthChangedConfirmation is 1(YES)).
        /// </purpose>
        /// <param name="roleAuthList">AuthList having the role </param>
        /// <param name="userAuthChangedConfirmation">Defines either the user auth will changed according the role-auth changing value</param>
        /// <returns> Acitivity Message </returns>
        // PUT: api/RoleManagement/UpdateRoleAuth
        [HttpPut]
        [Route("UpdateRoleAuth/{userAuthChangedConfirmation}")]
        public async Task<IActionResult> PutRuoloAbilitazione([FromBody] List<RuoliTipiAbilitazioneDto> ruoliTipiAbilitazioneDtoList , int userAuthChangedConfirmation)
        {
            try
            {
                if (ruoliTipiAbilitazioneDtoList == null)
                {
                    return NotFound();
                }
                await _roleManager.UpdateRoleAuthData(ruoliTipiAbilitazioneDtoList, userAuthChangedConfirmation);
              
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "ruolo_abilitazione");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Update Role Authentication List");
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///  Get api to retreive all the auth list regardless any role.
        /// </summary>
        /// <purpose>
        ///    While changing the auth list of a role, it is necessary to load all the auth.
        ///    Here the auth list is loaded having two columns. One is the auth name and another the provided rolename if the specific auth 
        ///         is synced to that role.
        /// </purpose>
        /// <param name="roleName">the role for which the synced auth list going to be changed.</param>
        /// <param name="clientId">client id of the logged in user.</param>
        /// <returns>List of auth</returns>
        // GET: api/RoleManagement/GetAllAuthHavingRole/roleName/clientId
        [HttpGet]
        [Route("GetAllAuthHavingRole/{roleName}/{clientId}")]
        [TypeFilter(typeof(LoggerActionFilter), Arguments = new object[] { "get", "All auths of a role" })]
        public async Task<IActionResult> GetAllAuthHavingRole(string roleName, string clientId)
        {
            try
            {
                var categories = _roleManager.GetAllAuthHavingRoleData(roleName, clientId);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get All Auth which have Rulo");
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     Get api to retribe the auth list based on the role.
        /// </summary>
        /// <purpose>
        ///    To get only those auth which are related to the role.
        /// </purpose>
        /// <param name="roleName">provided role: based on this only the synced auth will be loaded.</param>
        /// <param name="clientId">client id of the logged in user.</param>
        /// <returns> List Object of auth</returns>
        // GET: api/RoleManagement/GetAllAuthByRole/roleName/clientId
        [HttpGet]
        [Route("GetAllAuthByRole/{roleName}/{clientId}")]
        public async Task<IActionResult> GetAllAuthByRole(string roleName, string clientId)
        {
            try
            {
                var categories = await _roleManager.GetAllAuthByRoleData(roleName, clientId);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get Auth list based on Ruolo");
                return BadRequest(errorObj);
            }

        }



        [HttpGet]
        [Route("GetCountAuthByRole/{roleName}/{cliId}")]
        public async Task<IActionResult> GetCountAuthByRole(string roleName, string cliId)
        {
            try
            {
                var categories = await _roleManager.GetCountAuthByRoleData(roleName, cliId);
                if (categories == 0)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Count Auth based on Ruolo");
                return BadRequest(errorObj);
            }

        }


        /// <summary>
        ///      Get api to retrieve all the roles.
        /// </summary>
        /// <purpose>
        ///         While adding/updating a role or load the list of role while adding/updating a utrenti.
        /// </purpose>
        /// <returns>List object having all the roles.</returns>
        // GET: api/RoleManagement/GetUserAllRoles
        [HttpGet]
        [Route("GetUserAllRoles")]
        public async Task<IActionResult> GetRuoliUtenti()
        {
            try
            {
                var categories = await _roleManager.GetAllUserRolesData();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get all Roulo");
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///     To get the list of all user roles based on client id.
        /// </summary>
        /// <purpose>
        ///         While adding/updating a role or load the list of role while adding/updating a utrenti.
        /// </purpose>
        /// <param name="clientid">client id of the logged in user</param>
        /// <returns>List object having all the roles.</returns>
        // GET: api/RoleManagement/GetUserAllRoles/clientid
        [HttpGet, Authorize]
        [Route("GetUserAllRoles/{clientid}")]
        public async Task<IActionResult> GetRuoliUtentiByClient(string clientid)
        {
            try
            {
                var categories = await _roleManager.GetAllUserRolesDataByClientId(clientid);
                if (categories == null)
                {
                    return NotFound();
                }

                //await _utilityManager.GenerateLogOperazioniDto(User," "," ");
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get all Roulo based on client id");
                return BadRequest(errorObj);
            }

        }
        /// <summary>
        ///     Get the related details of selected role
        /// </summary>
        /// <param name="id"> Id of the selected role is being passed</param>
        /// <returns>An object having the related details of a specific role</returns>
        // GET: api/RoleManagement/GetRuoliUtentiDetails?id="id"
        [HttpGet]
        [Route("getUserRolesDetail")]
        public async Task<IActionResult> GetRuoliUtentiDetails(string id)
        {
            try
            {
                var categories = await _roleManager.GetUserRoleDetailsData(id);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get Rulo details");
                return BadRequest(errorObj);
            }

        }


        [HttpPost]
        [Route("insertruolo")]
        public async Task<IActionResult> InsertRuolo([FromBody] RuoliUtentiDto ruoliUtentiDto)
        {
            try
            {
                var categories = await _roleManager.InsertRuoloData(ruoliUtentiDto);
                if (categories == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "ruolo");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);

                return Ok();
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Insert new Ruolo");
                return BadRequest(errorObj);
            }
        }

         [HttpPut]
        [Route("updateruolo/{roleName}")]
        public async Task<IActionResult> UpdateRuolo([FromBody] RuoliUtentiDto ruoliUtentiDto, string roleName)
        {
            try
            {
                await _roleManager.UpdateRuoloData(ruoliUtentiDto,roleName);
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "ruolo");
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Update Ruolo");
                return BadRequest(errorObj);
            }
        }

        [HttpDelete]
        [Route("deleteruolo/{ruolo}/{cliId}")]
        public async Task<IActionResult> Deleteruolo(string ruolo, string cliId)
        {
            try
            {
                await _roleManager.DeleteRuoloData(ruolo, cliId);
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "delete", "ruolo");
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Delete Ruolo");
                return BadRequest(errorObj);
            }
        }


    }
}
