using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class RichiesteManager : IRichiesteManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RichiesteManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }




        public async Task<IEnumerable<StatiRichiesteListaRisorseDescr>> GetStatiRichListRisDescrAsync(string langName)
        {
            try
            {
                return await _unitOfWork.Richieste.GetStatiRichListRisDescrAsync(langName);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<IEnumerable<CompetenzaDto>> GetAllCompetenzaByCliIdAsync(string clientid)
        {
            try
            {
                // Fetching data from dal.
                var data = await _unitOfWork.Competenze
                    .FindInOrderAsync(
                        x => x.CompCliId.Equals(clientid), 
                        x => x.Competenza,
                        OrderType.Ascending);
                // Returning the retrieved data to controller end after mapping.

                return _mapper.Map<List<Competenze>, List<CompetenzaDto>>(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<IEnumerable<CittaDto>> GetAllCittaByCliIdAsync(string clientid)
        {
            try
            {
                // Fetching data from dal.
                var data = await _unitOfWork.Citta
                    .FindInOrderAsync(
                        x => x.CittaCliId.Equals(clientid),
                        x => x.Citta1,
                        OrderType.Ascending);
                // Returning the retrieved data to controller end after mapping.
                return _mapper.Map<List<Citta>, List<CittaDto>>(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        ///     Fetching data from data access layer for richieste and return it to controller end.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RichiesteDto>> GetAllAsync()
        {
            try
            {
                // Fetching data from dal.
                var data = await _unitOfWork.Richieste
                    .GetAllInOrderAsync(
                        x => x.RichId, 
                        OrderType.Descending);
                // Returning the retrieved data to controller end after mapping.
                return _mapper.Map<List<Richieste>, List<RichiesteDto>>(data.Take(500).ToList());
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        ///     Fetching data from data access layer for richieste and return it to controller end based on client id.
        /// </summary>
        /// <param name="cliId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RichiesteDto>> FindAllByCliIdAsync(string cliId, int counter)
        {

            try
            {
                // Fetching data from dal.
                var data = await _unitOfWork.Richieste
                    .FindInOrderAsync(
                        x => x.RichCliId.Equals(cliId) && x.RichAttiva.Equals("S"),
                        o => o.RichInsTimestamp,
                        OrderType.Descending);
                // Passing the retrieved data to controller end by skipping a number of  rows.
                return _mapper.Map<List<Richieste>, List<RichiesteDto>>(data.Skip(counter * 500).Take(500).ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///     Get single row data by predicate where clause.
        /// </summary>
        /// <param name="richid"></param>
        /// <returns></returns>
        public async Task<RichiesteDetailDto> FindByRichIdAsync(string richid)
        {
            try
            {
                Richieste richieste = await _unitOfWork.Richieste.FirstOrDefaultAsync(c => c.RichId.Equals(richid));
                Aziende aziende = await _unitOfWork.Aziende.FirstOrDefaultAsync(x => x.AzId.Equals(richieste.RichAzId));

                RichiesteDetailDto richiesteDetailDto = _mapper.Map<Richieste, RichiesteDetailDto>(richieste);
                richiesteDetailDto.AzRagSociale = aziende.AzRagSociale;

                return richiesteDetailDto;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<string> CloneAsync(string richid)
        {
            try
            {
                Richieste richieste = await _unitOfWork.Richieste.FirstOrDefaultAsync(c => c.RichId == richid);

                richieste.RichInsTimestamp = DateTime.Now;
                richieste.RichModTimestamp = DateTime.Now;
                richieste.RichData = DateTime.Now;

                var richId = await _unitOfWork.Richieste.InsertRichieste(richieste);

                return richId;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        ///     Pasing data to data access layer for inserting richieste retrieved from controller end.
        /// </summary>
        /// <param name="richiesteDto"></param>
        /// <returns></returns>
        public async Task<string> InsertAsync(ClaimsPrincipal User, RichiesteDto richiesteDto)
        {
            try
            {
                //map dto to table richieste
                Richieste richieste = _mapper.Map<RichiesteDto, Richieste>(richiesteDto);

                richieste.RichInsTimestamp = DateTime.Now;
                richieste.RichModTimestamp = DateTime.Now;
                richieste.RichData = DateTime.Now;
                richieste.RichInsUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
                richieste.RichModUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
                richieste.RichCliId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;

                richieste.RichAttiva = "S";

                // Passing data to dal
                var richId = await _unitOfWork.Richieste.InsertRichieste(richieste);

                return richId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///     Pasing data to data access layer for deleting richieste retrieved from controller end.
        /// </summary>
        /// <param name="richid"></param>
        /// <returns></returns>
        public async Task<string> DeleteAsync(string richid)
        {
            try
            {
                Richieste richieste = await _unitOfWork.Richieste
                    .FirstOrDefaultAsync(c => c.RichId.Equals(richid));
                // Here changing the status 'S' to 'N' rather than deleting the record.
                richieste.RichStato = "N";

                await _unitOfWork.CompleteAsync();
                return richieste.RichId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///     Pasing data to data access layer for updating richieste retrieved from controller end.
        /// </summary>
        /// <param name="richiesteDto"></param>
        /// <returns></returns>
        public async Task<string> UpdateAsync(ClaimsPrincipal User, RichiesteDto richiesteDto)
        {
            try
            {
                //map dto dto to table termini
                Richieste richieste = await _unitOfWork.Richieste
                    .FirstOrDefaultAsync(c => c.RichId.Equals(richiesteDto.RichId) 
                                              && c.RichCliId.Equals(richiesteDto.RichCliId));

                _mapper.Map(richiesteDto, richieste);

                richieste.RichModTimestamp = DateTime.Now;
                richieste.RichModUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;

                await _unitOfWork.CompleteAsync();
                return richieste.RichId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<MatchingRisorse>> MatchingRichiesteAsync(string richid, string cliId, int status)
        {
            try
            {
                var data = await _unitOfWork.Richieste.MatchingRichieste(richid, cliId);
                var dataList = data.ToList();

                if (status != -1)
                {
                    for (int i = 0; i < dataList.Count; i++)
                    {
                        if (dataList[i].ActionTaken != status)
                        {
                            dataList.Remove(dataList[i]);
                            i--;
                        }
                    }
                    //foreach (var singleData in data)
                    //{
                    //    if (singleData.ActionTaken != status)
                    //    {
                    //        data.Remove(singleData);
                    //    }
                    //}
                }

                if (data != null)
                {
                    return data;
                }
                else
                {
                    return new List<MatchingRisorse>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<MatchingRisorse>> GetMatchingRichiesteListByRisIdAsync(string richid, string cliId, int[] richlistRisIdList)
        {
            try
            {
                var data = await _unitOfWork.Richieste.MatchingRichiesteByRisIdList(richid, cliId, richlistRisIdList);
                if (data != null)
                {
                    return data;
                }
                else
                {
                    return new List<MatchingRisorse>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CountFindByRichlistRisorseAsync(string richId, int risId, string cliId)
        {

            try
            {
                // Fetching data from dal.
                var data = await _unitOfWork.RichiesteListaRisorse
                    .CountAsync(x => x.RichlistRichId.Equals(richId)
                                     && x.RichlistRisId == risId
                                     && x.RichlistCliId.Equals(cliId));
                // Passing the retrieved data to controller end by skipping a number of  rows.
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<int> InsertRichlistRisorseAsync(RichiesteListaRisorseDto richiesteListaRisorseDto,
                                                   ClaimsPrincipal User)
        {
            try
            {

                RichiesteListaRisorse richListRisorse = _mapper.Map<RichiesteListaRisorseDto, RichiesteListaRisorse>(richiesteListaRisorseDto);

                richListRisorse.RichlistUltimaSelUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
                richListRisorse.RichlistUltimaSelData = DateTime.Now;
                richListRisorse.RichlistInsUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
                richListRisorse.RichlistInsTimestamp = DateTime.Now;
                richListRisorse.RichlistModUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
                richListRisorse.RichlistModTimestamp = DateTime.Now;
                richListRisorse.RichlistCliId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;

                _unitOfWork.RichiesteListaRisorse.Add(richListRisorse);
                await _unitOfWork.CompleteAsync();

                return richListRisorse.RichlistId;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<int> UpdateRichlistRisorseAsync(RichiesteListaRisorseDto richiesteListaRisorseDto)
        {
            try
            {
                RichiesteListaRisorse richListRisorse = await _unitOfWork.RichiesteListaRisorse
                    .FirstOrDefaultAsync(c => c.RichlistRichId == richiesteListaRisorseDto.RichlistRichId 
                                              && c.RichlistCliId == richiesteListaRisorseDto.RichlistCliId
                                              && c.RichlistRisId == richiesteListaRisorseDto.RichlistRisId);

                richListRisorse.RichlistVoto = richiesteListaRisorseDto.RichlistVoto;

                await _unitOfWork.CompleteAsync();

                return richListRisorse.RichlistId;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<int> CountFindByTalentRichlistRisorseAsync(string richId, int risId, ClaimsPrincipal User)
        {

            try
            {
                var cliId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;
                // Fetching data from dal.
                int count = await _unitOfWork.TalentRichiesteListaRisorse
                    .CountAsync(x => x.TrichlistRichId.Equals(richId)
                                     && x.TrichlistRisId == risId
                                     && x.TrichlistCliId.Equals(cliId));
                // Passing the retrieved data to controller end by skipping a number of  rows.
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertTalentRichlistRisorseAsync(RichiesteListaRisorseDto richiesteListaRisorseDto, ClaimsPrincipal User)
        {
            try
            {

                TalentRichiesteListaRisorse talentRichiesteListaRisorse = _mapper.Map<RichiesteListaRisorseDto, TalentRichiesteListaRisorse>(richiesteListaRisorseDto);
                talentRichiesteListaRisorse.TrichlistInsUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
                talentRichiesteListaRisorse.TrichlistModUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
                talentRichiesteListaRisorse.TrichlistCliId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;
                talentRichiesteListaRisorse.TrichlistInsTimestamp = DateTime.Now;
                talentRichiesteListaRisorse.TrichlistModTimestamp = DateTime.Now;

                // Passing data to dal
                _unitOfWork.TalentRichiesteListaRisorse.Add(talentRichiesteListaRisorse);
                await _unitOfWork.CompleteAsync();

                return talentRichiesteListaRisorse.TrichlistId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateTalentRichlistRisorseAsync(RichiesteListaRisorseDto richiesteListaRisorseDto, ClaimsPrincipal User)
        {
            try
            {
                TalentRichiesteListaRisorse talentRichiesteListaRisorse = await _unitOfWork.TalentRichiesteListaRisorse
                    .FirstOrDefaultAsync(c => c.TrichlistRichId == richiesteListaRisorseDto.RichlistRichId 
                                              && c.TrichlistCliId == richiesteListaRisorseDto.RichlistCliId 
                                              && c.TrichlistRisId == richiesteListaRisorseDto.RichlistRisId);


                _mapper.Map(richiesteListaRisorseDto, talentRichiesteListaRisorse);

                talentRichiesteListaRisorse.TrichlistModUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
                talentRichiesteListaRisorse.TrichlistModTimestamp = DateTime.Now;

                await _unitOfWork.CompleteAsync();

                return talentRichiesteListaRisorse.TrichlistId;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}