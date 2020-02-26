using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.Common.Enums;
using Talent.DataModel;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class SoftSkillManager : ISoftSkillManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SoftSkillManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        /// <summary>
        ///     To store the soft skill survey ws data to db.
        /// </summary>
        /// <param name="surveryorEmail">email of the surveyor who attent the survey</param>
        /// <param name="softSkillTestId">1 for ws getProfile() and 2 for ws GetSkillProfile</param>
        /// <param name="softSkillTestQuiz">S for ws getProfile() and N for ws GetSkillProfile</param>
        /// <returns></returns>
        public async Task<int> InsertSoftSkillTestWSResultAsync(GetWSResultDto getWSResultDto)
        {
            try
            {
                SoftskillsTestWsResult sstwr = new SoftskillsTestWsResult();
                sstwr.SsktestresTestId = getWSResultDto.SoftSkillTestId;
                sstwr.SsktestresPlayField1 = (decimal)getWSResultDto.P;
                sstwr.SsktestresPlayField2 = (decimal)getWSResultDto.L;
                sstwr.SsktestresPlayField3 = (decimal)getWSResultDto.A;
                sstwr.SsktestresPlayField4 = (decimal)getWSResultDto.Y;
                sstwr.SsktestresProfilo = getWSResultDto.ProfileIdProp;
                sstwr.SsktestresTipoTestQuiz = getWSResultDto.SoftSkillTestQuiz;
                sstwr.SsktestresRisDataRisposta = DateTime.Now;
                sstwr.SsktestresInsTimestamp = DateTime.Now;
                sstwr.SsktestresModTimestamp = DateTime.Now;

                if (getWSResultDto.RichId != null)
                {
                    sstwr.SsktestresRichId = getWSResultDto.RichId;
                }

                if(sstwr.SsktestresRichId == null)
                {
                    Risorse risorse = await _unitOfWork.Risorse
                        .FirstOrDefaultAsync(c => c.RisEmail.Contains(getWSResultDto.SurveyorEmail));
                    sstwr.SsktestresRisId = risorse?.RisId;
                }

                _unitOfWork.SoftskillsTestWsResult.Add(sstwr);
                await _unitOfWork.CompleteAsync();

                return sstwr.SsktestresId;
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public async Task<IEnumerable<SPSchedulazioneGetSchedulazioniDto>> GetScheduleAsync(string codiceProcesso)
        {
            try
            {
                var datas = await _unitOfWork.SoftSkill.GetScheduleListFromSPAsync(codiceProcesso);

                return _mapper.Map<List<SPSchedulazioneGetSchedulazioniDto>>(datas.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<IEnumerable<SoftskillsCompetenzeDescrDto>> GetFindSkillDataByLangAsync(string languageName)
        {
            try
            {
                var datas = await _unitOfWork.SoftSkill.FindInOrderAsync(
                           c => c.SskcompdescrLingua.Equals(languageName),
                           c => c.SskcompdescrCompetenza,
                           OrderType.Ascending);

                return _mapper.Map<List<SoftskillsCompetenzeDescrDto>>(datas.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        public async Task<string> GetSoftSkillProfileDescriptionAsync(string richId)
        {
            try
            {
                string profileDescription = "";

                var testWsResult = await _unitOfWork.SoftskillsTestWsResult.FirstOrDefaultAsync(c => c.SsktestresRichId == richId);
                if (testWsResult != null)
                {
                    var ssProfile = await _unitOfWork.SoftskillsProfili
                        .FirstOrDefaultAsync(c => c.SskprofIdPlay == testWsResult.SsktestresProfilo);

                    profileDescription = ssProfile == null ? "" : ssProfile.SskprofDescrizione ;
                }

                return profileDescription;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<int>> PostSoftSkillProfileAsync(string[] skillDescriptionArray)
        {
            try
            {
                List<int> skillCodeArray = new List<int>();
                for (var i = 0; i < skillDescriptionArray.Length; i++)
                {
                    // Retrieving the id and assigning to the list
                    var skill = await _unitOfWork.SoftskillsCompetenze.FirstOrDefaultAsync(c => c.SskcompCompetenza == skillDescriptionArray[i]);
                    if (skill == null)
                    {
                        return new int[]{};
                    }

                    skillCodeArray.Add(skill.SskcompIdPlay);
                }

                return skillCodeArray;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ViewSoftSkillWsResultDto>> GetSavedWsResultByRisIdAsync(int risId, string langName)
        {
            try
            {
                var data = await _unitOfWork.SoftSkill.GetSavedWsResultByRisIdAndLanguageAsync(risId, langName);
                return _mapper.Map<List<ViewSoftSkillWsResultDto>>(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
