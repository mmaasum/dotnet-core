using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.Models;

namespace Talent.BLL.DTO
{
    public class MasterFilterDto
    {
        public long TntfilFiltropagId { get; set; }
        public string TntfilFiltropagCliId { get; set; }
        public string TntfilFiltropagPaginaCodice { get; set; }
        public string TntfilFiltropagNome { get; set; }
        public string TntfilFiltropagNomeCorto { get; set; }
        public string TntfilFiltropagPulisciPrecedenti { get; set; }
        public string TntfilFiltropagPubblico { get; set; }
        public string TntfilFiltropagDescrizione { get; set; }
        public string TntfilFiltropagSelect1FiltropagcampoCodice { get; set; }
        public string TntfilFiltropagSelect1Filtrocond { get; set; }
        public string TntfilFiltropagSelect1FiltrocondDatafissa { get; set; }
        public string TntfilFiltropagSelect1Valore { get; set; }
        public string TntfilFiltropagSelect2FiltropagcampoCodice { get; set; }
        public string TntfilFiltropagSelect2Filtrocond { get; set; }
        public string TntfilFiltropagSelect2FiltrocondDatafissa { get; set; }
        public string TntfilFiltropagSelect2Valore { get; set; }
        public string TntfilFiltropagSelect3FiltropagcampoCodice { get; set; }
        public string TntfilFiltropagSelect3Filtrocond { get; set; }
        public string TntfilFiltropagSelect3FiltrocondDatafissa { get; set; }
        public string TntfilFiltropagSelect3Valore { get; set; }
        public string TntfilFiltropagOrder1FiltropagcampoCodice { get; set; }
        public string TntfilFiltropagOrder1Ascending { get; set; }
        public string TntfilFiltropagOrder2FiltropagcampoCodice { get; set; }
        public string TntfilFiltropagOrder2Ascending { get; set; }
        public string TntfilFiltropagQuery { get; set; }
        public string TntfilFiltropagInternalRepresentation { get; set; }
        public DateTime? TntfilFiltropagInsTimestamp { get; set; }
        public string TntfilFiltropagInsUteId { get; set; }
        public DateTime? TntfilFiltropagModTimestamp { get; set; }
        public string TntfilFiltropagModUteId { get; set; }


