using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL;
using Talent.BLL.Repositories;
using Talent.Common.Enums;

namespace Talent.Web.Controllers.Administrative
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiLanguageController : ControllerBase
    {

        private readonly IUtilityManager _utilityManager;
        private readonly IMultiLanguageManager _multiLanguageManager;

        public MultiLanguageController(IUtilityManager utilityManager, IMultiLanguageManager multiLanguageManager)
        {
            _utilityManager = utilityManager;
            _multiLanguageManager = multiLanguageManager;
        }


        /// <summary>
        ///      To get the left menu list from database based on the language
        /// </summary>
        /// <purpose>
        ///     To get the menu list loaded from database dynamically based on the language which ensure the global acceptance of system.
        /// </purpose>
        /// <param name="language">In which lanaguage the data will be loaded</param>
        /// <returns>List of menu object</returns>
        [HttpGet]
        [Route("GetAllMenu/{language}")]
        public async Task<IActionResult> GetAllMenu(SupportedLanguage language)
        {
            try
            {
                // Retreiving data from the system by provided language.
                var categories = await _multiLanguageManager.GetAllMenuAsync(language);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get All Menu");
                return BadRequest(errorObj);
            }
        }




        /// <summary>
        ///      To get the left menu list from database based on the language and utenti id
        /// </summary>
        /// <purpose>
        ///     To load the authenticate menu for any user
        /// </purpose>
        /// <param name="language">In which lanaguage the data will be loaded</param>
        /// / <param name="uteId">For which utenti the menu will be loaded</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUtentiMenu/{language}/{uteId}/{cliId}")]
        public async Task<IActionResult> GetUtentiMenu(SupportedLanguage language, string uteId, string cliId)
        {
            try
            {
                // Retreiving data from the system by provided language and ute id.
                var categories = await _multiLanguageManager.GetMenuOfUserAsync(language, uteId, cliId);
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get Left Menu List");
                return BadRequest(errorObj);
            }
        }
    }
}