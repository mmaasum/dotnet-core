using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers.ApplicationData
{
    [Route("api/[controller]")]
    [ApiController]
    public class RichiesteController : ControllerBase
    {

        private readonly IAzioniManager _azioniManager;
        private readonly IRichiesteManager _richiesteManager;
        private readonly IUtilityManager _utilityManager;

        public RichiesteController(IAzioniManager azioniManager, IRichiesteManager richiesteManager, IUtilityManager utilityManager)
        {
            _azioniManager = azioniManager;
            _richiesteManager = richiesteManager;
            _utilityManager = utilityManager;
        }


        [HttpGet]
        [Route("GetStatiRichListRisDescr/{langName}")]
        public async Task<IActionResult> GetStatiRichListRisDescr(string langName)
        {
            try
            {
                var data = await _richiesteManager.GetStatiRichListRisDescrAsync(langName);

                // creating the azioni object passing the related details and description.
                var azioniDto =  _utilityManager.GetAzioniDtoObject(User, "get", "Stati_Rich_List_Ris_Descr");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Stati_Rich_List_Ris_Descr");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }



        [HttpGet]
        [Route("GetAllCompetenzaByCliId/{clientid}")]
        public async Task<IActionResult> GetAllCompetenzaByCliId(string clientid)
        {
            try
            {
                var data = await _richiesteManager.GetAllCompetenzaByCliIdAsync(clientid);
                return Ok(data);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Competenza");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        [HttpGet]
        [Route("GetAllCittaByCliId/{clientid}")]
        public async Task<IActionResult> GetAllCittaByCliId(string clientid)
        {
            try
            {
                var data = await _richiesteManager.GetAllCittaByCliIdAsync(clientid);
                return Ok(data);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Citta");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To create a new richieste having all the data same as existing one.
        ///     By cloning 2 richieste have only different richId.
        /// </summary>
        /// <param name="richid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("clonerichieste/{richid}")]
        public async Task<IActionResult> CloneRichieste(string richid)
        {
            try
            {
                // Retreiving the newly created richieste object from bll.
                var data = await _richiesteManager.CloneAsync(richid);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "richiste clone");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Insert new Richieste (clone)");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///     To create a new richieste
        /// </summary>
        /// <param name="richiesteDto">Data Template Object of richieste</param>
        /// <returns></returns>
        [HttpPost]
        [Route("insertrichieste")]
        public async Task<IActionResult> InsertRichieste([FromBody] RichiesteDto richiesteDto)
        {
            try
            {
                // Retreiving the newly created richieste object from bll.
                var categories = await _richiesteManager.InsertAsync(User, richiesteDto);
                // Null Exception handling code block
                if (categories == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "richieste");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);

                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Insert new Richieste");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///      To update an exisiting richieste.
        /// </summary>
        /// <param name="richiesteDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updaterichieste")]
        public async Task<IActionResult> UpdateRuolo([FromBody] RichiesteDto richiesteDto)
        {
            try
            {
                // Retreiving the newly updated richieste object from bll.
                await _richiesteManager.UpdateAsync(User, richiesteDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "richieste");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Update Richiese");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get all richieste data from richieste table based on client id
        /// </summary>
        /// <param name="clientid">client id of logged in user</param>
        /// <param name="counter">Counter multiply with 500 and defines the result to be skipped while loading </param>
        /// <returns>List object of richiesta</returns>
        // GET: api/Richieste/getrichieste/clientid/counter
        [HttpGet]
        [Route("getrichieste/{clientid}/{counter}")]
        public async Task<IActionResult> GetAllRichiesteByClientId(string clientid, int counter)
        {
            try
            {
                var data = await _richiesteManager.FindAllByCliIdAsync(clientid, counter);
                return Ok(data);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Richieste");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///     To get the details of a specific richiesta based on provided richiesta id
        /// </summary>
        /// <param name="richid">unique identity of richiesta table.</param>
        /// <returns>Object of richiesta </returns>
        // GET: api/Richieste/getrichieste/richid
        [HttpGet]
        [Route("getdetailrichieste/{richid}")]
        public async Task<IActionResult> GetRichiesteByRichId(string richid)
        {
            try
            {
                var data = await _richiesteManager.FindByRichIdAsync(richid);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "richiese based on rich id");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(data);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Richieste details");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get the matching richieste list data based on provided rich_id and client id
        /// </summary>
        /// <param name="richid">selected rich id of the richieste list.</param>
        /// <param name="cliId">client id of the logged in user.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("MatchingRichieste/{richid}/{cliId}/{status}")]
        public async Task<IActionResult> MatchingRichieste(string richid, string cliId, int status)
        {
            try
            {
                var data = await _richiesteManager.MatchingRichiesteAsync(richid, cliId, status);
                if (data == null)
                {
                    return null;
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "matching richiese");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(data);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Matching Richieste");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }




        [HttpGet]
        [Route("MatchingRichiesteByRisIdList/{richid}/{cliId}")]
        public async Task<IActionResult> MatchingRichiesteByRisIdList(string richid, string cliId, int[] richlistRisIdList)
        {
            try
            {
                var data = await _richiesteManager.GetMatchingRichiesteListByRisIdAsync(richid, cliId, richlistRisIdList);
                if (data == null)
                {
                    return null;
                }

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "mathing richieste");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Matching Richieste");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }







        [HttpGet]
        [Route("CountFindByRichlistRisorse/{richId}/{risId}/{cliId}")]
        public async Task<IActionResult> CountFindByRichlistRisorse(string richId, int risId, string cliId)
        {
            try
            {

                int count = await _richiesteManager.CountFindByRichlistRisorseAsync(richId, risId, cliId);

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "count richieste_lista_risorse");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(new { count = count });
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Count richieste_lista_risorse");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        [HttpPost]
        [Route("InsertRichlistRisorse")]
        public async Task<IActionResult> InsertRichlistRisorse(RichiesteListaRisorseDto richiesteListaRisorseDto)
        {
            try
            {

                if (richiesteListaRisorseDto == null)
                {
                    return NotFound();
                }
                await _richiesteManager.InsertRichlistRisorseAsync(richiesteListaRisorseDto, User);


                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "richieste_lista_risorse");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Insert richieste_lista_risorse");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///   To update the richlist_voto data of [richieste_lista_risorse] table based on 
        ///   richlistrisorseDto object data.
        /// </summary>
        /// <param name="richiesteListaRisorseDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateRichlistRisorse")]
        public async Task<IActionResult> UpdateRichlistRisorse(RichiesteListaRisorseDto richiesteListaRisorseDto)
        {
            try
            {

                if (richiesteListaRisorseDto == null)
                {
                    return NotFound();
                }
                await _richiesteManager.UpdateRichlistRisorseAsync(richiesteListaRisorseDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "richieste_lista_risorse");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Update richieste_lista_risorse");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        [HttpPost]
        [Route("ManageTalentRichlistRisorse")]
        public async Task<IActionResult> ManageTalentRichlistRisorse([FromBody]RichiesteListaRisorseDto richiesteListaRisorseDto)
        {
            try
            {
                int count = await _richiesteManager.CountFindByTalentRichlistRisorseAsync
                                                                    (richiesteListaRisorseDto.RichlistRichId,
                                                                     richiesteListaRisorseDto.RichlistRisId, User);

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "count talent_rich_lista_risorse");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);

                if (count == 0)
                {
                    var data = InsertTalentRichlistRisorse(richiesteListaRisorseDto);
                    return Ok();

                }
                else
                {
                    var data = InsertTalentRichlistRisorse(richiesteListaRisorseDto);
                    return Ok();
                }
               
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Count talent_rich_lista_risorse");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///   To insert the trichlist_stato into [talent_richieste_lista_risorse] table 
        ///   same as [richieste_lista_risorse] record 
        /// </summary>
        /// <param name="richiesteListaRisorseDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertTalentRichlistRisorse")]
        public async Task<IActionResult> InsertTalentRichlistRisorse(RichiesteListaRisorseDto richiesteListaRisorseDto)
        {
            try
            {
                if (richiesteListaRisorseDto == null)
                {
                    return NotFound();
                }

                await _richiesteManager.InsertTalentRichlistRisorseAsync(richiesteListaRisorseDto, User);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "talent_richieste_lista_risorse");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Insert Talent_Richlist_Risorse");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        [HttpPost]
        [Route("UpdateTalentRichlistRisorse")]
        public async Task<IActionResult> UpdateTalentRichlistRisorse(RichiesteListaRisorseDto richiesteListaRisorseDto)
        {
            try
            {
                if (richiesteListaRisorseDto == null)
                {
                    return NotFound();
                }

                await _richiesteManager.UpdateTalentRichlistRisorseAsync(richiesteListaRisorseDto, User);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "talent_rich_lista_risorse");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Update Talent_Richlist_Risorse");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }






    }
}
