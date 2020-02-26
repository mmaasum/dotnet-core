using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OperazioniController : ControllerBase
    {

        private readonly IAzioniManager _azioniManager;
        private readonly IOperazioniManager _operazioniManager;
        private readonly IUtilityManager _utilityManager;

        public OperazioniController(IAzioniManager azioniManager, IOperazioniManager operazioniManager, IUtilityManager utilityManager)
        {
            _azioniManager = azioniManager;
            _operazioniManager = operazioniManager;
            _utilityManager = utilityManager;
        }


        /// <summary>
        ///     To Get All log record of operazioni
        /// </summary>
        /// <returns>List object of operazione</returns>
        //GET: api/operazioni/getlogoperazioni
        [HttpGet]
        [Route("Operazioni/GetLogOperazioni")]
        public async Task<IActionResult> LogOperations()
        {
            try
            {
                var logOperazionis = await _operazioniManager.GetAllLogOperazioniData();
                if (logOperazionis == null)
                {
                    return NotFound();
                }
                return Ok(logOperazionis);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Log Operazioni");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     Get All log record of operazioni by client id.
        /// </summary>
        /// <param name="clientid">client id of the logged in user</param>
        /// <param name="counter">Counter multiply with 500 and defines the result to be skipped while loading </param>
        /// <returns>List object of log operazioni</returns>
        //GET: api/operazioni/getlogoperazioni/{clientid}
        [HttpGet]
        [Route("Operazioni/GetLogOperazioni/{clientid}/{counter}")]
        public async Task<IActionResult> LogOperationsByClientId(string clientid,int counter)
        {
            try
            {
                var logOperazionis = await _operazioniManager.GetAllLogOperazioniDataByCliId(clientid, counter);
                if (logOperazionis == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "log operazioni");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(logOperazionis);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Log Operazioni based on client id");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }

        /// <summary>
        ///     Insert new log operazioni data 
        /// </summary>
        /// <param name="description">description of the operazione</param>
        /// <param name="details">details of the operazione</param>
        /// <param name="clientId">client id of the logged in user</param>
        /// <returns>general success message</returns>
        // POST: api/operazioni/submitlogoperazioni
        [HttpPost]
        [Route("robot/SubmitLogOperazioni")]
        public async Task<IActionResult> LogSubmit(LogOperazioniDto logOperazioniDto)
        {
            try
            {
                await _operazioniManager.LogOperazioniInsert(logOperazioniDto);
                // creating the azioni object passing the related details and description. 
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "log operazioni");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Submit Log Operazioni");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }
    }
}
