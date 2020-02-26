using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.DataModel;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class SediAziendeManager : ISediAziendeManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SediAziendeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SediAziendeDto> FindBySedeIdAsync(int sedeId)
        {
            try
            {
                // Fetching data from dal.
                SediAziende data = await _unitOfWork.SediAziende.FirstOrDefaultAsync(c => c.AzsedeId == sedeId);
                // Returning the retrieved data to controller end
                return _mapper.Map<SediAziende, SediAziendeDto>(data);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SediAziendeDto>> GetAllAsync(string clientId)
        {
            try
            {
                // Fetching data from dal.
                var data = await _unitOfWork.SediAziende.GetAllSediAziendeDal(clientId);
                // Returning the retrieved data to controller end
                return _mapper.Map<List<ViewSediAziende>, List<SediAziendeDto>>(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SediAziendeDto>> GetAllByAzSedeAzIdAsync(int azSedeAzId)
        {
            try
            {
                // Fetching data from dal.
                var data = await _unitOfWork.SediAziende.FindAsync(c => c.AzsedeAzId == azSedeAzId);
                // Returning the retrieved data to controller end
                return _mapper.Map<List<SediAziende>, List<SediAziendeDto>>(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertAsync(SediAziendeDto sediAziendeDto)
        {
            try
            {
                var sediAziende = _mapper.Map<SediAziendeDto, SediAziende>(sediAziendeDto);
                _unitOfWork.SediAziende.Add(sediAziende);
                await _unitOfWork.CompleteAsync();

                return sediAziende.AzsedeId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(SediAziendeDto sediAziendeDto)
        {
            try
            {
                var sediAziende = await _unitOfWork.SediAziende
                    .FirstOrDefaultAsync(u => u.AzsedeId.Equals(sediAziendeDto.AzsedeId) 
                                              && u.AzsedeCliId.Equals(sediAziendeDto.AzsedeCliId));


                _mapper.Map(sediAziendeDto, sediAziende);
                await _unitOfWork.CompleteAsync();

                return sediAziende.AzsedeId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}