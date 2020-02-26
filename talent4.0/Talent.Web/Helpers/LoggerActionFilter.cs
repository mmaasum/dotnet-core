using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Talent.BLL.Repositories;

namespace Talent.Web.Helpers
{
    public class LoggerActionFilter : IAsyncActionFilter
    {
        private readonly string _type;
        private readonly string _description;
        private readonly IAzioniManager _azioniManager;
        private readonly IUtilityManager _utilityManager;

        public LoggerActionFilter(string type, string description, IAzioniManager azioniManager, IUtilityManager utilityManager)
        {
            _type = type;
            _description = description;
            _azioniManager = azioniManager;
            _utilityManager = utilityManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ActionExecutedContext resultContext = await next();
            var user = context.HttpContext.User;

            if (resultContext.Exception != null)
            {
                var azioniDto = _utilityManager.GetAzioniDtoObject(user, _type, _description);
                await _azioniManager.AzioniInsert(azioniDto);
            }
            
        }
    }
}
