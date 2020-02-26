using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;

namespace Talent.BLL.Repositories
{
    public interface IRobotManager
    {
        Task<IEnumerable<SPSchedulazioneResiduoCv>> LaunchSpSchedulazioneResiduoCvDataAsync(int schedulazioneId);
        Task<int> LaunchSpSchedulazioneStartDataAsync(int schedule_id);
        Task<int> LaunchSpSchedulazioneIncrementaCvScaricatiDataAsync(int schedule_id);
        Task<int> LaunchSpSchedulazioneStopDataAsync
            (int schedule_id, int new_cvs, int updated_cvs, int total_cvs, string exit_code);


        Task<IEnumerable<SpItpFindResource>> LaunchSpItpFindResourceDataAsync
        (
            string cli_id, string name = null,
            string surname = null, string email = null,
            string phone = null, string date_of_birth = null,
            string cities = null, string keyword_skill1 = null,
            string indebug = null
        );
    }
}