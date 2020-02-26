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
    public class ClientManager : IClientManager
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetAllClientDataAsync()
        {
            try
            {
                // Fetching all the client as list except the client name is "ITP999".
                var clients = await _unitOfWork.Clienti.FindAsync(a => !a.CliNome.Equals("ITP999"));
                var clientsDto = _mapper.Map<List<Clienti>, List<ClientDto>>(clients.ToList());
                // Returning only two columns rather than all to the controller end.
                return clientsDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ClientDto>> GetAllClientDataByUteIdAsync(string uteId)
        {
            try
            {
                var clientIdList = (await _unitOfWork.Users.FindAsync(u => u.UteId.Equals(uteId)))
                                    .Select(a => a.UteCliId);

                var clients = await _unitOfWork.Clienti.FindAsync(a => clientIdList.Contains(a.CliId));
                var clientsDto = _mapper.Map<List<Clienti>, List<ClientDto>>(clients.ToList());
                return clientsDto;
            }
            catch (Exception ex)
            {
                // Throwing Exception to business logic layer.
                throw;
            }
        }

        public async Task<ClientDto> GetClientDataByClientId(string cliId, string secretKey)
        {
            try
            {

                var validKeyData = await _unitOfWork.Clienti.FindByGeneralParamListAsync
                                                        (a => a.CliId.ToLower().Equals(cliId.ToLower())
                                                           && a.Valore.ToString().Equals(secretKey)
                                                           && a.NomeParametro.Equals("login_secure_code"));

                // Fetching all the client as list except the client name is "ITP999".
                var data = await _unitOfWork.Clienti.FindAsync(a => a.CliId.Equals(cliId));
                ClientDto clientDto = new ClientDto();
                if (data.Count() == 0 || validKeyData.Count() == 0)
                //if (data.Count() == 0)
                {
                    return null;
                }
                clientDto.CliId = data.FirstOrDefault().CliId;
                clientDto.CliNome = data.FirstOrDefault().CliNome;
                clientDto.CliLogoPath = data.FirstOrDefault().CliLogoPath;
                return clientDto;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
