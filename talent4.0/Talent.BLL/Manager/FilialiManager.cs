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
    class FilialiManager : IFilialiManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FilialiManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Filiali>> GetAllFilialiByClientId(string clientId)
        {
            try
            {
                // Fetching from dal.
                var data = await _unitOfWork.Filiali.FindAsync(x => x.FilialeCliId.Equals(clientId));
                // Returning the retrieved data to controller end.
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
