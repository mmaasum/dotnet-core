using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.DataModel;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class OperazioniManager : IOperazioniManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OperazioniManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        ///  To get all the operazioni data 
        /// </summary>
        /// <returns>Operazioni dto list</returns>
        public async Task<IEnumerable<LogOperazioniDto>> GetAllLogOperazioniData()
        {
            try
            {
                var data = await _unitOfWork.LogOperazioni.GetAllAsync();
                var data2 = data.OrderByDescending(a => a.LogTimestamp).Take(500);

                return _mapper.Map<List<LogOperazioni>, List<LogOperazioniDto>>(data2.ToList());
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        ///   Get all operazioni data based on client id.
        /// </summary>
        /// <param name="cliId"></param>
        /// <param name="counter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LogOperazioniDto>> GetAllLogOperazioniDataByCliId(string cliId, int counter)
        {
            try
            {
                var data = await _unitOfWork.LogOperazioni.FindAsync(x => x.LogCliId.Equals(cliId));
                var data2 = data.Skip(500 * counter).Take(500).ToList();

                return _mapper.Map<List<LogOperazioni>, List<LogOperazioniDto>>(data2.ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        ///  Create new log_operazoni record in database.
        /// </summary>
        /// <param name="logOperazioniDto"></param>
        /// <returns></returns>
        public async Task<int> LogOperazioniInsert(LogOperazioniDto logOperazioniDto)
        {
            try
            {
                logOperazioniDto.LogTimestamp = DateTime.Now;
                var logOperazioni = _mapper.Map<LogOperazioniDto, LogOperazioni>(logOperazioniDto);

                _unitOfWork.LogOperazioni.Add(logOperazioni);
                int res = await _unitOfWork.CompleteAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
