namespace Talent.BLL.DTO
{
    public class AziendeDto
    {
        public int AzId;
        public string AzRagSociale;
        public string AzDescrizione;
        public string AzIndirizzo;
        public string AzCitta;
        public string AzSitoWeb;
        public string AzEmail1;
        public string AzEmail2;
        public string AzTelefono1;
        public string AzTelefono2;
        public string AzSiglaRichiesta;
        public string AzCap;
        public string AzTipoAzienda;
        public string AzAttiva;
        public string AzCvIniziali;
        public string AzUteIdComm;
        public string AzCollLuogo1;
        public string AzCollLuogo1Indic;
        public string AzCollLuogo2;
        public string AzCollLuogo2Indic;
        public string AzCollLuogo3;
        public string AzCollLuogo3Indic;
        public string AzNote;
        public int AzPriormin;
        public int AzPriormax;
        public string AzCliId;
        public decimal? AzLocationLat;
        public decimal? AzLocationLong;
        public string AzInsUteId;
        public string AzModUteId;
    }

    public class OptimizedAziendeDto
    {
        public int AzId { get; set; }
        public string AzRagSociale { get; set; }
    }
}