        public string TntfilFiltropagUteDefault { get; set; }
        public int TntfilFiltropagUteOrdine { get; set; }
        public int TntfilFiltropagUteButtonId { get; set; }
        public string TntfilFiltropagUteButtonLabel { get; set; }
        public long TntfilFiltropagUteId { get; set; }

      
        public MasterFilterDto MapTalentFiltriPagineCampiToDto(TalentFiltriPagine talentFiltriPagine)
        {

            MasterFilterDto masterFilterDto = new MasterFilterDto();

            masterFilterDto.TntfilFiltropagId = talentFiltriPagine.TntfilFiltropagId;
            masterFilterDto.TntfilFiltropagCliId = talentFiltriPagine.TntfilFiltropagCliId;
            masterFilterDto.TntfilFiltropagPaginaCodice = talentFiltriPagine.TntfilFiltropagPaginaCodice;
            masterFilterDto.TntfilFiltropagNome = talentFiltriPagine.TntfilFiltropagNome;
            masterFilterDto.TntfilFiltropagNomeCorto = talentFiltriPagine.TntfilFiltropagNomeCorto;
            masterFilterDto.TntfilFiltropagPulisciPrecedenti = talentFiltriPagine.TntfilFiltropagPulisciPrecedenti;
            masterFilterDto.TntfilFiltropagPubblico = talentFiltriPagine.TntfilFiltropagPubblico;
            masterFilterDto.TntfilFiltropagDescrizione = talentFiltriPagine.TntfilFiltropagDescrizione;
            masterFilterDto.TntfilFiltropagSelect1FiltropagcampoCodice = talentFiltriPagine.TntfilFiltropagSelect1FiltropagcampoCodice;
            masterFilterDto.TntfilFiltropagSelect1Filtrocond = talentFiltriPagine.TntfilFiltropagSelect1Filtrocond;
            masterFilterDto.TntfilFiltropagSelect1FiltrocondDatafissa = talentFiltriPagine.TntfilFiltropagSelect1FiltrocondDatafissa;
            masterFilterDto.TntfilFiltropagSelect1Valore = talentFiltriPagine.TntfilFiltropagSelect1Valore;
            masterFilterDto.TntfilFiltropagSelect2FiltropagcampoCodice = talentFiltriPagine.TntfilFiltropagSelect2FiltropagcampoCodice;
            masterFilterDto.TntfilFiltropagSelect2Filtrocond = talentFiltriPagine.TntfilFiltropagSelect2Filtrocond;
            masterFilterDto.TntfilFiltropagSelect2FiltrocondDatafissa = talentFiltriPagine.TntfilFiltropagSelect2FiltrocondDatafissa;
            masterFilterDto.TntfilFiltropagSelect2Valore = talentFiltriPagine.TntfilFiltropagSelect2Valore;
            masterFilterDto.TntfilFiltropagSelect3FiltropagcampoCodice = talentFiltriPagine.TntfilFiltropagSelect3FiltropagcampoCodice;
            masterFilterDto.TntfilFiltropagSelect3Filtrocond = talentFiltriPagine.TntfilFiltropagSelect3Filtrocond;
            masterFilterDto.TntfilFiltropagSelect3FiltrocondDatafissa = talentFiltriPagine.TntfilFiltropagSelect3FiltrocondDatafissa;
            masterFilterDto.TntfilFiltropagSelect3Valore = talentFiltriPagine.TntfilFiltropagSelect3Valore;
            masterFilterDto.TntfilFiltropagOrder1FiltropagcampoCodice = talentFiltriPagine.TntfilFiltropagOrder1FiltropagcampoCodice;
            masterFilterDto.TntfilFiltropagOrder1Ascending = talentFiltriPagine.TntfilFiltropagOrder1Ascending;
            masterFilterDto.TntfilFiltropagOrder2FiltropagcampoCodice = talentFiltriPagine.TntfilFiltropagOrder2FiltropagcampoCodice;
            masterFilterDto.TntfilFiltropagOrder2Ascending = talentFiltriPagine.TntfilFiltropagOrder2Ascending;
            masterFilterDto.TntfilFiltropagQuery = talentFiltriPagine.TntfilFiltropagQuery;
            masterFilterDto.TntfilFiltropagInternalRepresentation = talentFiltriPagine.TntfilFiltropagInternalRepresentation;
            masterFilterDto.TntfilFiltropagInsTimestamp = talentFiltriPagine.TntfilFiltropagInsTimestamp;
            masterFilterDto.TntfilFiltropagInsUteId = talentFiltriPagine.TntfilFiltropagInsUteId;
            masterFilterDto.TntfilFiltropagModTimestamp = talentFiltriPagine.TntfilFiltropagModTimestamp;
            masterFilterDto.TntfilFiltropagModUteId = talentFiltriPagine.TntfilFiltropagModUteId;

            return masterFilterDto;
        }



