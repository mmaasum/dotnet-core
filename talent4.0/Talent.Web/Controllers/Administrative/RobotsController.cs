using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers.Administrative
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotsController : ControllerBase
    {

        private readonly IAzioniManager _azioniManager;
        private readonly IUtilityManager _utilityManager;
        private readonly IRobotManager _robotManager;
        

        public RobotsController(IAzioniManager azioniManager, IUtilityManager utilityManager, IRobotManager robotManager)
        {
            _azioniManager = azioniManager;
            _utilityManager = utilityManager;
            _robotManager = robotManager;
        }


        //// api/robots/StartSchedule/schedule_id
        //[HttpGet]
        //[Route("TestSP/{queryText}")]
        //public IActionResult TestSP(string queryText)

        //{
        //    try
        //    {
        //        var categories = _talentBLLWrapper.RobotBll.TestSP(queryText);

        //        if (categories == null)
        //        {
        //            return NotFound();
        //        }

        //        // creating the azioni object passing the related details and description.
        //        var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "launch SP [sp_schedulazione_start] ");
        //        // logging the activity record by the user.
        //        _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);
        //        return Ok(categories);
        //    }
        //    catch (Exception x)
        //    {
        //        // Code block of Exception handling and logging into log_operazione table.
        //        var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Launch SP [sp_schedulazione_start]");
        //        // Returning the error object.
        //        return BadRequest(errorObj);
        //    }
        //}

        /// <summary>
        ///         Before downloading a CV it checks if this is present or not in the database and if so it checks if its
        ///         insertion date is older than 180 days(to be parameterised 180), in case the resource is new or
        ///         existing but older than defined days, proceed to download and send by email to the automatic
        ///         data entry, otherwise go to the next cv.
        /// </summary>
        /// <param name="name">name of the risorse</param>
        /// <param name="surname">surname of the risorse</param>
        /// <param name="email">email of the risorse</param>
        /// <param name="phone">phone of the risorse</param>
        /// <param name="date_of_birth">dob of the risorse</param>
        /// <param name="cities">city that any risorse belongs to</param>
        /// <param name="keyword_skill1">skill that any risorse belongs to</param>
        /// <param name="cli_id">vlient id of the risorse</param>
        /// <param name="indebug"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ResourceExists/{name?}/{surname?}/{email?}/{phone?}/{date_of_birth?}/{cities?}/{keyword_skill1?}/{cli_id?}/{indebug?}")]
        public async Task<IActionResult> LaunchSpItpFindResource(
                                            string name = null, 
                                            string surname = null, string email = null,
                                            string phone = null, string date_of_birth = null,
                                            string cities = null, string keyword_skill1 = null,
                                            string cli_id = null, string indebug = null
                                            )
        {
            //return Ok();
            try
            {
                var categories = await _robotManager.LaunchSpItpFindResourceDataAsync
                                            (
                                                cli_id, name, surname,
                                                email, phone, date_of_birth,
                                                cities, keyword_skill1, indebug
                                            );
                if (categories == null)
                {
                    return NotFound();
                }

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "launch SP [Sp_schedulazione_residuo_cv] ");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "launch SP [Sp_Itp_Find_Resource] ");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }




        /// <summary>
        ///     To check how many CVs can be downloaded for today of this automation.
        /// </summary>
        /// <param name="iprogrammatori"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CvCredit/{iprogrammatori}")]
        public async Task<IActionResult> LaunchSpSchedulazioneResiduoCv(int iprogrammatori)
        {
            try
            {
                var categories = await _robotManager.LaunchSpSchedulazioneResiduoCvDataAsync(iprogrammatori);
                if (categories == null)
                {
                    return NotFound();
                }

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "launch SP [Sp_schedulazione_residuo_cv] ");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Launch SP [Sp_schedulazione_residuo_cv]");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }





        /// <summary>
        ///     To mark the start of the job using the StartSchedulation method (sp_schedulazione_start)
        /// </summary>
        /// <param name="schedule_id"></param>
        /// <returns></returns>
        // api/robots/StartSchedule/schedule_id
        [HttpGet]
        [Route("StartSchedule/{schedule_id}")]
        public async Task<IActionResult> LaunchSpSchedulazioneStart(int schedule_id)

        {
            try
            {
                var categories = await _robotManager.LaunchSpSchedulazioneStartDataAsync(schedule_id);

                if (categories == 0)
                {
                    return NotFound();
                }

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "launch SP [sp_schedulazione_start] ");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Launch SP [sp_schedulazione_start]");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///     Each time you download a Cv, it records the download by increasing the daily Cv credit counter for
        ///     this robot.
        /// </summary>
        /// <param name="schedule_id"></param>
        /// <returns></returns>
        // api/robots/IncreaseDownloadedCvs/schedule_id
        [HttpGet]
        [Route("IncreaseDownloadedCvs/{schedule_id}")]
        public async Task<IActionResult> LaunchSpSchedulazioneIncrementaCvScaricati(int schedule_id)

        {
            try
            {
                var categories = await _robotManager.LaunchSpSchedulazioneIncrementaCvScaricatiDataAsync(schedule_id);

                if (categories == 0)
                {
                    return NotFound();
                }

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "launch SP [sp_schedulazione_start] ");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Launch SP [sp_schedulazione_start]");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }



        /// <summary>
        ///     To mark the end of the job using the StopSchedulation method (sp_schedulazione_stop)
        /// </summary>
        /// <param name="schedule_id"></param>
        /// <param name="new_cvs"></param>
        /// <param name="updated_cvs"></param>
        /// <param name="total_cvs"></param>
        /// <param name="exit_code"></param>
        /// <returns></returns>
        // api/robots/StopSchedule/schedule_id/new_cvs/updated_cvs/total_cvs/exit_code
        [HttpGet]
        [Route("StopSchedule/{schedule_id}/{new_cvs}/{updated_cvs}/{total_cvs}/{exit_code}")]
        public async Task<IActionResult> SpSchedulazioneStop
                                    (   int schedule_id,int new_cvs,int updated_cvs, 
                                        int total_cvs, string exit_code
                                    )
        {
            try
            {
                var categories = await _robotManager.LaunchSpSchedulazioneStopDataAsync
                                                (schedule_id, new_cvs, updated_cvs, total_cvs, exit_code);
                if (categories == 0)
                {
                    return NotFound();
                }

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "launch SP [Sp_schedulazione_stop] ");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Launch SP [Sp_schedulazione_stop]");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }
    }






    //public class Candidates
    //{
    //    public string ris_id { get; set; }
    //    public decimal score { get; set; }


    //    string cli_id, 
    //        string name = null,
    //         string surname = null, string email = null,
    //         string phone = null, 
    //        string date_of_birth = null,
    //         string cities = null, 
    //        string keyword_skill1 = null,
    //         string indebug = null

    //}
}