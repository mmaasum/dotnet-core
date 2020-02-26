using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers.ApplicationData
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminiController : ControllerBase
    {

        private readonly IAzioniManager _azioniManager;
        private readonly ITerminiManager _terminiManager;
        private readonly IUtilityManager _utilityManager;

        public TerminiController(IAzioniManager azioniManager, ITerminiManager terminiManager,  IUtilityManager utilityManager)
        {
            _azioniManager = azioniManager;
            _terminiManager = terminiManager;
            _utilityManager = utilityManager;
        }


        [HttpPost]
        [Route("GetLastAnalysisInfo/{cliId}/{uteId}")]
        public async Task<IActionResult> GetLastAnalysisInfo(string cliId, string uteId)
        {
            try
            {
                var terminiDtos = await _terminiManager.GetLastAnalysisInfoData(cliId, uteId);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "termini last analysis");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(terminiDtos);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get all termini by sinonimo");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }

        /// <summary>
        ///     To get the list of termini
        /// </summary>
        /// <purpose>
        ///    While inserting/updating termini data, it is necessary to check the uniqueness of sinonimo.
        ///    Here this function is checking whether there is any record that match the any sinonimo with provided sinonimos
        /// </purpose>
        /// <param name="termini">termini name : to check whether it is already exist</param>
        /// <param name="cliId">client id of the logged in user</param>
        /// <param name="sinonimoArray">list of sinonimo that are provided to add or update a termini</param>
        /// <returns></returns>
        // POST: api/termini/GetAllTerminiBySinonimo/termini/cliId
        [HttpPost]
        [Route("GetAllTerminiBySinonimo/{termini}/{cliId}")]
        public async Task<IActionResult> GetAllTerminiBySinonimo(string termini, string cliId, [FromBody]string[] sinonimoArray)
        {
            try
            {
                var terminiDtos =  await _terminiManager.GetAllTerminiBySinonimoData(sinonimoArray, termini, cliId);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "termini");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(terminiDtos);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get all termini by sinonimo");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }






        /// <summary>
        ///    To insert a new termini record 
        /// </summary>
        /// <param name="terminiDto">dto object of termini to be inserted by mapped with termini object in dal</param>
        /// <returns>general confirmation message</returns>
        // POST: api/termini/savetermini/
        [HttpPost]
        [Route("savetermini")]
        public async Task<IActionResult> InsertTermini(TerminiDto terminiDto)
        {
            try
            {
                // Checking whether the dto object is null or not.
                if (terminiDto == null)
                {
                    return NotFound();
                }
                await _terminiManager.InsertAsync(terminiDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "termini");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Insert new termini");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///    To get all termini Data based on client id.
        /// </summary>
        /// <param name="clientid">client id of the logged in user.</param>
        /// <param name="counter">defines the number of record should be skipped while retreiving by multiply with 500.</param>
        /// <returns>List object of termini</returns>
        //GET: api/termini/getterminis/clientid/counter.
        [HttpGet]
        [Route("GetTerminis/{clientid}/{counter}")]
        public async Task<IActionResult> GetAllTerminiByClientId(string clientid,int counter)
        {
            try
            {
                // Retrieving the termini list by providing client_id to the business layer.
                var terminiDtos = await _terminiManager.FindListAsync(clientid, counter);
                if (terminiDtos == null)
                {
                    return NotFound();
                }
                return Ok(terminiDtos);
            }
            catch (Exception x)
            {
                // Code block of Exception handling
                var result = new
                {
                    error = x.StackTrace,
                    error_type = x.InnerException,
                    message = x.Message
                };
                return BadRequest(result);
            }

        }


        /// <summary>
        ///     To get the details of a termini based on specific termini name and client id.
        /// </summary>
        /// <param name="termini">unique key of the table , through which specific termini data is benn retrieved.</param>
        /// <param name="clientid">client id of the logged in user.</param>
        /// <returns>termini object</returns>
        //GET: api/termini/getterminidetails/termini/cliId.
        [HttpGet]
        [Route("getterminidetails/{termini}/{cliId}")]
        public async Task<IActionResult> TerminiDetail(string termini, string cliId)
        {
            try
            {
                // Retrieving th termni details by passing the termini name and client id.;
                var terminiDtos = await _terminiManager.FindAsync(termini, cliId);
                if (terminiDtos == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "termini details");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(terminiDtos);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get termini detais");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }


        /// <summary>
        ///     To update the record of a specific termini.
        /// </summary>
        /// <param name="terminiDto">updated dto object of termini of bll , which will be updated by mapped with the termini object of dal.</param>
        /// <returns></returns>
        // PUT: api/termini/updatetermini/
        [HttpPut]
        [Route("updatetermini")]
        public async Task<IActionResult> PutTermini(TerminiDto terminiDto)
        {
            try
            {
                // Checking whether the dto object is null or not.
                if (terminiDto == null)
                {
                    return NotFound();
                }
                await _terminiManager.UpdateAsync(terminiDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "termini");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Update specific termini");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }
        /// <summary>
        ///    To get all the tipi termini based on client id 
        /// </summary>
        /// <param name="clientid">client id of the logged in user</param>
        /// <returns>List object of tipi termini</returns>
        //GET: api/termini/GetTipiTerminis/clientid
        [HttpGet]
        [Route("GetTipiTerminis/{clientid}")]
        public async Task<IActionResult> GetAllTipiTerminiByClientId(string clientid)
        {
            try
            {
                // Retrieving the list data by passing the client id to the business logic layer
                var data = await _terminiManager.FindByTipiTermineListAsync(clientid);
                if (data == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "tipi termini");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(data);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get tipi termini by client id");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        [HttpPost]
        [Route("GetNextTermini")]
        public async Task<IActionResult> GetNextTermini(TerminiDto terminiDto)
        {
            try
            {
                // Retrieving th termni details by passing the termini name and client id.;
                var terminiDtos = await _terminiManager.FindNextTerminiAsync(terminiDto);
                if (terminiDtos == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "next termini");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(terminiDtos);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get termini detais");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }
    }
}
