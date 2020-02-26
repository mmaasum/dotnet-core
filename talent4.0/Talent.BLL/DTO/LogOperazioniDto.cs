using System;

namespace Talent.BLL.DTO
{
    public class LogOperazioniDto
    {
        public DateTime LogTimestamp;
        public string LogUteId;
        public string LogDescr;
        public string LogDettaglio;
        public string LogAccAccountEmail;
        public string LogCliId;

        public LogOperazioniDto()
        {

        }

        public LogOperazioniDto(string uteId, string clientId, string desc, string details)
        {
            LogUteId = uteId;
            LogDescr = desc;
            LogDettaglio = details;
            LogCliId = clientId;
            LogTimestamp = DateTime.Now;
        }
    }
    
}
