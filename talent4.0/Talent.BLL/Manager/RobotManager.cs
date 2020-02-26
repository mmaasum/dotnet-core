using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.BLL.Repositories;
using Talent.DataModel;
using Talent.DataModel.DataModels;

namespace Talent.BLL.Manager
{
    public class RobotManager : IRobotManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public RobotManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<SPSchedulazioneResiduoCv>> LaunchSpSchedulazioneResiduoCvDataAsync(int schedulazioneId)
        {
            var data = await _unitOfWork.GenericQuery.LaunchSpSchedulazioneResiduoCvDal(schedulazioneId);
            if (data != null)
            {
                return data;
            }
                
            return new List<SPSchedulazioneResiduoCv>();
            
        }

        public async Task<int> LaunchSpSchedulazioneStartDataAsync(int schedule_id)
        {
            var data = await _unitOfWork.GenericQuery.LaunchSpSchedulazioneStartDal(schedule_id);
            return data;
        }

        public async Task<int> LaunchSpSchedulazioneIncrementaCvScaricatiDataAsync(int schedule_id)
        {
            var data = await _unitOfWork.GenericQuery.LaunchSpSchedulazioneIncrementaCvScaricatiDal(schedule_id);
            return data;
        }

        public async Task<int> LaunchSpSchedulazioneStopDataAsync(int schedule_id, int new_cvs, int updated_cvs, int total_cvs, string exit_code)
        {
            var data = await _unitOfWork.GenericQuery.LaunchSpSchedulazioneStopDal
                (schedule_id, new_cvs, updated_cvs, total_cvs, exit_code);

            return data;
        }

        public async Task<IEnumerable<SpItpFindResource>> LaunchSpItpFindResourceDataAsync
                                        (
                                            string cli_id, string name = null,
                                            string surname = null, string email = null,
                                            string phone = null, string date_of_birth = null,
                                            string cities = null, string keyword_skill1 = null,
                                            string indebug = null
                                        )
        {
            var data = await _unitOfWork.GenericQuery.LaunchSpItpFindResourceAsync
            (
                cli_id, name, surname,
                email, phone, date_of_birth,
                cities, keyword_skill1, indebug
            );

            if (data != null)
            {
                return data;
            }

            return new List<SpItpFindResource>();
        }
    }
}