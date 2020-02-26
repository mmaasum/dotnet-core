using AutoMapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.DataModel;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class UtilityManager : IUtilityManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UtilityManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public UtilityManager()
        {
           
        }


        public string GetTranslatedData(string langName, string fileName, string queryToken)
        {
            var webRoot = "ClientApp/dist/assets/localization/";

            var env = AppSettingsDto.Environment;
            if(env == "Development")
            {
               webRoot = "ClientApp/src/assets/localization/";
            }
           
            fileName = fileName + langName + ".json";
            var fullRoute = webRoot + fileName;
            var myJsonString = System.IO.File.ReadAllText(fullRoute);
            var myJObject = JObject.Parse(myJsonString);
            string jSonRetreivedData = myJObject.SelectToken(queryToken).Value<string>();
            
            return jSonRetreivedData;
        }

        public async void GenerateLogOperazioniDto(ClaimsPrincipal User, string desc, string details)
        {
            try
            {
                LogOperazioniDto logOperazioniDto = new LogOperazioniDto
                                    (
                                        User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value,
                                        User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value,
                                        desc,
                                        details
                                    );

                LogOperazioni logOperazioni = _mapper.Map<LogOperazioniDto, LogOperazioni>(logOperazioniDto);
                
                _unitOfWork.LogOperazioni.Add(logOperazioni);
                await _unitOfWork.CompleteAsync();
            }
            catch { }
        }

        public AzioniDto GetAzioniDtoObject(ClaimsPrincipal User, string azioniTipo, string azioniDesc)
        {
            AzioniDto azioniDto = new AzioniDto();
            azioniDto.AzioneTipo = azioniTipo;
            azioniDto.AzioneDescrizione = azioniDesc;
            var uteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
            azioniDto.AzioneUteId = uteId;
            azioniDto.AzioneInsUteId = uteId;
            azioniDto.AzioneModUteId = uteId;
            azioniDto.AzioneCliId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;
            azioniDto.AzioneInizio = DateTime.Now;
            return azioniDto;
        }

        public async Task<object> ReturnErrorObj(Exception ex, ClaimsPrincipal User, string desc)
        {
            try
            {
                LogOperazioniDto logOperazioniDto = new LogOperazioniDto
                                        (
                                            User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value,
                                            User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value,
                                            desc,
                                            ReturnOptimizedString(ex.Message)
                                        );

                LogOperazioni logOperazioni = _mapper.Map<LogOperazioniDto, LogOperazioni>(logOperazioniDto);
                _unitOfWork.LogOperazioni.Add(logOperazioni);
                await _unitOfWork.CompleteAsync();
            }
            catch { }

            var errObj = new
            {
                error = ex.StackTrace,
                error_type = ex.InnerException,
                message = ex.Message
            };
            return errObj;
        }

        private string ReturnOptimizedString(string str)
        {
            if (str.Length > 299)
            {
                str = str.Remove(str.Length - (str.Length - 299));
            }
            var a = str.Length;
            return str;
        }
    }
}
