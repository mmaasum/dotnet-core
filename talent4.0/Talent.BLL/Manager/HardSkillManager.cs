using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.Common.Enums;
using Talent.DataModel;
using Talent.DataModel.DataModels;

namespace Talent.BLL.Manager
{
    public class HardSkillManager : IHardSkillManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HardSkillManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestCompetenzeDto>> GetAllCompetenzaAsync(string clientId)
        {
            try
            {
                var data = await _unitOfWork.TestCompetenze.FindInOrderAsync(
                        x => x.TscompCliId.Equals(clientId),
                        c => c.TscompCompetenza,
                        OrderType.Ascending
                    );

                return _mapper.Map<List<TestCompetenzeDto>>(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TestValutazioneDto>> GetAllTestValutazioneAsync(string competenza, string clientId)
        {
            try
            {
                var data = await _unitOfWork.TestValutazione
                    .GetAllTestValutazioneBasedOnCompetenzeAsync(competenza, clientId);

                return _mapper.Map<List<TestValutazioneDto>>(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TestRisultatiDto>> GetHardSkillAsync(int risId)
        {
            try
            {
                var data = await _unitOfWork.TestRisultati.FindInOrderAsync(
                        c => c.TsrisRisId == risId,
                        c => c.TsrisId,
                        OrderType.Descending
                    );

                return _mapper.Map<List<TestRisultatiDto>>(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ModelliEmailDto>> GetMailModelAsync(ClaimsPrincipal User, string langName)
        {
            try
            {
                var cliId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;

                var data = await _unitOfWork.ModelliEmail.FindAsync(
                    c => c.ModemCliId == cliId
                         && c.ModemFunzione == "RichiediTest"
                         && c.ModemLanguage == langName
                );

                return _mapper.Map<List<ModelliEmailDto>>(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TestValutazioneDto>> GetTestValutazioneDataByTypeAsync(int risId, string clientId, string type)
        {
            try
            {
                var data = await _unitOfWork.TestValutazione
                    .GetTestValutazioneDataByTypeDataAsync(risId, clientId, type);

                return _mapper.Map<List<TestValutazioneDto>>(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HardSkillInvitationDto> SendHardSkillInvitationAsync(string[] titoloList, int risId, string clientId)
        {
            try
            {
                var risorse = await _unitOfWork.Risorse.FirstOrDefaultAsync(c => c.RisId == risId);

                StringBuilder emailBody = new StringBuilder();

                emailBody.Append("<br />Gent.le ");
                emailBody.Append(risorse.RisTitolo + " ");
                emailBody.Append(risorse.RisNome + " ");
                emailBody.Append(risorse.RisCognome + ",");
                emailBody.Append("<br />" + " ");
                emailBody.Append(
                    @"come da conversazione telefonica, le invio i link per accedere ai nostri test di 
                    valutazione relativi alla tecnologia di cui ha maggior esperienza.
                    I questionari sono a tempo e possono essere svolti on-line in qualsiasi momento.
                    Si avvierà il test, la procedura è completamente automatica e fornisce al candidato 
                    la possibilità di seguire il tempo rimasto a disposizione per completare il test ed 
                    eventualmente di segnare alcune domande da rivedere prima della consegna finale del test.
                    Una volta terminato il test, arriverà direttamente a me la comunicazione dello svolgimento 
                    del test con il relativo risultato. Sarà poi mia premura darle un riscontro in merito.
                    Di seguito i link per effettuare le prove:"
                );

                

                foreach (var titolo in titoloList)
                {
                    var tsvlInfo = await _unitOfWork.TestValutazione.FirstOrDefaultAsync(c => c.TsvalTitolo == titolo && c.TsvalCliId == clientId);

                    emailBody.Append("<br /> ");
                    emailBody.Append(tsvlInfo.TsvalTitolo + " ");
                    emailBody.Append("<br /> ");
                    emailBody.Append(tsvlInfo.TsvalLink + " ");
                }

                emailBody.Append("<br />  ");
                emailBody.Append("Cordiali saluti");
                emailBody.Append("<br />  ");
                emailBody.Append("IT Partner Italia");


                var hardSkillInvitationDto = new HardSkillInvitationDto();
                hardSkillInvitationDto.Email = risorse.RisEmail;
                hardSkillInvitationDto.EmailBody = emailBody.ToString();

                return hardSkillInvitationDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}