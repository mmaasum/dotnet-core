using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RichiesteListaRisorse
    {
        public int RichlistId { get; set; }
        public string RichlistRichId { get; set; }
        public int RichlistRisId { get; set; }
        public string RichlistUltimaSelUteId { get; set; }
        public DateTime RichlistUltimaSelData { get; set; }
        public long RichlistAttinenzaTot { get; set; }
        public int RichlistNumRicPres { get; set; }
        public string RichlistStato { get; set; }
        public decimal? RichlistVoto { get; set; }
        public string RichlistVotoUteId { get; set; }
        public string RichlistNote { get; set; }
        public string RichlistNoteEstrazionePositive { get; set; }
        public string RichlistNoteEstrazioneNegative { get; set; }
        public DateTime? RichlistInsTimestamp { get; set; }
        public string RichlistInsUteId { get; set; }
        public DateTime? RichlistModTimestamp { get; set; }
        public string RichlistModUteId { get; set; }
        public int? RichlistPosizioneOrdinale { get; set; }
        public string RichlistMotivazioneScarto { get; set; }
        public string RichlistCliId { get; set; }

        public virtual Utenti Richlist { get; set; }
        public virtual Richieste Richlist1 { get; set; }
        public virtual Risorse Richlist2 { get; set; }
        public virtual Utenti Richlist3 { get; set; }
        public virtual Utenti Richlist4 { get; set; }
        public virtual Clienti RichlistCli { get; set; }
        public virtual Utenti RichlistNavigation { get; set; }
        public virtual StatiRichiesteListaRisorse RichlistStatoNavigation { get; set; }
    }
}
