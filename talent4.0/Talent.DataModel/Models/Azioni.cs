using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Azioni
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
        public DateTime? AzioneInizio { get; set; }
        public DateTime? AzioneFine { get; set; }
        public string AzioneLuogo { get; set; }
        public string AzioneInsUteId { get; set; }
        public DateTime AzioneInsTimestamp { get; set; }
        public string AzioneModUteId { get; set; }
        public DateTime AzioneModTimestamp { get; set; }
        public string AzioneCliId { get; set; }
        public string AzioneDettaglio04 { get; set; }
        public string AzioneDettaglio05 { get; set; }
        public string AzioneDettaglio06 { get; set; }

        public virtual Utenti Azione { get; set; }
        public virtual Richieste Azione1 { get; set; }
        public virtual Risorse Azione2 { get; set; }
        public virtual Utenti Azione3 { get; set; }
        public virtual Contatti AzioneC { get; set; }
        public virtual Clienti AzioneCli { get; set; }
        public virtual Utenti AzioneNavigation { get; set; }
        public virtual TipiAzione AzioneTipoNavigation { get; set; }
    }
}
