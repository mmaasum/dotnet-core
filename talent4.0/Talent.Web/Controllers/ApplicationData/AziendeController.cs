using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AziendeController : ControllerBase
    {
        private readonly IAziendeManager _aziendeManager;
        private readonly IAzioniManager _azioniManager;
        private readonly IUtilityManager _utilityManager;

        public AziendeController(IAziendeManager aziendeManager, IAzioniManager azioniManager, IUtilityManager utilityManager)
        {
            _aziendeManager = aziendeManager;
            _azioniManager = azioniManager;
            _utilityManager = utilityManager;
        }

        /// <summary>
        ///   To get the list of aziende having the provided siglaRichiesta
        /// </summary>
        /// <purpose>
        ///   This api is used to check whether the provided siglaRichiesta is exist or not to ensure the unique siglaRichiesta
        ///        while adding or updating Aziende
        /// </purpose>
        /// <param name="azid">the aziende id that need to be inserted or updated</param>
        /// <param name="azCliId">client id of logged in user</param>
        /// <param name="azSiglaRichiesta">provided by user</param>
        /// <returns>List of aziende, so that the user may know about the records which are having the provided siglaRichiesta</returns>
        //GET: api/aziende/FindBySiglaRichiestaData/azid/azCliId/azSiglaRichiesta
        [HttpGet]
        [Route("FindBySiglaRichiestaData/{azid}/{azCliId}/{azSiglaRichiesta}")]
        public async Task<IActionResult> FindBySiglaRichiestaData(int azid, string azCliId, string azSiglaRichiesta)
        {
            try
            {
                var aziendes = await _aziendeManager.FindBySiglaRichiestaData(azid, azCliId, azSiglaRichiesta);
                return Ok(aziendes);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Singla Richieste");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }



        /// <summary>
        ///     Get All Tipi Aziendi Data based on client id  
        /// </summary>
        /// <param name="cliId">client id of the logged in user</param>
        /// <returns>List of Tipi_Aziende</returns>
        //GET: api/aziende/GetAllTipiAzienda/cliId
        [HttpGet]
        [Route("GetAllTipiAzienda/{cliId}")]
        public async Task<IActionResult> GetAllTipiAzienda(string cliId)
        {
            try
            {
                var tipiAziendaDto = await _aziendeManager.GetAllTipiAziendaData(cliId);
                if (tipiAziendaDto == null)
                {
                    return NotFound();
                }
                return Ok(tipiAziendaDto);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get all Tipi_aziende");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }



        /// <summary>
        ///     Get All Aziendi Data based on the client id
        /// </summary>
        /// <param name="clientid">client id of the logged in user</param>
        /// /// <param name="counter">defines the number of rows to be skipped by multipying with 500</param>
        /// <returns>List of aziende</returns>
        //GET: api/aziende/getaziende/{clientid}/{counter}
        [HttpGet]
        [Route("GetAziende/{clientid}/{counter}")]
        public async Task<IActionResult> GetAziendeByCliId(string clientid,int counter=0)
        {
            try
            {
                //var aziendes = await _talentBllWrapper.AziendeiBll.GetAllAziendeDataByCliIdAsync(clientid,counter);
                var aziendes = await _aziendeManager.GetAziendeListByCliIdAsync(clientid,counter);
                if (aziendes == null)
                {
                    return NotFound();
                }
                return Ok(aziendes);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Aziende");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///     Get All Aziendi Data having two columns only based on client id
        /// </summary>
        ///  /// <param name="clientid">client id of the logged in user</param>
        /// <returns>List of Aziende having the azId and AzRagSociale column value</returns>
        //GET: api/aziende/getaziende/{clientid}
        [HttpGet]
        [Route("GetlistAziende/{clientid}")]
        public async Task<IActionResult> GetlistAziende(string clientid)
        {
            try
            {
                var aziendes = await _aziendeManager.GetOptimizedAziendeListByCliIdAsync(clientid);
                if (aziendes == null)
                {
                    return NotFound();
                }
                return Ok(aziendes);
            }
            catch (Exception x)
            {
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
        ///     Get the aziende details list of having sedi aziende based on specific azId and client id
        /// </summary>
        /// <param name="azid">unique id/key to retreive the details sedi list of it.</param>
        /// <param name="clientid">client id of the logged in user</param>
        /// <returns>List of sedi aziende details</returns>
        //GET: api/aziende/getaziende/{clientid}
        [HttpGet]
        [Route("GetSediAziende/{azid}/{clientid}")]
        public async Task<IActionResult> GetSediAziende(int azid,string clientid)
        {
            try
            {
                var aziendes = await _aziendeManager.AziendeDetails(azid,clientid);
                if (aziendes == null)
                {
                    return NotFound();
                }
                return Ok(aziendes);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Sedi Aziende");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }


        /// <summary>
        ///     To insert new aziende data
        /// </summary>
        /// <param name="aziendeDto">Dto object of aziende, which need to be inserted by mapped with aziende object of dal.</param>
        /// <returns>recently added/inseted aziende object</returns>
        // PUT: api/aziende/updateaziende/
        [HttpPost]
        [Route("postaziende")]
        public async Task<IActionResult> PostAziende(AziendeDto aziendeDto)
        {
            try
            {
                if (aziendeDto == null)
                {
                    return NotFound();
                }
                var azid =  await _aziendeManager.InsertAziende(aziendeDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "aziende");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                aziendeDto.AzId = azid;
                return Ok(aziendeDto);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Insert Aziende");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To update the provided aziende
        /// </summary>
        /// <param name="aziendeDto">Dto object of aziende, which need to be updated by synced with aziende object of dal.</param>
        /// <returns>recently updated aziende id</returns>
        // PUT: api/aziende/updateaziende/
        [HttpPut]
        [Route("updateaziende")]
        public async Task<IActionResult> PutAziende(AziendeDto aziendeDto)
        {
            try
            {
                if (aziendeDto == null)
                {
                    return NotFound();
                }

                await _aziendeManager.UpdateAziende(aziendeDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "aziende");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Update Aziende");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

    }
}
