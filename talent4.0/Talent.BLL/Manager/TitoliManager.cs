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
    class TitoliManager : ITitoliManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TitoliManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Titoli>> GetAllTitoliByClientId(string clientId)
        {
            try
            {
                // Fetching from dal.
                var data = await _unitOfWork.Titoli.FindAsync(a => a.TitoloCliId.Equals(clientId));
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
