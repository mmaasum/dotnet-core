using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.Models;

namespace Talent.BLL.DTO
{
    public class TalentFontSizeDto
    {
        public int TntszFontDimensione { get; set; }


        public TalentFontSizeDto MapToDto(TalentFontDimensioni talentFontDimensioni)
        {
            TalentFontSizeDto talentFontSizeDto = new TalentFontSizeDto();
            talentFontSizeDto.TntszFontDimensione = talentFontDimensioni.TntszFontDimensione;
            return talentFontSizeDto;
        }
    }
}
