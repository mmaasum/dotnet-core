using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.Models;

namespace Talent.BLL.DTO
{
    public class MasterGridFieldDto
    {
        public string TntgcNomeCampo { get; set; }
        public string TntgcTntgridNomeGriglia { get; set; }
        public string TntgcDescrizione { get; set; }
        public string TntgcNomeCampoDb { get; set; }
        public DateTime TntgcInsTimestamp { get; set; }
        public DateTime TntgcModTimestamp { get; set; }


        public MasterGridFieldDto MapToDto(TalentGriglieCampi talentGriglieCampi)
        {
            MasterGridFieldDto masterFilterFieldsDto = new MasterGridFieldDto();

            masterFilterFieldsDto.TntgcNomeCampo = talentGriglieCampi.TntgcNomeCampo;
            masterFilterFieldsDto.TntgcTntgridNomeGriglia = talentGriglieCampi.TntgcTntgridNomeGriglia;
            masterFilterFieldsDto.TntgcDescrizione = talentGriglieCampi.TntgcDescrizione;
            masterFilterFieldsDto.TntgcNomeCampoDb = talentGriglieCampi.TntgcNomeCampoDb;
            masterFilterFieldsDto.TntgcInsTimestamp = talentGriglieCampi.TntgcInsTimestamp;
            masterFilterFieldsDto.TntgcModTimestamp = talentGriglieCampi.TntgcModTimestamp;
            return masterFilterFieldsDto;
        }


        public TalentGridFieldsUser MapGridFieldToGridFieldUserDto(TalentGriglieCampi talentGriglieCampi)
        {
            TalentGridFieldsUser talentGridFieldsUser = new TalentGridFieldsUser();

            //talentGridFieldsUser.TntgcuId = talentGriglieCampiUtenti.TntgcuId;
            talentGridFieldsUser.TntgcuFieldName = talentGriglieCampi.TntgcNomeCampo;
            //talentGridFieldsUser.TntgcuUteId = talentGriglieCampiUtenti.TntgcuUteId;
            //talentGridFieldsUser.TntgcuCliId = talentGriglieCampiUtenti.TntgcuCliId;
            talentGridFieldsUser.TntgcuFieldFontName = "Arial";
            talentGridFieldsUser.TntgcuFieldFontSize = 10;
            talentGridFieldsUser.TntgcuOrderPosition = 0;
            talentGridFieldsUser.TntgcuFieldTextAlign = "Left";
            talentGridFieldsUser.TntgcuMinSize = 100;
            talentGridFieldsUser.TntgcuMaxSize = 1000;
            talentGridFieldsUser.TntgcuAutoSize = "S";

            talentGridFieldsUser.TntgcuFieldLabelDescription = talentGriglieCampi.TntgcDescrizione;

            return talentGridFieldsUser;
        }
    }
}
