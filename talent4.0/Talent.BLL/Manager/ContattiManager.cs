using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.Common.ExtensionMethods;
using Talent.DataModel;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class ContattiManager : IContattiManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContattiManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<IEnumerable<ContattiOptimizedDto>> FindAllContattiByContAzIdAsync(ClaimsPrincipal User, int azId)
        {
            try
            {
                // Retreiving the client id from JWT 
                var clientId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;

                if (azId == 0)
                {
                    return new List<ContattiOptimizedDto>();
                }
                else
                {
                    // Fetching data from DAL.
                    var allContatti = await _unitOfWork.Contatti
                                    .FindAsync(x => x.ContAzId == azId  && x.ContCliId.Equals(clientId));
                    if (allContatti == null || allContatti.Count() == 0)
                    {
                        return new List<ContattiOptimizedDto>();
                    }
                    else
                    {
                        // Returning the retrieved data to controller end 
                        // after mapping to Optimized contatti.
                        return _mapper.Map<List<Contatti>, List<ContattiOptimizedDto>>(allContatti.ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ContattiDto> FindByContattiAsync(int contId)
        {
            Contatti contatti = await _unitOfWork.Contatti.FirstOrDefaultAsync(x => x.ContId.Equals(contId));
            return _mapper.Map<Contatti, ContattiDto>(contatti);
        }

        public async Task<IEnumerable<TipiContattoDto>> GetAllTipiContattoDataByCliIdAsync(string contCliId)
        {
            try
            {
                var data = await _unitOfWork.TipiContatto.FindAsync(x => x.TipcontCliId.Equals(contCliId));
                return _mapper.Map<List<TipiContatto>, List<TipiContattoDto>>(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ContattiOptimizedDto>> GetFindByAllContattiByContAzSedeIdAsync(ClaimsPrincipal User, int contAzSedeId)
        {
            try
            {
                // Retreiving the client id from JWT 
                var clientId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;
                // Fetching data from dal.

                Predicate<Contatti> predicate = x => x.ContCliId.Equals(clientId);


                if (contAzSedeId == 0)
                {
                    predicate = x => x.ContCliId.Equals(clientId);
                }
                else
                {
                    predicate = x => x.ContAzsedeId == contAzSedeId && x.ContCliId.Equals(clientId);
                }

                var data = await _unitOfWork.Contatti.FindAsync(x => predicate.Invoke(x));
                if (data == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<List<Contatti>, List<ContattiOptimizedDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> InsertAsync(ContattiDto contattiDto)
        {
            try
            {
                var allContatti = await _unitOfWork.Contatti.GetAllAsync();
                //mapping dto to contatti table

                contattiDto.ContInsTimestamp = DateTime.Now;
                contattiDto.ContModTimestamp = DateTime.Now;
                contattiDto.ContId = allContatti.OrderByDescending(x => x.ContId).FirstOrDefault().ContId + 1;

                if (contattiDto.ContAzsedeId == 0)
                {
                    var azData = await _unitOfWork.Aziende
                        .FirstOrDefaultAsync(x => x.AzId.Equals(contattiDto.ContAzId) 
                                                  && x.AzCliId.Equals(contattiDto.ContCliId));
                    contattiDto.ContCitta = azData.AzCitta.ReturnEmptyStringForNull();
                    contattiDto.ContAzsedeId = null;
                }
                else
                {
                    var sedeData = await _unitOfWork.SediAziende
                        .FirstOrDefaultAsync(c => c.AzsedeId == contattiDto.ContAzsedeId);
                    contattiDto.ContCitta = sedeData.AzsedeCitta.ReturnEmptyStringForNull();
                }

                Contatti contatti = _mapper.Map<ContattiDto, Contatti>(contattiDto);
                _unitOfWork.Contatti.Add(contatti);
                await _unitOfWork.CompleteAsync();
                return contatti.ContId;
            }
            catch (Exception x)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(ContattiDto contattiDto)
        {
            //map dto dto to table contatti
            Contatti contatti = await _unitOfWork.Contatti.FirstOrDefaultAsync(c => c.ContId.Equals(contattiDto.ContId) && c.ContCliId.Equals(contattiDto.ContCliId));
            contattiDto.ContModTimestamp = DateTime.Now;

            if (contattiDto.ContAzsedeId == 0)
            {
                var azData = await _unitOfWork.Aziende
                    .FirstOrDefaultAsync(x => x.AzId.Equals(contattiDto.ContAzId) 
                                              && x.AzCliId.Equals(contattiDto.ContCliId));
                contattiDto.ContCitta = azData.AzCitta.ReturnEmptyStringForNull();
                contattiDto.ContAzsedeId = null;
            }
            else
            {
                var sedeData = await _unitOfWork.SediAziende
                    .FirstOrDefaultAsync(c => c.AzsedeId == contattiDto.ContAzsedeId);
                contattiDto.ContCitta = sedeData.AzsedeCitta.ReturnEmptyStringForNull();
            }

            _mapper.Map(contattiDto, contatti);

            await _unitOfWork.CompleteAsync();
            return contatti.ContId;
        }

        
    }
}