using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Talent.BLL.Utilities;
using Talent.BLL.Manager;
using Talent.BLL.Repositories;
using Talent.DataModel;

namespace Talent.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services, string connection)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDataAccess(connection);

            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IAziendeManager, AziendeManager>();
            services.AddScoped<IAzioniManager, AzioniManager>();
            services.AddScoped<IClientManager, ClientManager>();
            services.AddScoped<IClientFinaleManager, ClientFinaleManager>();
            services.AddScoped<IContattiManager, ContattiManager>();
            services.AddScoped<IDifferentListManager, DifferentListManager>();
            services.AddScoped<IEmailManager, EmailManager>();
            services.AddScoped<IFilialiManager, FilialiManager>();
            services.AddScoped<IGlobalGridManager, GlobalGridManager>();
            services.AddScoped<IHardSkillManager, HardSkillManager>();
            services.AddScoped<IMultiLanguageManager, MultiLanguageManager>();
            services.AddScoped<IOperazioniManager, OperazioniManager>();
            services.AddScoped<IRichiesteManager, RichiesteManager>();
            services.AddScoped<IRisorseManager, RisorseManager>();
            services.AddScoped<IRobotManager, RobotManager>();
            services.AddScoped<IRoleManager, RoleManager>();
            services.AddScoped<ISediAziendeManager, SediAziendeManager>();
            services.AddScoped<ISoftSkillManager, SoftSkillManager>();
            services.AddScoped<ISubscriberManager, SubscriberManager>();
            services.AddScoped<ISurveyManager, SurveyManager>();
            services.AddScoped<ITerminiManager, TerminiManager>();
            services.AddScoped<ITitoliManager, TitoliManager>();
            services.AddScoped<IUsersManager, UsersManager>();
            services.AddScoped<IUtilityManager, UtilityManager>();


            return services;
        }
    }
}
