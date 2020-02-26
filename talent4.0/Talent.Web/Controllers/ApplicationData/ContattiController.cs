using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers.ApplicationData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContattiController : ControllerBase
    {

        private readonly IAzioniManager _azioniManager;
        private readonly IContattiManager _contattiManager;
        private readonly IEmailManager _emailManager;
        private readonly IUtilityManager _utilityManager;

        public ContattiController(IAzioniManager azioniManager, IContattiManager contattiManager, IEmailManager emailManager, IUtilityManager utilityManager)
        {
            _azioniManager = azioniManager;
            _contattiManager = contattiManager;
            _emailManager = emailManager;
            _utilityManager = utilityManager;
        }


        [HttpGet]
        [Route("GetFindByAllContattiByContAzSedeId/{contAzSedeId}")]
        public async Task<IActionResult> GetFindByAllContattiByContAzSedeId(int contAzSedeId)
        {
            try
            {
                var data = await _contattiManager.GetFindByAllContattiByContAzSedeIdAsync(User, contAzSedeId);
                if (data == null)
                {
                    return NotFound();
                }

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "tipi contatto");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(data);
            }
            catch (Exception x)
            {
                
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Tipi Contatto");
                // Returning the error object.
                return BadRequest(errorObj);
            }


        }


        /// <summary>
        ///     Get all contatti by aziende id.
        /// </summary>
        /// <param name="azId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllContattiByAzId/{azId}")]
        public async Task<IActionResult> GetAllContattiByAzId(int azId)
        {
            try
            {
                var data = await _contattiManager.FindAllContattiByContAzIdAsync(User, azId);
                if (data == null)
                {
                    return NotFound();
                }

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "tipi contatto");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(data);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Tipi Contatto");
                // Returning the error object.
                return BadRequest(errorObj);
            }


        }

        /// <summary>
        ///     To get the list of all tipi contatto based on client id
        /// </summary>
        /// <param name="clientid">client id of the logged in user</param>
        /// <returns>List object of tipi contattos</returns>
        // GET: api/Contatti/Gettipicontatto/clientid
        [HttpGet]
        [Route("Gettipicontatto/{clientid}")]
        public async Task<IActionResult> GetTipiContattoByClientId(string clientid)
        {
            try
            {
                var data = await _contattiManager.GetAllTipiContattoDataByCliIdAsync(clientid);
                if (data == null)
                {
                    return NotFound();
                }

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "tipi contatto");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(data);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Tipi Contatto");
                // Returning the error object.
                return BadRequest(errorObj);
            }


        }


        /// <summary>
        ///     To insert the new contatti record
        /// </summary>
        /// <param name="contattiDto">Dto object of contatti, which will be stored/inserted by mapped with contatti object.</param>
        /// <returns>recently changed contatti object</returns>
        // GET: api/Contatti/postcontatti
        [HttpPost]
        [Route("postcontatti")]
        public async Task<IActionResult> PostContatti(ContattiDto contattiDto)
        {
            try
            {
                if (contattiDto == null)
                {
                    return NotFound();
                }
                var id = await _contattiManager.InsertAsync(contattiDto);
                contattiDto.ContId = id;
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "contatti");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(contattiDto);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Save Contatti");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }


        /// <summary>
        ///  To update a conttati record
        /// </summary>
        /// <param name="contattiDto">Dto object of contatti which will be updated by mapping with the contatti object</param>
        /// <returns>general confirmation message</returns>
        [HttpPut]
        [Route("updatecontatti")]
        public async Task<IActionResult> PutContatti(ContattiDto contattiDto)
        {
            try
            {
                if (contattiDto == null)
                {
                    return NotFound();
                }
                await _contattiManager.UpdateAsync(contattiDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "contatti");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Update Contatti");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }



        /// <summary>
        ///     Send mail according to mail body and email id
        /// </summary>
        /// <param name="mailContattiDto">Dto object of mail that contain mail address and mail body</param>
        /// <returns>general success message</returns>
        //     POST: api/Contatti/EmailContatti
        [HttpPost]
        [Route("emailcontatti")]
        public async Task<IActionResult> EmailContatti([FromBody] MailContattiDto mailContattiDto)
        {
            try
            {
                if (mailContattiDto == null)
                {
                    return NotFound();
                }
                // Sending email to the specific resource mail
                _emailManager.To.Add(mailContattiDto.Email);
                _emailManager.Subject = "Talent_Contatti";
                _emailManager.Body = mailContattiDto.Body;
                _emailManager.Send();

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "email", "contatti");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Send Email Contatti");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }
    }
}
