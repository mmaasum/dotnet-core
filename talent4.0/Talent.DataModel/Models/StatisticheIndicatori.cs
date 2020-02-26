using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class StatisticheIndicatori
    {
        public string StatCodice { get; set; }
        public string StatDescrizione { get; set; }
        public string StatTipoValore { get; set; }
        public int? StatOrdineElaborazione { get; set; }
        public string StatQuery { get; set; }
        public DateTime StatDataInizioRilevazione { get; set; }
        public DateTime StatDataFineRilevazione { get; set; }
        public string StatNote { get; set; }
        public DateTime StatInsTimestamp { get; set; }
        public string StatInsUteId { get; set; }
        public DateTime StatModTimestamp { get; set; }
        public string StatModUteId { get; set; }
        public string StatCliId { get; set; }

        public virtual Utenti Stat { get; set; }
        public virtual Clienti StatCli { get; set; }
        public virtual Utenti StatNavigation { get; set; }
    }
}
