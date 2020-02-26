using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.DataModel;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class ClientFinaleManager : IClientFinaleManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientFinaleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<AziendeClientiFinaleDto> FindByClifinIdData(int clifinId)
        {
            try
            {
                AziendeClientiFinali data = await _unitOfWork.AziendeClientiFinali.FirstOrDefaultAsync(c => c.ClifinId == clifinId);
                return _mapper.Map<AziendeClientiFinali, AziendeClientiFinaleDto>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AziendeClientiFinaleDto>> GetAllData(int clifinAzId)
        {
            try
            {
                // Retrieving the data from dal by passing az_id and client id.
                var data = await _unitOfWork.AziendeClientiFinali.GetAllAziendeClientiFinaleAsync(clifinAzId);
                // Returning the aziende client finale list by converting those into dto object list.
                return _mapper.Map<List<ViewAziendeClientiFinali>, List<AziendeClientiFinaleDto>>(data.ToList());
            }
            catch (Exception ex)
            {
                // throwing if there's any exception.
                throw;
            }
        }

        public async Task<IEnumerable<AziendeClientiFinaleOptimizedDto>> GetFindAllByOptimizedAziendeClienteFinale(ClaimsPrincipal User, int azId)
        {
            try
            {
                var clientId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;
                // Retrieving the data from dal by passing az_id and client id.
                var data = await _unitOfWork.AziendeClientiFinali
                                .FindAsync(u => u.ClifinAzId == azId
                                                && u.ClifinCliId.Equals(clientId));
                return _mapper.Map<List<AziendeClientiFinali>, List<AziendeClientiFinaleOptimizedDto>>(data.ToList());
            }
            catch (Exception ex)
            {
                // throwing if there's any exception.
                throw;
            }
        }

        public async Task<int> InsertData(AziendeClientiFinaleDto aziendeClientiFinaleDto)
        {
            try
            {
                // Converting to aziende client finale from dto object to pass into dal.
                var clientFinale = _mapper.Map<AziendeClientiFinaleDto, AziendeClientiFinali>(aziendeClientiFinaleDto);
               
                _unitOfWork.AziendeClientiFinali.Add(clientFinale);
                await _unitOfWork.CompleteAsync();
                
                return clientFinale.ClifinId;
            }
            catch (Exception ex)
            {
                // throwing an exception if there's any.
                throw;
            }
        }

        public async Task<int> UpdateData(AziendeClientiFinaleDto aziendeClientiFinaleDto)
        {
            // Implementing try-catch block.
            try
            {
                // Retrieving the current aziende client finale record by matching through several criteria.
                var clientFinale = await _unitOfWork.AziendeClientiFinali
                    .FirstOrDefaultAsync(u => u.ClifinId.Equals(aziendeClientiFinaleDto.ClifinId) 
                                              && u.ClifinCliId.Equals(aziendeClientiFinaleDto.ClifinCliId));

                aziendeClientiFinaleDto.ClifinInsTimestamp = clientFinale.ClifinInsTimestamp;

                _mapper.Map(aziendeClientiFinaleDto, clientFinale);

                clientFinale.ClifinModTimestamp = DateTime.Now;

                await _unitOfWork.CompleteAsync();
                return clientFinale.ClifinId;
            }
            catch (Exception ex)
            {
                // throwing an exception if there's any.
                throw;
            }
        }
    }
}