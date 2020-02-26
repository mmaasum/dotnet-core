using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.Models;

namespace Talent.BLL.DTO
{
    public class TalentFontNameDto
    {
        public string FontName { get; set; }


        public TalentFontNameDto MapToDto(TalentFontNomi talentFontNomi)
        {

            TalentFontNameDto talentFontName = new TalentFontNameDto();
            talentFontName.FontName = talentFontNomi.TntfontNomeFont;
            return talentFontName;
        }
        
    }
}
