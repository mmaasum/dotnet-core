using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Talent.BLL.DTO;
using Talent.DataModel.DataModels;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers.Resources
{
    [Route("api/[controller]")]
    [ApiController]
    public class RisorseController : ControllerBase
    {

        private readonly IAzioniManager _azioniManager;
        private readonly IContattiManager _contattiManager;
        private readonly IEmailManager _emailManager;
        private readonly IRichiesteManager _richiesteManager;
        private readonly IRisorseManager _risorseManager;
        private readonly IUtilityManager _utilityManager;

        public RisorseController(IAzioniManager azioniManager, IContattiManager contattiManager, IEmailManager emailManager, IRichiesteManager richiesteManager, IRisorseManager risorseManager, IUtilityManager utilityManager)
        {
            _azioniManager = azioniManager;
            _contattiManager = contattiManager;
            _emailManager = emailManager;
            _richiesteManager = richiesteManager;
            _risorseManager = risorseManager;
            _utilityManager = utilityManager;
        }




        /// <summary>
        ///     To create a new richieste
        /// </summary>
        /// <param name="richiesteDto">Data Template Object of risorse</param>
        /// <returns></returns>
        [HttpPost]
        [Route("insertrisorse")]
        public async Task<IActionResult> InsertRisorse([FromBody] RisorseDto risorseDto)
        {
            try
            {
                // Retreiving the newly created richieste object from bll.
                var categories = await _risorseManager.InsertAsync(User, risorseDto);
                // Null Exception handling code block
                if (categories == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "risorse");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);

                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Insert new Risorse");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///      To update an exisiting risorse.
        /// </summary>
        /// <param name="richiesteDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updaterisorse")]
        public async Task<IActionResult> UpdateRiosorse([FromBody] RisorseDto risorseDto)
        {
            try
            {
                // Retreiving the newly updated risorse object from bll.
                await _risorseManager.UpdateAsync(User, risorseDto);
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "risorse");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Update Risorse");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get all the risorse data based on client id
        /// </summary>
        /// <param name="clientId">client id of the logged in user.</param>
        /// <param name="nextCount"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllRisorse/{clientid}/{nextCount}")]
        public async Task<IActionResult> GetAllRisorse(string clientId, int nextCount = 0)
        {
            try
            {
                // Fetching data from bll
                var categories = await _risorseManager.GetAllAsync(clientId, nextCount);
                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Risorse");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get the CV file of a specific risorse retrieved by ris_id
        /// </summary>
        /// <param name="risId">selected unique id of a risorse record</param>
        /// <returns>File Object.</returns>
        [HttpGet]
        [Route("GetRisorseCV/{risId}")]
        public async Task<IActionResult> GetRisorseCV(int risId)
        {
            try
            {
                // Retrieving the CV file from business logic layer provided by ris_id
                var risorseDto = await _risorseManager.GetCvInfoAsync(risId);
                if (risorseDto == null)
                {
                    return NotFound();
                }

                // Defining the file mimetype based on file name.
                var mimeType = GetFileMimeType(risorseDto.RisCvNomeFile);
                // Setting the file name having the current date as prefix.
                var fileName = DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + risorseDto.RisCvNomeFile ;

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "risorse CV file");
                // logging the activity record by the user.
                // await _talentBllWrapper.AzuiniBll.AzioniInsert(azioniDto);

                // Returning the file along with the mimeType and file name.
                return File(risorseDto.RisCvAllegato, mimeType, fileName);
            }

            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Risorse CV file");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get the details of a risorse record based on ris_id
        /// </summary>
        /// <param name="risId">unique id of risorse that need to be passed to retreive specific risorse details.</param>
        /// <returns>Single risorse object.</returns>
        [HttpGet]
        [Route("GetRisorseDetails/{risId}")]
        public async Task<IActionResult> GetRisorseDetails(int risId)
        {
            try
            {
                // Retrieving the risrose details from bll.
                var risorseDto = await _risorseManager.GetDetailAsync(risId);
                if (risorseDto == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "risorse details");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                // Returning the risorse object.
                return Ok(risorseDto);
            }

            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Risorse details");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To call the store procedure to launch risorse.
        /// </summary>
        /// <param name="richId">selected rich_id of the list.</param>
        /// <param name="cvInviati">static data.</param>
        /// <param name="clientId">client id of the logged in user.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("LaunchRisorseSP/{richId}/{cvInviati}/{clientId}")]
        public async Task<IActionResult> LaunchRisorseSP(string richId, string cvInviati, string clientId)
        {
            try
            {
                var categories = await _risorseManager.LaunchRisorseSPBl(richId, cvInviati, clientId);
                if (categories == null)
                {
                    return NotFound();
                }
                else
                {
                    //// Sending data to match richieste.
                    //var data = _talentBllWrapper.RichiesteBll.MatchingRichiesteAsync(richId, clientId, -1);
                    //// Handling Null reference exception.
                    //if (data == null)
                    //{
                    //    return null;
                    //}

                    // creating the azioni object passing the related details and description.
                    var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "launch SP");
                    // logging the activity record by the user.
                    await _azioniManager.AzioniInsert(azioniDto);
                    return Ok(new { status = "ok" });
                }
               
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Launch Risorse_SP");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///     To launch/call the machine learning API developed by the vendor.
        /// </summary>
        /// <param name="richId">selected rich_id of the list.</param>
        /// <param name="clientId">client id of the logged in user.</param>
        /// <returns>Returns the matching richieste by providing the retrieved ris_id list from the API</returns>
        [HttpGet]
        [Route("LaunchMachineLearning/{richId}/{clientId}")]
        public async Task<ActionResult> LaunchMachineLearning(string richId, string clientId)
        {

            try
            {
                // Creating the empty list of ris_id
                List<int> risIdList = new List<int>();

                // Creating the custom object to pass as the body to call the API.
                LaunchMLBody launchMLBody = new LaunchMLBody
                {
                    // Initaiting the static value of id_model
                    id_model = "six_generations",
                    // Initaiting the static value of filter_level
                    candidates_filter_level = "cv inviati",
                    // Initaiting the static value of n_candidtates.
                    n_candidates = 100
                };

                // creating the object of HTTPClient.
                var client = new HttpClient();
                // Initiating the base address of the API where the API is hosted.
                client.BaseAddress = new Uri("http://192.168.1.135:5000/");


                var asssc  = AppSettingsDto.HostName;
                var h = AppSettingsDto.APIDomainName;

                client.BaseAddress = new Uri(AppSettingsDto.APIDomainName);                

                // Converting the custom message bosy object to JSon object.
                string message = JsonConvert.SerializeObject(launchMLBody);

                // Declaring and initiating the request to call the API.
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "api/jobs/" + richId + "/rankings");
                // Initiating the post bosy into the content
                request.Content = new StringContent(message, Encoding.UTF8, "application/json");
                // Initiating the request header.
                request.Headers.Add("accept", "application/json");
                // Sending the API request
                HttpResponseMessage response = client.SendAsync(request).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

                using (HttpContent content = response.Content)
                {
                    // Retrieving and stroing the result of the API 
                    var json = content.ReadAsStringAsync();
                    // Converting the retrieved result to JToken object.
                    var jToken = JToken.Parse(json.Result);
                    // Retreving the desired result portion from the whole returned result.
                    var resultObj = jToken[1].ToObject<RootObject>();

                    // Storing the ris_id list from the retrieved result.
                    var candidates = resultObj.candidates;
                    // Loop through the all ris_id of the retreived list.
                    foreach (var item in candidates)
                    {
                        // Adding the each ris_id to the earlier defined ris_id list.
                        risIdList.Add(Convert.ToInt32(item.ris_id));
                    }

                    // Sending data to match richieste
                    var data = await _richiesteManager.GetMatchingRichiesteListByRisIdAsync(richId, clientId, risIdList.ToArray());
                    if (data == null)
                    {
                        return null;
                    }

                    // creating the azioni object passing the related details and description.
                    var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "machine learning");
                    // logging the activity record by the user.
                    await _azioniManager.AzioniInsert(azioniDto);
                    return Ok(data);
                }
            }
            catch (Exception x)
            {
                
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Launch Machine learning");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        ///// <summary>
        /////     To call both machine learning API and store procedure function at the same time.
        ///// </summary>
        ///// <param name="richId">Selected rich_id of richieste list.</param>
        ///// <param name="cvInviati">static data</param>
        ///// <param name="clientId">client id of the logged in user.</param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("LauchBothSPansML/{richId}/{cvInviati}/{clientId}")]
        //public IActionResult LauchBothSPansML(string richId, string cvInviati, string clientId)
        //{
        //    try
        //    {
        //        // Passing the data to business logic layer to call the store procedure.
        //        var categories = _talentBllWrapper.RisorseBll.LaunchRisorseSPBl(richId, cvInviati, clientId);
        //        // calling the function that will call the API of machine learning.
        //        var result = LaunchMachineLearning(richId, clientId);
        //        if (result == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(result);
        //    }
        //    catch (Exception x)
        //    {
        //        // code block for exception handling.
        //        var result = new
        //        {
        //            error = x.StackTrace,
        //            error_type = x.InnerException,
        //            message = x.Message
        //        };
        //        return BadRequest(result);
        //    }
        //}


        /// <summary>
        ///     To get the ris_info based on rich id.
        /// </summary>
        /// <param name="richId">provided rich id.</param>
        /// <returns>Dto object of Risorse.</returns>
        [HttpGet]
        [Route("GetRisInfoByRichId/{richId}")]
        //public async Task<IActionResult> GetRisInfoByRichId(string richId)
        public async Task<IActionResult> GetRisInfoByRichId(string richId)
        {
            try
            {
                // Passing the data to business logic layer
                //var categories = await _talentBllWrapper.RisorseBll.GetRisInfoByRichIdData(richId);
                var categories = await _risorseManager.GetRisInfoByRichIdAsync(User,richId);
                // Null reference handling code block.
                if (categories == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "risorse");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Ris_Info by rich id");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///      Geting the risInfo based on the nome and cognome
        /// </summary>
        /// <param name="risnome">nome of the specific risorse</param>
        /// <param name="risCognome">cognome of the specific risorse</param>
        /// <param name="clientId">client id of the specific </param>
        /// <returns>Risorse dto object.</returns>
        [HttpGet]
        [Route("GetRisInfoByRisNomeCognome/{risnome}/{risCognome}/{clientId}")]
        public async Task<IActionResult> GetRisInfoByRisNomeCognome(string risnome,string risCognome, string clientId)
        {
            try
            {
                // Passing the data to business logic layer
                var categories = await _risorseManager.GetRisInfoByRisNomeCognomeAsync(risnome,risCognome,clientId);
                // Null reference handling code block 
                if (categories == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "risorse");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Ris_Info by risnome");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        [HttpPost]
        [Route("UploadCV/{clientId}/{risId}")]
        public async Task<IActionResult> UploadCV(string clientId, int risId, IFormFile file)
        {
            if (file == null)
                return BadRequest("No file selected");
            if (file.Length == 0)
                return BadRequest("Invalid file");
            if (file.Length > 5 * 1024 * 1024)
                return BadRequest("File size is too large. Max file size is 5 MB");


            var status = await _risorseManager.UploadCvAsync(clientId, risId, file);
            
            try
            {
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "risorse CV file");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
            }
            catch(Exception e)
            {
                // Do nothing
            }

            return Ok(new { status = status });
        }


        [HttpGet]
        [Route("ScanCV/{clientId}/{risId}")]
        public async Task<IActionResult> ScanCV(string clientId, int risId)
        {
            var cvContent = await _risorseManager.ScanCVAsync(clientId, risId);
            return Ok(new { cvContent = cvContent });
        }

        /// <summary>
        ///     To get the file mimeType based on the filename
        /// </summary>
        /// <param name="fileName">name of the file along with the file type name.</param>
        /// <returns></returns>
        [NonAction]
        public string GetFileMimeType(string fileName)
        {
            string mimeType = "";
            
            int lastIndexOfDot = fileName.LastIndexOf('.');
            string fileType = fileName.Substring(lastIndexOfDot + 1);
            switch(fileType.ToLower())
            {
                case "doc":
                    mimeType = "application/vnd.ms-word";
                    break;
                case "docx":
                    mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case "pdf":
                    mimeType = "application/pdf";
                    break;
                case "jpg":
                    mimeType = "image/jpeg";
                    break;
                case "jpeg":
                    mimeType = "image/jpeg";
                    break;
                case "png":
                    mimeType = "image/png";
                    break;
                default:
                    mimeType = "application/vnd.ms-word";
                    break;
            }
            return mimeType;
        }


        /// <summary>
        ///     To send mail to specific contatti having the CV attached
        ///         of specific risorse.
        /// </summary>
        /// <param name="contId"></param>
        /// <param name="risId"></param>
        /// <param name="mailContattiDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SendEmail/{contId}/{risId}")]
        public async Task<IActionResult> EmailContatti(int contId, int risId,[FromForm] MailContattiDto mailContattiDto)
        {
            try
            {
                if (string.IsNullOrEmpty(mailContattiDto.Body))
                {
                    return BadRequest("Mail body can't be empty");
                }

                var contatti = await _contattiManager.FindByContattiAsync(contId);
                var risorse = await _risorseManager.GetCvInfoAsync(risId);

                if(contatti == null || string.IsNullOrEmpty(contatti.ContEmail1))
                {
                    return BadRequest("Email address not found");
                }
            
                // Sending email to the specific resource mail
                _emailManager.To.Add(contatti.ContEmail1);
                _emailManager.Subject = "CV";
                _emailManager.Body = mailContattiDto.Body;


                var stream = new MemoryStream();
                if (mailContattiDto.Attachment != null && mailContattiDto.Attachment.Length > 0)
                {
                    await mailContattiDto.Attachment.CopyToAsync(stream);
                    _emailManager.Attachments.Add(stream, mailContattiDto.Attachment.FileName);                
                }
                else if (risorse.RisCvAllegato != null && !string.IsNullOrEmpty(risorse.RisCvNomeFile))
                {
                    stream = new MemoryStream(risorse.RisCvAllegato);
                    _emailManager.Attachments.Add(stream, risorse.RisCvNomeFile);                    
                }
                
                var response = _emailManager.Send();
                stream.Dispose();

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "email", "contatti");
                // logging the activity record by the user.
                // await _talentBllWrapper.AzuiniBll.AzioniInsert(azioniDto);
                return Ok(new { status = response });
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

    // Creating custom object to call POST API for Machine Learning 
    // This object will be passed for the Body of POST API.
    public class LaunchMLBody
    {
        public string id_model { get; set; }
        public string candidates_filter_level { get; set; }
        public int n_candidates { get; set; }
     
    }

    // Creating custom object to retrieve Machine Learning API result as JsonObject.
    public class RootObject
    {
        public string Candidates_filter_level { get; set; }
        public string Customer { get; set; }
        public string Id_job { get; set; }

        public string Id_model { get; set; }
        public string N_candidates { get; set; }

        public List<Candidates> candidates { get; set; }
    }

    // Creating custom object to retrieve Machine Learning API result as JsonObject.
    public class Candidates
    {
        public string ris_id { get; set; }
        public decimal score { get; set; }
    }
}