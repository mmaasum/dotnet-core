using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.DataModel.DataModels;

namespace Talent.DataModel.Repositories
{
    public interface IGenericQueryRepository
    {
        Task<IEnumerable<Object>> FindDataFromRawQueryAsync(string query, string tableName);

        Task<IEnumerable<SPSchedulazioneResiduoCv>> LaunchSpSchedulazioneResiduoCvDal(int schedulazioneId);
        Task<int> LaunchSpSchedulazioneStartDal(int schedule_id);

        Task<int> LaunchSpSchedulazioneIncrementaCvScaricatiDal(int schedule_id);

        Task<int> LaunchSpSchedulazioneStopDal
            (int schedule_id, int new_cvs, int updated_cvs, int total_cvs, string exit_code);

        Task<IEnumerable<SpItpFindResource>> LaunchSpItpFindResourceAsync
        (
            string cli_id, string name = null,
            string surname = null, string email = null,
            string phone = null, string date_of_birth = null,
            string cities = null, string keyword_skill1 = null,
            string indebug = null
        );
    }
}