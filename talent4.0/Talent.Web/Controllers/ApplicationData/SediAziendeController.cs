using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers.ApplicationData
{
    [Route("api/[controller]")]
    [ApiController]
    public class SediAziendeController : ControllerBase
    {

        private readonly IAzioniManager _azioniManager;
        private readonly ISediAziendeManager _sediAziendeManager;
        private readonly IUtilityManager _utilityManager;

        public SediAziendeController(IAzioniManager azioniManager, ISediAziendeManager sediAziendeManager, IUtilityManager utilityManager)
        {
            _azioniManager = azioniManager;
            _sediAziendeManager = sediAziendeManager;
            _utilityManager = utilityManager;
        }


        [HttpGet]
        [Route("FindSediAziendeBySedeId/{sedeId}")]
        public async Task<ActionResult> FindSediAziendeBySedeId(int sedeId)
        {
            try
            {
                var sediAziende = await _sediAziendeManager.FindBySedeIdAsync(sedeId);
                if (sediAziende == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "Sedi Aziende");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(sediAziende);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Sedi Aziende");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        [HttpGet]
        [Route("GetAllSediAziendeByAzSedeAzId/{azSedeAzId}")]
        public async Task<ActionResult> GetAllSediAziendeByAzSedeAzId(int azSedeAzId)
        {
            try
            {
                var sediAziendeList = await _sediAziendeManager.GetAllByAzSedeAzIdAsync(azSedeAzId);
                if (sediAziendeList == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "Sedi Aziende by AzSedeId");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(sediAziendeList);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get All Sedi Aziende by azSedeId");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        [HttpGet]
        [Route("GetAllSediAziende/{clientId}")]
        public async Task<ActionResult> GetAllSediAziende(string clientId)
        {
            try
            {
                var sediAziendeList = await _sediAziendeManager.GetAllAsync(clientId);
                if (sediAziendeList == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "Sedi Aziende by client id");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(sediAziendeList);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get All Sedi Aziende by client id");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        [HttpPost]
        [Route("InsertSediAziende")]
        public async Task<IActionResult> InsertSediAziende([FromBody] SediAziendeDto sediAziendeDto)
        {
            // Implementing try-catch block.
            try
            {
                // Checking whether the form data is null
                if (sediAziendeDto == null)
                {
                    // Returning 404 error for null
                    return NotFound();
                }
                // calling the insert method of bll that will pass the object to dal 
                // to create a new sedi aziende.
                var returnedId = await _sediAziendeManager.InsertAsync(sediAziendeDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "sedi_aziende");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(returnedId);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Insert new Sedi Aziende");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        [HttpPut]
        [Route("UpdateSediAziende")]
        public async Task<IActionResult> UpdateSediAziende([FromBody] SediAziendeDto sediAziendeDto)
        {
            try
            {
                // Checking whether the updatable object is null
                if (sediAziendeDto == null)
                {
                    // Return 404 error for null data.
                    return NotFound();
                }
                // Calling the update metho of bll which will pass the object to the dal
                // to update the record in the database.
                var returnedId = await _sediAziendeManager.UpdateAsync(sediAziendeDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "sedi_aziende");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(returnedId);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Update Sedi Aziende");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

    }
}