using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.Common.Enums;

namespace Talent.Web.Controllers.ApplicationData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListTypeFilterValueController : ControllerBase
    {

        private readonly IDifferentListManager _differentListManager;
        private readonly IUtilityManager _utilityManager;

        public ListTypeFilterValueController(IDifferentListManager differentListManager, IUtilityManager utilityManager)
        {
            _differentListManager = differentListManager;
            _utilityManager = utilityManager;
        }


        [HttpGet]
        [Route("Azioni/{language}")]
        public async Task<IActionResult> Azioni(SupportedLanguage language)
        {
            var categories = await _differentListManager.GetAllAzioniTypeCategoryDescriptionAsync(language);
            var descriptions = await _differentListManager.GetAllAzioniTypeDescriptionAsync(language);
            
            var dt = new List<List<KeyValuePairDto>>();
            dt.Add(categories.ToList());
            dt.Add(descriptions.ToList());

            return Ok(dt);
        }

        [HttpGet]
        [Route("Termini/{language}/{clientId}")]
        public async Task<IActionResult> Termini(SupportedLanguage language, string clientId)
        {
            var states = await _differentListManager.GetAllTerminiStateAsync(language);
            var languages = await _differentListManager.GetAllTerminiLanguageAsync();
            var types = await _differentListManager.GetAllTerminiTypeAsync(language, clientId);

            var dt = new List<List<KeyValuePairDto>>();
            dt.Add(states.ToList());
            dt.Add(languages.ToList());
            dt.Add(types.ToList());

            return Ok(dt);
        }

        [HttpGet]
        [Route("Role/{language}/{clientId}")]
        public async Task<IActionResult> Role(SupportedLanguage language, string clientId)
        {
            var roleCodes = await _differentListManager.GetAllRuoloCodesAsync(clientId);
            var roleNames = await _differentListManager.GetAllRuoloNameAsync(language, clientId);
            var languages = await _differentListManager.GetAllTerminiLanguageAsync();


            var yesText = _utilityManager.GetTranslatedData(language.ToString(), "common_loc_", "$.common.usrmsg_info.L7014_yes");
            var noText = _utilityManager.GetTranslatedData(language.ToString(), "common_loc_", "$.common.usrmsg_info.L7015_no");

            var enableText = _utilityManager.GetTranslatedData(language.ToString(), "ruoli_loc_", "$.ruoli.usrmsg_info.L07352_enabled");
            var disabledText = _utilityManager.GetTranslatedData(language.ToString(), "ruoli_loc_", "$.ruoli.usrmsg_info.L07353_disabled");


            var stateList = new List<KeyValuePairDto>
            {
                new KeyValuePairDto("S", enableText),
                new KeyValuePairDto("N", disabledText)
            };

            var systemList = new List<KeyValuePairDto>
            {
                new KeyValuePairDto("S", yesText),
                new KeyValuePairDto("N", noText)
            };

            var dt = new List<List<KeyValuePairDto>>();
            dt.Add(roleCodes.ToList());
            dt.Add(roleNames.ToList());
            dt.Add(languages.ToList());
            dt.Add(stateList);
            dt.Add(systemList);

            return Ok(dt);
        }
    }
}