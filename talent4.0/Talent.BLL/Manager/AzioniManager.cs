using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.DataModel;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class AzioniManager : IAzioniManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AzioniManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<string>> GetAllTipiAzione()
        {
            try
            {
                var data = await _unitOfWork.Azioni.GetAllTipiAzioneData();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }





        public async Task<int> AzioniInsert(AzioniDto azioniDto)
        {
            try
            {
                if ((azioniDto.AzioneTipo != "login_ko" && azioniDto.AzioneTipo != "login_ok" && azioniDto.AzioneTipo != "logout_user"))
                {
                    var data = await _unitOfWork.Azioni.FindByAzioniAsync(x => x.AzioneCliId.Equals(azioniDto.AzioneCliId)
                                                                    && x.AzioneUteId.Equals(azioniDto.AzioneUteId), 0);

                    
                    if (((DateTime.Now - data.AzioneInsTimestamp).TotalSeconds > 7200))
                    {
                        throw new UnauthorizedAccessException("Token Expired");
                    }
                }


                // Model class mapping from AzioniDto to Azioni.
                var azioni = _mapper.Map<AzioniDto, Azioni>(azioniDto);
                azioni.AzioneInsTimestamp = DateTime.Now;
                azioni.AzioneModTimestamp = DateTime.Now;
                azioni.AzioneInizio = DateTime.Now;

                _unitOfWork.Azioni.Add(azioni);
                int logid = await _unitOfWork.CompleteAsync();
                return logid;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

       

        public async Task<AzioniDto> GetAzioniData(string cliId, string uteId, int noOfSkip)
        {
            try
            {
                Azioni azioni = await _unitOfWork.Azioni.FindByAzioniAsync(x => x.AzioneCliId.Equals(cliId)
                                                                        && x.AzioneUteId.Equals(uteId)
                                                                        && x.AzioneTipo == "login_ok", noOfSkip);

                AzioniDto azioniDto = _mapper.Map<Azioni, AzioniDto>(azioni);
                return azioniDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
