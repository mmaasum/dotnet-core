using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers.ApplicationData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientFinaleController : ControllerBase
    {
        // Creating the readonly object of talent business layer wrapper class.
        private readonly IAzioniManager _azioniManager;
        private readonly IClientFinaleManager _clientFinaleManager;
        private readonly IUtilityManager _utilityManager;

        public ClientFinaleController(IAzioniManager azioniManager, IClientFinaleManager clientFinaleManager, IUtilityManager utilityManager)
        {
            _azioniManager = azioniManager;
            _clientFinaleManager = clientFinaleManager;
            _utilityManager = utilityManager;
        }


        [HttpGet]
        [Route("GetOptimizedAziendeClientiFinaleByAzId/{azId}")]
        public async Task<IActionResult> GetOptimizedAziendeClientiFinaleByAzId(int azId)
        {
            try
            {
                // retrieving the list of data by passing the az_id
                var categories = await _clientFinaleManager.GetFindAllByOptimizedAziendeClienteFinale(User,azId);
                if (categories == null)
                {
                    // Returning 404 error for null.
                    return NotFound();
                }
                // Retrurning success code along with the retrieved data.
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get all aziende_client_finale");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///     To get all the aziende client finale data based on az_id and client id
        /// </summary>
        /// <param name="azId">selected unique id of aziende record.</param>
        /// <param name="clientId">client id of the logged in user.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllAziendeClientiFinaleByAzId/{clifinAzId}")]
        public async Task<IActionResult> GetAllAziendeClientiFinaleByAzId(int clifinAzId)
        {
            try
            {
                // retrieving the list of data by passing the az_id
                var categories = await _clientFinaleManager.GetAllData(clifinAzId);
                if (categories == null)
                {
                    // Returning 404 error for null.
                    return NotFound();
                }
                // Retrurning success code along with the retrieved data.
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get all aziende_client_finale");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///     To create a new aziende client finale record.
        /// </summary>
        /// <param name="aziendeClientiFinaleDto">
        ///     dto object that contains all the data to store a aziende client finale record in database.
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertAziendeClientiFinale")]
        public async Task<IActionResult> InsertAziendeClientiFinale([FromBody] AziendeClientiFinaleDto aziendeClientiFinaleDto)
        {
            // Implementing try-catch block.
            try
            {
                // Checking whether the form data is null
                if (aziendeClientiFinaleDto == null)
                {
                    // Returning 404 error for null
                    return NotFound();
                }
                // calling the insert method of bll that will pass the object to dal 
                // to create a new aziende client finale.
                var returnedId = await _clientFinaleManager.InsertData(aziendeClientiFinaleDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "aziende_client_finale");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(returnedId);
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
        ///     To update an existing aziende client finale record.
        /// </summary>
        /// <param name="aziendeClientiFinaleDto">updated object which need to be replaced with the current one.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateAziendeClientiFinale")]
        public async Task<IActionResult> UpdateAziendeClientiFinale([FromBody] AziendeClientiFinaleDto aziendeClientiFinaleDto)
        {
            try
            {
                // Checking whether the updatable object is null
                if (aziendeClientiFinaleDto == null)
                {
                    // Return 404 error for null data.
                    return NotFound();
                }
                // Calling the update metho of bll which will pass the object to the dal
                //         to update the record in the database.
                await _clientFinaleManager.UpdateData(aziendeClientiFinaleDto);

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "aziende_client_finale");
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


        [HttpGet]
        [Route("FindAziendeClienteFinaleByClifinId/{clifinId}")]
        public async Task<IActionResult> FindAziendeClienteFinaleByClifinId(int clifinId)
        {
            try
            {
                // retrieving the list of data by passing the az_id
                var categories = await _clientFinaleManager.FindByClifinIdData(clifinId);
                if (categories == null)
                {
                    // Returning 404 error for null.
                    return NotFound();
                }
                // Retrurning success code along with the retrieved data.
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get specific aziende_client_finale");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


    }
}