using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RaConfigurazioni
    {
        public int RacId { get; set; }
        public string RacFrequenza { get; set; }
        public string RacOra { get; set; }
        public string RacGiorno { get; set; }
        public string RacSqlType { get; set; }
        public string RacSql { get; set; }
        public string RacParametri { get; set; }
        public string RacOggetto { get; set; }
        public string RacNote { get; set; }
        public string RacEmail { get; set; }
        public string RacEmailException { get; set; }
        public string RacEnable { get; set; }
        public string RacUltimaEsecuzione { get; set; }
        public string RacEsito { get; set; }
        public string RacProssimaEsecuzione { get; set; }
        public string RacStyleTable { get; set; }
        public string RacStyleTableHeader { get; set; }
        public string RacStyleTableText { get; set; }
        public string RacStyleText { get; set; }
        public DateTime RacInsTimestamp { get; set; }
        public string RacInsUteId { get; set; }
        public DateTime RacModTimestamp { get; set; }
        public string RacModUteId { get; set; }
        public string RacEmailCcn { get; set; }
        public string RacEmailCc { get; set; }
        public DateTime? RacDataFine { get; set; }
        public string RacRacatCodice { get; set; }
        public string RacCliId { get; set; }

        public virtual Utenti Rac { get; set; }
        public virtual Clienti RacCli { get; set; }
        public virtual Utenti RacNavigation { get; set; }
    }
}
