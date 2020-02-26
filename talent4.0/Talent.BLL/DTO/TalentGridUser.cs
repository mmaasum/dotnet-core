using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.Models;

namespace Talent.BLL.DTO
{
    public class TalentGridUser
    {
        public int TntgruId { get; set; }
        public string TntgruGridName { get; set; }
        public string TntgruUteId { get; set; }
        public string TntgruCliId { get; set; }
        public string TntgruFontName { get; set; }
        public int? TntgruFontSize { get; set; }
        public string TntgruShowRowNumber { get; set; }
        public string TntgruEvenRowsColor { get; set; }
        public string TntgruOddRowsColor { get; set; }
        public DateTime TntgruInsTimestamp { get; set; }
        public DateTime TntgruModTimestamp { get; set; }


        public TalentGridUser MapToDto(TalentGriglieUtenti talentGriglieUtenti)
        {
            TalentGridUser talentGridUser = new TalentGridUser();

            talentGridUser.TntgruId = talentGriglieUtenti.TntgruId;
            talentGridUser.TntgruGridName = talentGriglieUtenti.TntgruNomeGriglia;
            talentGridUser.TntgruUteId = talentGriglieUtenti.TntgruUteId;
            talentGridUser.TntgruCliId = talentGriglieUtenti.TntgruCliId;
            talentGridUser.TntgruFontName = talentGriglieUtenti.TntgruTntfontNomeFont;
            talentGridUser.TntgruFontSize = talentGriglieUtenti.TntgruTntszFontDimensione;
            talentGridUser.TntgruShowRowNumber = talentGriglieUtenti.TntgruMostraNumeriRiga;
            talentGridUser.TntgruEvenRowsColor = talentGriglieUtenti.TntgruColoreRighePari;
            talentGridUser.TntgruOddRowsColor = talentGriglieUtenti.TntgruColoreRigheDispari;
            talentGridUser.TntgruInsTimestamp = talentGriglieUtenti.TntgruInsTimestamp;
            talentGridUser.TntgruModTimestamp = talentGriglieUtenti.TntgruModTimestamp;
            return talentGridUser;
        }


        public TalentGriglieUtenti MapDtoToModelObj(TalentGridUser dtoObj, TalentGriglieUtenti modelObj)
        {
            modelObj.TntgruNomeGriglia = dtoObj.TntgruGridName;
            modelObj.TntgruUteId = dtoObj.TntgruUteId;
            modelObj.TntgruCliId = dtoObj.TntgruCliId;
            modelObj.TntgruTntfontNomeFont = dtoObj.TntgruFontName;
            modelObj.TntgruTntszFontDimensione = dtoObj.TntgruFontSize;
            modelObj.TntgruMostraNumeriRiga = dtoObj.TntgruShowRowNumber;
            modelObj.TntgruColoreRighePari = dtoObj.TntgruEvenRowsColor;
            modelObj.TntgruColoreRigheDispari = dtoObj.TntgruOddRowsColor;
            modelObj.TntgruInsTimestamp = dtoObj.TntgruInsTimestamp;
            modelObj.TntgruModTimestamp = dtoObj.TntgruModTimestamp;

            return modelObj;
        }


        public TalentGriglieUtenti MapForInsert(TalentGridUser dtoObj)
        {
            TalentGriglieUtenti modelObj = new TalentGriglieUtenti();
            return MapDtoToModelObj(dtoObj, modelObj);
        }

        public TalentGriglieUtenti MapForUpdate(TalentGridUser dtoObj, TalentGriglieUtenti modelObj)
        {
            return MapDtoToModelObj(dtoObj, modelObj);
        }


    }
}
