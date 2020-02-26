using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL.Utilities;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.Web.Controllers.WebService;

namespace Talent.Web.Controllers.Administrative
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtentiController : ControllerBase
    {
        private readonly IAzioniManager _azioniManager;
        private readonly IUsersManager _userManager;
        private readonly IFilialiManager _filialiManager;
        private readonly ITitoliManager _titoliManager;
        private readonly IUtilityManager _utilityManager;

        private CommonBLL _cm = new CommonBLL();
        public UtentiController(IAzioniManager azioniManager, IUsersManager userManager, IFilialiManager filialiManager, ITitoliManager titoliManager,  IUtilityManager utilityManager)
        {
            _azioniManager = azioniManager;
            _userManager = userManager;
            _filialiManager = filialiManager;
            _titoliManager = titoliManager;
            _utilityManager = utilityManager;
        }


        [HttpGet]
        [Route("GetUserProfileDataByUteId/{uteId}/{cliId}")]
        public async Task<IActionResult> GetUserProfileDataByUteId(string uteId, string cliId)
        {
            try
            {
                //var categories = await _talentBllWrapper.UtentiBll.FindUserProfileData(uteId, cliId);
                var categories = await _userManager.FindUserProfileData(uteId, cliId);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get all Fillali");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        [HttpGet]
        [Route("checkValidPass/{pass}")]
        public ActionResult CheckValidPass(string pass)
        {
            //var isValidPass = _talentBllWrapper.UtentiBll.isValidPass(pass);
            var isValidPass =  _userManager.IsValidPass(pass);
            if (!isValidPass)
            {
                var result = new
                {
                    error = "Validation Failed",
                    error_type = "",
                    message = "Password should have 1 digit, 1 symbol (dot/Underline/minus sign) , 1 capital letter and 1 small letter"
                };
                return BadRequest(result);
            }
            return Ok("ok");
        }



        [HttpGet]
        [Route("getallutentibyrole/{clientid}/{rulo}")]
        public async Task<ActionResult> GetAllUtentiByRole(string clientid, string rulo)
        {
            try
            {
                //var categories = await _talentBllWrapper.UtentiBll.GetAllUtentiByRoleData(clientid, rulo);
                var categories = await _userManager.GetAllUtentiByRole(clientid, rulo);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get all Utenti based on role and client_id");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///    Fetching all the utenti list ( but only 2 column data) based on client id.
        /// </summary>
        /// <purpose>
        ///    As utenti table a number of data , but all the field data isn't necessary 
        ///             when it is required to load the utenti a select/dropdown option.
        ///    That's why this api only retrive 2 specific coluimn of utenti table by optimizing it.
        /// </purpose>
        /// <param name="clientid">client id of the logged in user</param>
        /// <returns>List data of utenti data having fewer columns.</returns>
        /// 
        //GET: api/utenti/getallutenti/clientid
        [HttpGet]
        [Route("GetOptimizedUtentiList/{clientid}/{userStatus}")]
        public async Task<ActionResult> GetOptimizedUtentiList(string clientid, string userStatus)
        {
            try
            {
                //var categories = await _talentBllWrapper.UtentiBll.GetOptimizedUtentiListData(clientid, userStatus);
                var categories = await _userManager.GetOptimizedUtentiListData(clientid, userStatus);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get Optimized Utenti List");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }





        /// <summary>
        ///     To get the client list id based on provided ute id
        /// </summary>
        /// <purpose>
        ///    When a user is trying to login to the database, one may see only the/those client id that may contain that ute id.
        ///</purpose>
        /// <param name="uteId">the id provided by the user while trying to login</param>
        /// <returns>The list of client id by ute id</returns>
        //GET: api/utenti/getCliListByUteId/uteId
        [HttpGet]
        [Route("GetCliListByUteId/{uteId}")]
        public async Task<ActionResult> GetCliListByUteId(string uteId)
        {
            try
            {
                //var categories = _talentBllWrapper.UtentiBll.GetClientListByUteIdData(uteId);
                var categories = await _userManager.GetClientListByUteIdData(uteId);
                if (categories == null)
                {
                    return NotFound();
                }

                //var clients = categories.Select(a => new ClientDto
                //{
                //    CliId = a.UteCliId,
                //    CliNome = a.UteCliId
                //});
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get Client list based on ute_id");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }


        /// <summary>
        ///    To get the list of fillali based on client id
        /// </summary>
        /// <purpose>
        ///    While creating a user, it is required to choose the fillali from the list for that specific user.
        ///</purpose>
        /// <param name="clientId">client id of the logged in user</param>
        /// <returns>List of fillali which are synced to the provided client id</returns>
        //GET: api/utenti/GetAllFiliali/clientId
        [HttpGet]
        [Route("GetAllFiliali/{clientId}")]
        public async Task<IActionResult> GetAllFiliali(string clientId)
        {
            try
            {
                //var categories = await _talentBllWrapper.UtentiBll.GetAllFilialiData(clientId);
                var categories = await _filialiManager.GetAllFilialiByClientId(clientId);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get all Fillali");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///    To get the list of titoli based on client id
        /// </summary>
        /// <purpose>
        ///    While creating a user, it is required to choose the titoli from the list for that specific user.
        ///</purpose>
        /// <param name="clientId">client id of the logged in user</param>
        /// <returns>List of titoli which are synced to the provided client id</returns>
        //GET: api/utenti/GetAllTitoli/clientId
        [HttpGet]
        [Route("GetAllTitoli/{clientId}")]
        public async Task<IActionResult> GetAllTitoli(string clientId)
        {
            try
            {
                //var categories = await _talentBllWrapper.UtentiBll.GetAllTitoliData(clientId);
                var categories = await _titoliManager.GetAllTitoliByClientId(clientId);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get all Titoli");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }



        /// <summary>
        ///      Get all the auth list, but having the ute_id if exist, otherwise null.
        /// </summary>
        /// <purpose>
        ///    It is required while editing a ute data. 
        ///    This api load all the authentication list and those are already synced with that user is loaded as checked.
        ///    Front-end developers will check whether the ute id is null. If null then keep the auth as unchecked, otherwise checked.
        ///</purpose> 
        /// <param name="uteId">Ute_Id: which need to be updated.</param>
        /// <param name="clientId">Client_Id: which belongs to the provided ute id.</param>
        /// <returns>
        ///     A list having 2 columns. one is auth and another is the ute id.
        ///     If the user doen't have the access to the auth, then the ute id will be null.
        /// </returns>
        //GET: api/utenti/GetAllAuthHavingUtenti/uteId/clientId 
        [HttpGet]
        [Route("GetAllAuthHavingUtenti/{uteId}/{clientId}")]
        public async Task<IActionResult> GetAllAuthHavingUtenti(string uteId, string clientId)
        {
            try
            {
                //var categories =  _talentBllWrapper.UtentiBll.GetAllAuthHavingUtentiData(uteId, clientId);
                var categories = await _userManager.GetAllAuthHavingUtentiData(uteId, clientId);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get all auth which have any utenti");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        [HttpGet]
        [Route("GetAllUserAuths/{uteId}/{clientId}")]
        public async Task<ActionResult> GetAllUserAuths(string uteId, string clientId)
        {
            try
            {
                //var categories = _talentBllWrapper.UtentiBll.UserAuthList(uteId, clientId);
                var categories = await _userManager.UserAuthList(uteId, clientId);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get all auth which have any utenti");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        [HttpGet]
        [Route("GetUserIsInAuth/{uteId}/{clientId}/{auth}")]
        public async Task<IActionResult> GetUserIsInAuth(string uteId, string clientId, string auth)
        {
            try
            {
                //var allAuths = _talentBllWrapper.UtentiBll.UserAuthList(uteId, clientId);
                var allAuths = await _userManager.UserAuthList(uteId, clientId);
                var isInAuth = allAuths.Any(a => a == auth);
                return Ok(new { status = isInAuth });
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get all auth which have any utenti");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     Fetching all the utenti list.
        /// </summary>
        /// <returns>List of utenti</returns>
        ///
        //GET: api/utenti/getallutenti
        [HttpGet]
        [Route("GetAllUtenti")]
        public async Task<ActionResult> GetAllUtenti()
        {
            try
            {
                //var categories = await _talentBllWrapper.UtentiBll.GetAllUtentiData();
                var categories = await _userManager.GetAllActiveUsers();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get all Utenti");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }


        /// <summary>
        ///    Fetching all the utenti list based on client id.
        /// </summary>
        /// <param name="clientid">client id of the logged in user</param>
        /// <param name="counter">T
        ///     This is define that how many rows will be skipped while retreiving data from the system.
        ///     e.g: if the counter is 0, then it will skip 0*500 rows, if the the counter is 1. then it will 1*500 rows and will retrive 501-1000th record.
        /// </param>
        /// <returns>List data of utenti</returns>
        /// 
        //GET: api/utenti/getallutenti/clientid
        [HttpGet]
        [Route("GetAllUtenti/{clientid}")]
        public async Task<ActionResult> GetAllUtentiByClientId(string clientid)
        {
            try
            {
                //var categories = await _talentBllWrapper.UtentiBll.GetAllUtentiDataByCliId(clientid);
                var categories = await _userManager.GetAllUtentiDataByCliId(clientid);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get all Utenti based on client_id");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///    Fetching utente detail.
        /// </summary>
        /// <param name="clientid">client id of the logged in user</param>
        /// <param name="uteId"></param>
        /// <returns>Detail data of utenti</returns>
        /// 
        //GET: api/utenti/getUtenti/clientid
        [HttpGet]
        [Route("getUtenti/{clientid}/{uteId}")]
        public async Task<ActionResult> GetUtenti(string clientid, string uteId )
        {
            try
            {
                //var categories = await _talentBllWrapper.UtentiBll.GetUtentiDetail(clientid, uteId);
                var categories = await _userManager.GetUtentiDetail(clientid, uteId);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get Utenti based on client_id and uteId");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///     Submit the data to create a new utenti
        /// </summary>
        /// <param name="utentiDto">Utenti Object to store data</param>
        /// <param name="userAuthList">To store UtentiAbilitazioni means UserAuth data</param>
        /// <returns></returns>
        // POST: api/Utenti/postUtenti/
        [HttpPost]
        [Route("postUtenti")]
        public async Task<IActionResult> PostUtenti([FromBody] UtentiDto utentiDto)
        {
            try
            {
                if (utentiDto == null)
                {
                    return NotFound();
                }

                var isValidPass = _userManager.IsValidPass(utentiDto.UtePassword);
                if (!isValidPass)
                {
                    var result = new
                    {
                        error = "Validation Failed",
                        error_type = "",
                        message = "Password should have 1 digit, 1 symbol, 1 capital letter and 1 small letter"
                    };
                    return BadRequest(result);
                }


                //var userHasSamePassForSameUsername = _talentBllWrapper.UtentiBll.HasSamePassForSameUsername(utentiDto.UteId, utentiDto.UtePassword);
                var userHasSamePassForSameUsername = await _userManager.HasSamePassForSameUsername(utentiDto.UteId, utentiDto.UtePassword);
                if (userHasSamePassForSameUsername)
                {
                    var result = new
                    {
                        error = "Validation Failed",
                        error_type = "",
                        message = "There's a user having same username and password for some other client"
                    };
                    return BadRequest(result);
                }

                utentiDto.UteInsUteId = this.LoggedInUserId();

                await _userManager.Insert(utentiDto, utentiDto.UtentiAbilitazioniDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "utenti");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Insert new Utenti");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     Delete the record of an utenti, actually update the status as Inactive for a Utenti Recorde. 
        /// </summary>
        /// <purpose>
        ///   To delete a user data, so that the system doesn't show any existence of it.
        ///   But here we're updating the status as Inactive instead of deleting, so that others record may find out if required.
        ///</purpose> 
        /// <param name="uteId">The ute id of the user which need to be deleted.</param>
        /// <param name="uteCliId">Client id of the user which need to be deleted.</param>
        /// <returns>general confirmation message</returns>
        // DELETE: api/Utenti/deleteUtenti/uteId/uteCliId
        [HttpDelete]
        [Route("deleteUtenti/{uteId}/{uteCliId}")]
        public async Task<IActionResult> DeleteUtenti(string uteId, string uteCliId)
        {
            try
            {
                await _userManager.Delete(uteId, uteCliId);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "delete", "utenti");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Delete Utenti");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }



        /// <summary>
        ///     Update the record of a specific utenti.
        /// </summary>
        /// <param name="utentiDto">Utenti object which need to be updated.</param>
        /// <returns>general confirmation message</returns>
        // PUT: api/Utenti/updateUtenti/
        [HttpPut]
        [Route("updateUtenti")]
        public async Task<IActionResult> PutUtenti(UtentiDto utentiDto)
        {
            try
            {
                if (utentiDto == null)
                {
                    return NotFound();
                }

                utentiDto.UteModUteId = this.LoggedInUserId();
                await _userManager.Update(utentiDto, utentiDto.UtentiAbilitazioniDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "utenti");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Update Utenti");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }
        
    }
}
