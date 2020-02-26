using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Talent.DataModel.Models;
using Talent.DataModel.Persistence;
using Talent.DataModel.Persistence.Implementation;
using Talent.DataModel.Repositories;

namespace Talent.DataModel
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connection)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IClientiRepository, ClientiRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISoftSkillRepository, SoftSkillRepository>();

            return services;
        }
    }
}
