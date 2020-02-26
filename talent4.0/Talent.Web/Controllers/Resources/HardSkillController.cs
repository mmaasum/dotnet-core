using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers.Resources
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardSkillController : ControllerBase
    {
        private readonly IAzioniManager _azioniManager;
        private readonly IEmailManager _emailManager;
        private readonly IHardSkillManager _hardSkillManager;
        private readonly IUtilityManager _utilityManager;
        

        public HardSkillController(IAzioniManager azioniManager, IEmailManager emailManager, IHardSkillManager hardSkillManager, IUtilityManager utilityManager)
        {
            _azioniManager = azioniManager;
            _emailManager = emailManager;
            _hardSkillManager = hardSkillManager;
            _utilityManager = utilityManager;
        }


        [HttpGet]
        [Route("GetMailModelObj/{langName}")]
        public async Task<IActionResult> GetMailModelObj(string langName)
        {
            try
            {
                // retrieving the list of data by passing the ris_id
                var categories = await _hardSkillManager.GetMailModelAsync(User,langName);
                if (categories == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "mail model data");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Mail Mail Model Data");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }



        /// <summary>
        ///  To get the list of hard skill based on selected ris_id
        /// </summary>
        /// <param name="risId">unique key of a risorse record that to be passed to retrieve hard skill list</param>
        /// <returns>List object of hard skill</returns>
        [HttpGet]
        [Route("GetHardSkill/{risId}")]
        public async Task<IActionResult> GetHardSkill(int risId)
        {
            try
            {
                // retrieving the list of data by passing the ris_id
                var categories = await _hardSkillManager.GetHardSkillAsync(risId);
                if (categories == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "hard skill");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Hard skill");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get all the competenza based on the logged in client id
        /// </summary>
        /// <param name="clientId">client id of the logged in user</param>
        /// <returns>List object of competenza</returns>
        [HttpGet]
        [Route("GetAllCompetenza/{clientId}")]
        public async Task<IActionResult> GetAllCompetenza(string clientId)
        {
            try
            {
                // retrieving the list data by passing the client id to the business logic layer
                var categories = await _hardSkillManager.GetAllCompetenzaAsync(clientId);
                if (categories == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "all competenza");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get all competenza");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///     To get all the test_valutazione based on the provided competenza
        ///     and client id of the logged in user.
        /// </summary>
        /// <param name="competenza">Selected competenza from the list</param>
        /// <param name="clientId">client id of the logged in user.</param>
        /// <returns>List data of test_valitazione</returns>
        [HttpPost]
        [Route("GetAllTestValutazione/{clientId}")]
        public async Task<IActionResult> GetAllTestValutazione([FromBody] TestCompetenzeDto competenze, string clientId)
        {
            try 
            {
                // passing the competenza and client id to business logic layer to retreive the list data.
                var categories = await _hardSkillManager.GetAllTestValutazioneAsync(competenze.TscompCompetenza,clientId);
                if (categories == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "TestValutazione");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                // returning the list data having the ok status
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get all TestValutazione");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To send the invitation regarding hardskill to risorse
        /// </summary>
        /// <param name="testValutazioneDto">contain the title and exam link</param>
        /// <param name="risId">unique id of a specific risore</param>
        /// <param name="clientId">client id of the logged in user</param>
        /// <returns></returns>
        [HttpPost]
        [Route("SendHardSkillInvitation/{risId}/{clientId}")]
        public async Task<IActionResult> SendHardSkillInvitation([FromBody]string[] titoloList, int risId, string clientId)
        {
            try
            {
                // Retrieving the dto object that contain the mail address and mail body
                // which is required to send the mail to the specific risorse.

                var categories = await _hardSkillManager.SendHardSkillInvitationAsync(titoloList,risId,clientId);
                if (categories == null)
                {
                    return NotFound();
                }

                List<string> emailList = categories.Email.Split(';').ToList<string>();
                emailList.Reverse();
                // Sending Invitation to the specific resource mail
                foreach (var email in emailList)
                {
                    // Initiating the mail address
                   _emailManager.To.Add(email);
                }
                // Initiating the mail subject
                _emailManager.Subject = "Talent: Hard Skill";
                // Initiating the mail body
                _emailManager.Body = categories.EmailBody.ToString();
                // Sending the mail to the specific recipient
                _emailManager.Send();
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "email", "send hard skill invitation");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Send Hard skill invitation");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///     To get the list of test_valutazione which are mandatory.
        /// </summary>
        /// <param name="risId">ris_id of the selected risorse.</param>
        /// <param name="clientId">client id of the selected risorse.</param>
        /// <param name="type">type of test_valutazione. Here which is mandatory.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMandatoryTestValutazione/{clientId}/{risId}/{type}")]
        public async Task<IActionResult> GetTestValutazioneDataByType(int risId, string clientId, string type)
        {
            try
            {
                // passing the competenza and client id to business logic layer to retreive the list data.
                var categories = await _hardSkillManager.GetTestValutazioneDataByTypeAsync(risId,clientId,type);
                // Handling Null Exception Reference.
                if (categories == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "mandatory TestValutazione");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                // returning the list data having the ok status
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get mandatory TestValutazione");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }
    }
}