
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.DataModel;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class AziendeManager : IAziendeManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AziendeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SediAziendeDto>> AziendeDetails(int azId, string cliId)
        {
            var items = await _unitOfWork.SediAziende
                            .FindAsync(x => x.AzsedeAzId.Equals(azId) && x.AzsedeCliId.Equals(cliId));
            return _mapper.Map<List<SediAziende>, List<SediAziendeDto>>(items.ToList());
        }

        public async Task<AziendeDto> FindByAziendeAsync(int azid, string azCliId)
        {
            Aziende data = await _unitOfWork.Aziende
                .FirstOrDefaultAsync(x => x.AzId.Equals(azid) && x.AzCliId.Equals(azCliId));

            return _mapper.Map<Aziende, AziendeDto>(data);
        }

        public async Task<AziendeDto> FindBySiglaRichiestaData(int azid, string azCliId, string azSiglaRichiesta)
        {
            try
            {
                Aziende data = await _unitOfWork.Aziende
                    .FirstOrDefaultAsync(x => x.AzId != azid 
                                              && x.AzCliId.Equals(azCliId) 
                                              && x.AzSiglaRichiesta.Equals(azSiglaRichiesta));
                
                return _mapper.Map<Aziende, AziendeDto>(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AziendeDto>> GetAllAziendeData()
        {
            try
            {
                var data = await _unitOfWork.Aziende.GetAllAsync();
                var dataOrderedList = data.OrderByDescending(a => a.AzInsTimestamp)
                    .Take(500)
                    .ToList();
                return _mapper.Map<List<Aziende>, List<AziendeDto>>(dataOrderedList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<OptimizedAziendeDto>> GetOptimizedAziendeListByCliIdAsync(string azCliId)
        {
            var data = await _unitOfWork.Aziende.FindAsync(x => x.AzCliId.Equals(azCliId));

            // Returning only two columns rather than all to the controller end.
            return new List<OptimizedAziendeDto>(data.Select(s => new OptimizedAziendeDto()
            {
                AzId = s.AzId,
                AzRagSociale = s.AzRagSociale
            }));
        }

        public async Task<IEnumerable<AziendeDto>> GetAziendeListByCliIdAsync(string azCliId, int counter)
        {
            var data = await _unitOfWork.Aziende.FindAsync(x => x.AzCliId.Equals(azCliId));
            var dataList = data.Skip(500 * counter).Take(500).ToList();

            return _mapper.Map<List<Aziende>, List<AziendeDto>>(dataList);

        }

        public async Task<IEnumerable<TipiAziendaDto>> GetAllTipiAziendaData(string cliId)
        {
            try
            {
                var data = await _unitOfWork.TipiAzienda.FindAsync(c => c.TipazCliId.Equals(cliId));

                return _mapper.Map<List<TipiAzienda>, List<TipiAziendaDto>>(data.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> InsertAziende(AziendeDto aziendeDto)
        {
            Aziende aziende = _mapper.Map<AziendeDto, Aziende>(aziendeDto);
            aziende.AzInsTimestamp = DateTime.Now;
            aziende.AzModTimestamp = DateTime.Now;

            _unitOfWork.Aziende.Add(aziende);

            var azid = await _unitOfWork.CompleteAsync();
            return aziende.AzId;
        }

        public async Task<int> UpdateAziende(AziendeDto aziendeDto)
        {
            Aziende aziende = await _unitOfWork.Aziende.FirstOrDefaultAsync(c => c.AzId.Equals(aziendeDto.AzId) && c.AzCliId.Equals(aziendeDto.AzCliId));
            _mapper.Map(aziendeDto, aziende);

            aziende.AzModTimestamp = DateTime.Now;
            var azid = await _unitOfWork.CompleteAsync();

            return aziende.AzId;
        }
    }
}