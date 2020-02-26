using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.Common.Enums;

namespace Talent.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzioniController : ControllerBase
    {
        private readonly IAzioniManager _azioniManager;
        private readonly IUtilityManager _utilityManager;
        private readonly IDifferentListManager _differentListManager;

        public AzioniController(IAzioniManager azioniManager, 
                                IUtilityManager utilityManager,
                                IDifferentListManager differentListManager)
        {
            _azioniManager = azioniManager;
            _utilityManager = utilityManager;
            _differentListManager = differentListManager;
        }


        [HttpGet]
        [Route("getallazionitype/{language}")]
        public async Task<IActionResult> GetAllAzioniType(SupportedLanguage language)
        {
            try
            {
                //var categories = await _azioniManager.GetAllTipiAzione();
                var categories = await _differentListManager.GetAllAzioniTypeDescriptionAsync(language);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get Last Login Info Azioni");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }



        ////`
        /// <summary>
        // 
        /// 

        /// 
        /// </summary>


        [HttpGet]
        [Route("getsecondlastazioni/{cliId}/{uteId}")]
        public async Task<IActionResult> GetSecondLastAzioni(string cliId, string uteId)
        {
            try
            {
                var categories = await _azioniManager.GetAzioniData(cliId, uteId, 1);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x) 
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Last Login Info Azioni");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///     Get All Azioni Data regardless Client Id 
        /// </summary>
        /// <purpose>
        ///     Get the list of azioni, so user may find ones own required data.
        /// </purpose>
        /// <returns>List Data</returns>


        /// <summary>
        ///   Get All Azioni Data based on Client Id and counter.
        /// </summary>
        /// <purpose>
        ///    Get all the data having the provided client id and 'nextCount' indicating which 500 hundred
        ///     rows shoule be retreived.
        /// </purpose>
        /// /// <param name="clientId">Client Id</param>
        /// <param name="nextCount">The counter that indicates the phase of regtrived data 500 hundread each time</param>
        /// <returns>List Data</returns>


        [HttpPost]
        [Route("postAzioni")]
        public async Task<IActionResult> postAzioni([FromBody] AzioniDto azioniDto)
        {
            try
            {
                if (azioniDto == null)
                {
                    return NotFound();
                }
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Insert Azioni");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }
    }
}
