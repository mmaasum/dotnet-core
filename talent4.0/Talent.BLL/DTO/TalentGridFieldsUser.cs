using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.Models;

namespace Talent.BLL.DTO
{
    public class TalentGridFieldsUser
    {
        public int TntgcuId { get; set; }
        public string TntgcuFieldName { get; set; }
        public string TntgcuUteId { get; set; }
        public string TntgcuCliId { get; set; }
        public string TntgcuFieldFontName { get; set; }
        public int? TntgcuFieldFontSize { get; set; }
        public int? TntgcuOrderPosition { get; set; }
        public string TntgcuFieldTextAlign { get; set; }
        public int? TntgcuMinSize { get; set; }
        public int? TntgcuMaxSize { get; set; }
        public string TntgcuAutoSize { get; set; }



        public bool isActive { get; set; }
        public string TntgcuFieldLabelDescription { get; set; }

        public TalentGridFieldsUser MapToDto(TalentGriglieCampiUtenti talentGriglieCampiUtenti)
        {
            TalentGridFieldsUser talentGridFieldsUser = new TalentGridFieldsUser();

            talentGridFieldsUser.TntgcuId = talentGriglieCampiUtenti.TntgcuId;
            talentGridFieldsUser.TntgcuFieldName = talentGriglieCampiUtenti.TntgcuTntgcNomeCampo;
            talentGridFieldsUser.TntgcuUteId = talentGriglieCampiUtenti.TntgcuUteId;
            talentGridFieldsUser.TntgcuCliId = talentGriglieCampiUtenti.TntgcuCliId;
            talentGridFieldsUser.TntgcuFieldFontName = talentGriglieCampiUtenti.TntgcuTntfontNomeFont;
            talentGridFieldsUser.TntgcuFieldFontSize = talentGriglieCampiUtenti.TntgcuTntszFontDimensione;
            talentGridFieldsUser.TntgcuOrderPosition = talentGriglieCampiUtenti.TntgcuOrdineVis;
            talentGridFieldsUser.TntgcuFieldTextAlign = talentGriglieCampiUtenti.TntgcuAllineamento;
            talentGridFieldsUser.TntgcuMinSize = talentGriglieCampiUtenti.TntgcuMinSize;
            talentGridFieldsUser.TntgcuMaxSize = talentGriglieCampiUtenti.TntgcuMaxSize;
            talentGridFieldsUser.TntgcuAutoSize = talentGriglieCampiUtenti.TntgcuAutoSize;

            return talentGridFieldsUser;
        }


        public TalentGriglieCampiUtenti MapDtoToModelObj(TalentGridFieldsUser dtoObj, TalentGriglieCampiUtenti modelObj, string actionName)
        {
            //modelObj.TntgcuId = dtoObj.TntgcuId;

            if(actionName == "insert")
            {
                modelObj.TntgcuTntgcNomeCampo = dtoObj.TntgcuFieldName;
                modelObj.TntgcuUteId = dtoObj.TntgcuUteId;
                modelObj.TntgcuCliId = dtoObj.TntgcuCliId;
            }
          
            modelObj.TntgcuTntfontNomeFont = dtoObj.TntgcuFieldFontName;
            modelObj.TntgcuTntszFontDimensione = dtoObj.TntgcuFieldFontSize;
            modelObj.TntgcuOrdineVis = dtoObj.TntgcuOrderPosition;
            modelObj.TntgcuAllineamento = dtoObj.TntgcuFieldTextAlign;
            modelObj.TntgcuMinSize = dtoObj.TntgcuMinSize;
            modelObj.TntgcuMaxSize = dtoObj.TntgcuMaxSize;
            modelObj.TntgcuAutoSize = dtoObj.TntgcuAutoSize;

            return modelObj;
        }

        public TalentGriglieCampiUtenti MapForInsert(TalentGridFieldsUser dtoObj)
        {
            TalentGriglieCampiUtenti modelObj = new TalentGriglieCampiUtenti();
            return MapDtoToModelObj(dtoObj, modelObj, "insert");
        }

        public TalentGriglieCampiUtenti MapForUpdate(TalentGridFieldsUser dtoObj, TalentGriglieCampiUtenti modelObj)
        {
            return MapDtoToModelObj(dtoObj, modelObj, "update");
        }
    }
}
