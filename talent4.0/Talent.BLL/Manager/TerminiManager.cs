using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.Common.Enums;
using Talent.DataModel;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class TerminiManager : ITerminiManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TerminiManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LastAnalysisDto>> GetLastAnalysisInfoData(string cliId, string uteId)
        {
            try
            {
                // Retriebing data from dal and then returning to controller end.
                var data = await _unitOfWork.Termini.GetLastAnalysisInfoDal(cliId, uteId);
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteAsync(string termini)
        {
            try
            {
                // Retrieving the termini object based on termini (name)
                Termini data = await _unitOfWork.Termini.FirstOrDefaultAsync(c => c.Termine.Equals(termini));
                // Updating the status as inactive rather than deleting.
                data.TerStato = "N";
                // Soft deleting the termini record.
                await _unitOfWork.CompleteAsync();
                // Returning the recently deleted termini object.
                return termini;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TerminiDto> FindAsync(string termini, string cliId)
        {
            try
            {
                // Fetching data from dal by passing parameter.
                Termini data = await _unitOfWork.Termini.FirstOrDefaultAsync(c => c.Termine.Equals(termini) && c.TerCliId.Equals(cliId));
                // Returning the retrieved data to controller end by mapping into dto object.
                return _mapper.Map<Termini, TerminiDto>(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TerminiDto> FindNextTerminiAsync(TerminiDto terminiDto)
        {
            try
            {
                // Fetching data from dal by passing parameter.
                //Termini currentTermini = await _unitOfWork.Termini.FirstOrDefaultAsync
                //                                (c => c.TerCliId.Equals(terminiDto.TerCliId) 
                //                                   && c.Termine.Equals(terminiDto.Termine)
                //                                   && c.TerLingua.Equals(terminiDto.TerLingua));

                Termini nextTermini = (await _unitOfWork.Termini.FindInOrderAsync
                                         ((c => c.TerCliId.Equals(terminiDto.TerCliId)
                                            && c.TerStato.Equals(terminiDto.TerStato)
                                            && c.TerLingua.Equals(terminiDto.TerLingua)),
                                            o => o.TerInsTimestamp, OrderType.Ascending)
                                      ).FirstOrDefault();
                                            
                // Returning the retrieved data to controller end by mapping into dto object.
                return _mapper.Map<Termini, TerminiDto>(nextTermini);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TipiTermineDto>> FindByTipiTermineListAsync(string cliId)
        {
            try
            {
                // Retriebing data from dal and then returning to controller end.
                var terminiList = await _unitOfWork.TipiTermine.FindAsync(x => x.TipterCliId.Equals(cliId));
                return _mapper.Map<List<TipiTermine>, List<TipiTermineDto>>(terminiList.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TerminiDto>> FindListAsync(string clientid, int counter)
        {
            try
            {
                // Fetching data from dal
                var data = await _unitOfWork.Termini.FindAsync(x => x.TerCliId.Equals(clientid));
                var dataTrimmedList = data.Skip(500 * counter).Take(500).ToList();
                return _mapper.Map<List<Termini>, List<TerminiDto>>(dataTrimmedList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TerminiDto>> GetAllAsync()
        {
            try
            {
                // Fetching data from dal.
                var data = await _unitOfWork.Termini.GetAllAsync();
                var dataList = data.OrderByDescending(a => a.Termine).Take(500).ToList();
                // Returning the retrieved data to controller end by mapping into dto object.
                return _mapper.Map<List<Termini>, List<TerminiDto>>(dataList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TerminiDto>> GetAllTerminiBySinonimoData(string[] sinonimoArray, string termini, string cliId)
        {
            try
            {
                List<Termini> terminiList = new List<Termini>();

                // Loop over the array to check whether any one of this get matched to any sinonimo in the system.
                foreach (var sinonimo in sinonimoArray)
                {
                    var similarRecords = await _unitOfWork.Termini
                        .FindAsync(c =>
                            (
                                c.TerSinonimo1 == sinonimo ||
                                c.TerSinonimo2 == sinonimo ||
                                c.TerSinonimo3 == sinonimo ||
                                c.TerSinonimo4 == sinonimo ||
                                c.TerSinonimo5 == sinonimo ||
                                c.TerSinonimo6 == sinonimo ||
                                c.TerSinonimo7 == sinonimo ||
                                c.TerSinonimo8 == sinonimo ||
                                c.Termine == sinonimo
                            ) && c.TerCliId == cliId && c.Termine != termini );

                    var similarRecordList = similarRecords.ToList();
                    // Checking whether there is any record having the specific sinonimo.
                    if (similarRecordList.Count > 0)
                    {
                        // Loop to add those reccord in the pre-declared termini list.
                        foreach (var similarRecord in similarRecordList)
                        {
                            terminiList.Add(similarRecord);
                        }
                    }
                }

                return _mapper.Map<List<Termini>, List<TerminiDto>>(terminiList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> InsertAsync(TerminiDto terminiDto)
        {
            try
            {
                // Map dto to termini domain model.
                Termini termini = _mapper.Map<TerminiDto, Termini>(terminiDto);

                termini.TerInsTimestamp = DateTime.Now;
                termini.TerModTimestamp = DateTime.Now;

                _unitOfWork.Termini.Add(termini);
                await _unitOfWork.CompleteAsync();
                
                return termini.Termine;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpdateAsync(TerminiDto terminiDto)
        {
            try
            {
                // Retrieving the termini object based on termini dto attributes value.
                var termini = await _unitOfWork.Termini.FirstOrDefaultAsync(c => c.Termine.Equals(terminiDto.Termine) && c.TerCliId.Equals(terminiDto.TerCliId));
                // Map dto dto to termini domain model
                _mapper.Map(terminiDto, termini);

                termini.TerModTimestamp = DateTime.Now;

                await _unitOfWork.CompleteAsync();

                return termini.Termine;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}