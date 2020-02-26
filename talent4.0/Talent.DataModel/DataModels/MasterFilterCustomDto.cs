using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.Models;

namespace Talent.DataModel.DataModels
{
    public class MasterFilterCustomDto
    {
        public long TntfilFiltropagUteId { get; set; }
        public long TntfilFiltropagUteFiltroPagId { get; set; }
        public string TntfilFiltropagNome { get; set; }
        public string TntfilFiltropagNomeCorto { get; set; }
        public int? TntfilFiltropagUteOrdine { get; set; }
        public int? TntfilFiltropagUteButtonId { get; set; }
        public string TntfilFiltropagUteButtonLabel { get; set; }
        public string TntfilFiltropagUteUteId { get; set; }
        public string TntfilFiltropagUteDefault { get; set; }
        
        public MasterFilterCustomDto MapMasterFilterUtentiToCustomDto(TalentFiltriPagineUtenti masterFilterUtentiDmo)
        {
            MasterFilterCustomDto masterFilterCustomDto = new MasterFilterCustomDto();

            masterFilterCustomDto.TntfilFiltropagUteOrdine = masterFilterUtentiDmo.TntfilFiltropaguteOrdine;
            masterFilterCustomDto.TntfilFiltropagUteButtonId = masterFilterUtentiDmo.TntfilFiltropaguteBottone;
            masterFilterCustomDto.TntfilFiltropagUteButtonLabel = masterFilterUtentiDmo.TntfilFiltropaguteBottoneLabel;
            masterFilterCustomDto.TntfilFiltropagUteUteId = masterFilterUtentiDmo.TntfilFiltropaguteUteId;
            masterFilterCustomDto.TntfilFiltropagUteDefault = masterFilterUtentiDmo.TntfilFiltropaguteDefault;
            masterFilterCustomDto.TntfilFiltropagUteId = masterFilterUtentiDmo.TntfilFiltropaguteId;

            return masterFilterCustomDto;
        }

    }
}
