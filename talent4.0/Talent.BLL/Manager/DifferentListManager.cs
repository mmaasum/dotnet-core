using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.Common.Enums;
using Talent.DataModel;

namespace Talent.BLL.Manager
{
    public class DifferentListManager : IDifferentListManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DifferentListManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<IEnumerable<KeyValuePairDto>> GetAllAzioniTypeCategoryDescriptionAsync(SupportedLanguage language)
        {
            var datas = await _unitOfWork.TipiAzioneCategoriaDescr
                .FindAsync(a => a.TpazcatdescrLingua.Equals(language.ToString()));

            var keyValuePairsList = _mapper.Map<List<KeyValuePairDto>>(datas.ToList());

            return keyValuePairsList;
        }

        public async Task<IEnumerable<KeyValuePairDto>> GetAllAzioniTypeDescriptionAsync(SupportedLanguage language)
        {
            var datas = await _unitOfWork.TipiAzioneDescr
                .FindAsync(a => a.TpazdescrLingua.Equals(language.ToString()));

            var keyValuePairsList = _mapper.Map<List<KeyValuePairDto>>(datas.ToList());

            return keyValuePairsList;
        }

        public async Task<IEnumerable<KeyValuePairDto>> GetAllTerminiStateAsync(SupportedLanguage language)
        {
            var datas = await _unitOfWork.StatiTermineDescr
                .FindAsync(a => a.SterdescrLingua.Equals(language.ToString()));

            var keyValuePairsList = _mapper.Map<List<KeyValuePairDto>>(datas.ToList());

            return keyValuePairsList;
        }

        public async Task<IEnumerable<KeyValuePairDto>> GetAllTerminiLanguageAsync()
        {
            var languages = await _unitOfWork.Termini.GetAllKeywordLanguageAsync();
            var keyValuePairsList = languages.Select(a => new KeyValuePairDto(a));
            return keyValuePairsList;
        }

        public async Task<IEnumerable<KeyValuePairDto>> GetAllTerminiTypeAsync(SupportedLanguage language, string ClientId)
        {
            var types = await _unitOfWork.TipiTermine.GetAllTerminiTypeWithExtraAsync(language, ClientId);

            var keyValuePairsList = _mapper.Map<List<KeyValuePairDto>>(types.ToList());

            return keyValuePairsList;
        }

        public async Task<IEnumerable<KeyValuePairDto>> GetAllRuoloCodesAsync(string ClientId)
        {
            var roles = await _unitOfWork.RuoloUtenti.FindAsync(role => role.RuoloCliId.Equals(ClientId));
            var keyValuePairsList = _mapper.Map<List<KeyValuePairDto>>(roles.ToList());

            return keyValuePairsList;
        }

        public async Task<IEnumerable<KeyValuePairDto>> GetAllRuoloNameAsync(SupportedLanguage language, string ClientId)
        {
            var rolesDescr = await _unitOfWork.RuoliUtentiDescr
                .FindAsync(r => r.RuolodescrLingua.Equals(language.ToString()) && r.RuolodescrCliId.Equals(ClientId));

            var keyValuePairsList = _mapper.Map<List<KeyValuePairDto>>(rolesDescr.ToList());

            return keyValuePairsList;
        }

        public async Task<IEnumerable<KeyValuePairDto>> GetAllRuoloLanguageAsync()
        {
            var languages = await _unitOfWork.RuoloUtenti.GetAllRoleLanguageAsync();
            var keyValuePairsList = languages.Select(a => new KeyValuePairDto(a));
            return keyValuePairsList;
        }

       
    }
}