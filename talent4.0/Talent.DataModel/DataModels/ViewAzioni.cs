using System;
using System.Collections.Generic;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public class ViewAzioni
    {
        public int AzioneId { get; set; }
        public string AzioneUteId { get; set; }
        public int? AzioneRisId { get; set; }
        public int? AzioneContId { get; set; }
        public string AzioneRichId { get; set; }
        public string AzioneTipo { get; set; }
        public string AzioneDescrizione { get; set; }
        public string AzioneDettaglio01 { get; set; }
        public string AzioneDettaglio02 { get; set; }
        public string AzioneDettaglio03 { get; set; }
        public string AzioneDettaglio04 { get; set; }
        public string AzioneDettaglio05 { get; set; }
        public string AzioneDettaglio06 { get; set; }

        public DateTime? AzioneInizio { get; set; }
        public DateTime? AzioneFine { get; set; }
        public string AzioneLuogo { get; set; }
        public string AzioneInsUteId { get; set; }
        public DateTime AzioneInsTimestamp { get; set; }
        public string AzioneModUteId { get; set; }
        public DateTime AzioneModTimestamp { get; set; }
        public string AzioneCliId { get; set; }

        public string RisNome { get; set; }
        public string RisCognome { get; set; }
        public string RichDescrizione { get; set; }
        public string UteNome { get; set; }
        public string ContNome { get; set; }
        public string ContCognome { get; set; }
        public string AzRagSociale { get; set; }


        public string tipi_azione_categoria_descr_OF_tpazcatdescr_descrizione { get; set; }
        public string tipi_azione_descr_OF_tpazdescr_descrizione { get; set; }
        public string richieste_OF_rich_citta { get; set; }
        public string richieste_OF_rich_comp_principale { get; set; }

        

        //public string AzRagSociale { get; set; }


    }
}
