using System;

namespace Talent.BLL.DTO
{
    public class AziendeClientiFinaleDto
    {
        public int ClifinId;
        public int ClifinAzId;
        public string ClifinLuogoLavoro;
        public string ClifinIndirizzo;
        public decimal? ClifinLocationLat;
        public decimal? ClifinLocationLong;
        public DateTime ClifinInsTimestamp;
        public string ClifinInsUteId;
        public DateTime ClifinModTimestamp;
        public string ClifinModUteId;
        public string ClifinNomeClienteFinale;
        public string ClifinRaggMezziPubblici;
        public string ClifinCliId;
        public string AzRagSociale;
    }


    public class AziendeClientiFinaleOptimizedDto
    {
        public int ClifinId;
        public string ClifinNomeClienteFinale;
    }

   

}
