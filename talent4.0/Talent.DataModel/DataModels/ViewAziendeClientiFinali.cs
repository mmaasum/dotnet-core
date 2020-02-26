using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public class ViewAziendeClientiFinali
    {
        [Key]
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
        public string AzRagSociale { get; set; }


    }
}