        public TalentFiltriPagine MapDtoToTalentFiltriPagineCampi(MasterFilterDto masterFilterDto, TalentFiltriPagine talentFiltriPagine)
        {
            talentFiltriPagine.TntfilFiltropagId = masterFilterDto.TntfilFiltropagId;
            talentFiltriPagine.TntfilFiltropagCliId = masterFilterDto.TntfilFiltropagCliId;
            talentFiltriPagine.TntfilFiltropagPaginaCodice = masterFilterDto.TntfilFiltropagPaginaCodice;
            talentFiltriPagine.TntfilFiltropagNome = masterFilterDto.TntfilFiltropagNome;
            talentFiltriPagine.TntfilFiltropagNomeCorto = masterFilterDto.TntfilFiltropagNomeCorto;
            talentFiltriPagine.TntfilFiltropagPulisciPrecedenti = masterFilterDto.TntfilFiltropagPulisciPrecedenti;
            talentFiltriPagine.TntfilFiltropagPubblico = masterFilterDto.TntfilFiltropagPubblico;
            talentFiltriPagine.TntfilFiltropagDescrizione = masterFilterDto.TntfilFiltropagDescrizione;
            talentFiltriPagine.TntfilFiltropagSelect1FiltropagcampoCodice = masterFilterDto.TntfilFiltropagSelect1FiltropagcampoCodice;
            talentFiltriPagine.TntfilFiltropagSelect1Filtrocond = masterFilterDto.TntfilFiltropagSelect1Filtrocond;
            talentFiltriPagine.TntfilFiltropagSelect1FiltrocondDatafissa = masterFilterDto.TntfilFiltropagSelect1FiltrocondDatafissa;
            talentFiltriPagine.TntfilFiltropagSelect1Valore = masterFilterDto.TntfilFiltropagSelect1Valore;
            talentFiltriPagine.TntfilFiltropagSelect2FiltropagcampoCodice = masterFilterDto.TntfilFiltropagSelect2FiltropagcampoCodice;
            talentFiltriPagine.TntfilFiltropagSelect2Filtrocond = masterFilterDto.TntfilFiltropagSelect2Filtrocond;
            talentFiltriPagine.TntfilFiltropagSelect2FiltrocondDatafissa = masterFilterDto.TntfilFiltropagSelect2FiltrocondDatafissa;
            talentFiltriPagine.TntfilFiltropagSelect2Valore = masterFilterDto.TntfilFiltropagSelect2Valore;
            talentFiltriPagine.TntfilFiltropagSelect3FiltropagcampoCodice = masterFilterDto.TntfilFiltropagSelect3FiltropagcampoCodice;
            talentFiltriPagine.TntfilFiltropagSelect3Filtrocond = masterFilterDto.TntfilFiltropagSelect3Filtrocond;
            talentFiltriPagine.TntfilFiltropagSelect3FiltrocondDatafissa = masterFilterDto.TntfilFiltropagSelect3FiltrocondDatafissa;
            talentFiltriPagine.TntfilFiltropagSelect3Valore = masterFilterDto.TntfilFiltropagSelect3Valore;
            talentFiltriPagine.TntfilFiltropagOrder1FiltropagcampoCodice = masterFilterDto.TntfilFiltropagOrder1FiltropagcampoCodice;
            talentFiltriPagine.TntfilFiltropagOrder1Ascending = masterFilterDto.TntfilFiltropagOrder1Ascending;
            talentFiltriPagine.TntfilFiltropagOrder2FiltropagcampoCodice = masterFilterDto.TntfilFiltropagOrder2FiltropagcampoCodice;
            talentFiltriPagine.TntfilFiltropagOrder2Ascending = masterFilterDto.TntfilFiltropagOrder2Ascending;
            talentFiltriPagine.TntfilFiltropagQuery = masterFilterDto.TntfilFiltropagQuery;
            talentFiltriPagine.TntfilFiltropagInternalRepresentation = masterFilterDto.TntfilFiltropagInternalRepresentation;
            //talentFiltriPagine.TntfilFiltropagInsTimestamp = masterFilterDto.TntfilFiltropagInsTimestamp;
            talentFiltriPagine.TntfilFiltropagInsUteId = masterFilterDto.TntfilFiltropagInsUteId;
            //talentFiltriPagine.TntfilFiltropagModTimestamp = masterFilterDto.TntfilFiltropagModTimestamp;
            talentFiltriPagine.TntfilFiltropagModUteId = masterFilterDto.TntfilFiltropagModUteId;

            return talentFiltriPagine;
        }

        public TalentFiltriPagine MapForInsert(MasterFilterDto masterFilterDto)
        {
            TalentFiltriPagine talentFiltriPagine = new TalentFiltriPagine();
            return MapDtoToTalentFiltriPagineCampi(masterFilterDto, talentFiltriPagine);
        }

        public TalentFiltriPagine MapForUpdate(MasterFilterDto masterFilterDto, TalentFiltriPagine talentFiltriPagine)
        {
            return MapDtoToTalentFiltriPagineCampi(masterFilterDto, talentFiltriPagine);
        }

    }
}
