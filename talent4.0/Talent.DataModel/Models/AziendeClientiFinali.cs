using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class AziendeClientiFinali
    {
        public int ClifinId { get; set; }
        public int ClifinAzId { get; set; }
        public string ClifinLuogoLavoro { get; set; }
        public string ClifinIndirizzo { get; set; }
        public decimal? ClifinLocationLat { get; set; }
        public decimal? ClifinLocationLong { get; set; }
        public DateTime ClifinInsTimestamp { get; set; }
        public string ClifinInsUteId { get; set; }
        public DateTime ClifinModTimestamp { get; set; }
        public string ClifinModUteId { get; set; }
        public string ClifinNomeClienteFinale { get; set; }
        public string ClifinRaggMezziPubblici { get; set; }
        public string ClifinCliId { get; set; }

        public virtual Aziende Clifin { get; set; }
    }
}
