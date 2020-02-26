using Microsoft.AspNetCore.Http;
using System;

namespace Talent.BLL.DTO
{
    public class ContattiDto
    {
        public int ContId;
        public string ContTitolo ;
        public string ContAzSociale ;
        public string ContNome ;
        public string ContCognome ;
        public int? ContAzId ;
        public string ContPosizione ;
        public string ContCitta ;
        public string ContEmail1 ;
        public string ContEmail2 ;
        public string ContTelefono1 ;
        public string ContTelefono2 ;
        public string ContRifUteId ;
        public string ContNote ;
        public DateTime? ContInsTimestamp ;
        public string ContInsUteId ;
        public DateTime? ContModTimestamp ;
        public string ContModUteId ;
        public string ContCvIniziali ;
        public string ContTipoContatto ;
        public string ContAttivo ;
        public string ContDescrizione ;
        public int? ContPriormin ;
        public int? ContPriormax ;
        public string ContOrari1Giorno ;
        public string ContOrari1Inizio ;
        public string ContOrari1Fine ;
        public string ContOrari2Giorno ;
        public string ContOrari2Inizio ;
        public string ContOrari2Fine ;
        public string ContOrari3Giorno ;
        public string ContOrari3Inizio ;
        public string ContOrari3Fine ;
        public string ContOrari4Giorno ;
        public string ContOrari4Inizio ;
        public string ContOrari4Fine ;
        public string ContOrari5Giorno ;
        public string ContOrari5Inizio ;
        public string ContOrari5Fine ;
        public string ContInvioCvNote ;
        public string ContCliId ;
        public int? ContAzsedeId ;

        public string AzRagSociale ;
        public string AzsedeDescr ;
        public string UteNome ;
    }

    public class TipiContattoDto
    {
        public string TipoContatto;
        public string TipcontCliId ;
    }

    public class MailContattiDto
    {
        public string Email ;
        public string Body ;
        public IFormFile Attachment ;
    }

    public class ContattiOptimizedDto
    {
        public int ContId;
        public string ContNome ;
        public string ContCognome ;
    }
}
