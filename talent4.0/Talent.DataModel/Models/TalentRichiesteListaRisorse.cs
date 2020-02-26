using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentRichiesteListaRisorse
    {
        public int TrichlistId { get; set; }
        public string TrichlistRichId { get; set; }
        public int TrichlistRisId { get; set; }
        public string TrichlistStato { get; set; }
        public decimal? TrichlistVoto { get; set; }
        public DateTime? TrichlistInsTimestamp { get; set; }
        public string TrichlistInsUteId { get; set; }
        public DateTime? TrichlistModTimestamp { get; set; }
        public string TrichlistModUteId { get; set; }
        public string TrichlistCliId { get; set; }

        public virtual Utenti Trichlist { get; set; }
        public virtual Richieste Trichlist1 { get; set; }
        public virtual Risorse Trichlist2 { get; set; }
        public virtual Clienti TrichlistCli { get; set; }
        public virtual Utenti TrichlistNavigation { get; set; }
    }
}
