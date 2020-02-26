using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RisorseEsperienzeLavorative
    {
        public long RisesplavId { get; set; }
        public int RisesplavRisId { get; set; }
        public DateTime? RisesplavInizio { get; set; }
        public DateTime? RisesplavFine { get; set; }
        public string RisesplavAzienda { get; set; }
        public string RisesplavLuogo { get; set; }
        public string RisesplavSettore { get; set; }
        public string RisesplavCompetenzaCv { get; set; }
        public string RisesplavDescrizione { get; set; }
        public DateTime RisesplavInsTimestamp { get; set; }
        public string RisesplavInsUteId { get; set; }
        public DateTime RisesplavModTimestamp { get; set; }
        public string RisesplavModUteId { get; set; }
        public string RisesplavCliId { get; set; }

        public virtual Utenti Risesplav { get; set; }
        public virtual Clienti RisesplavCli { get; set; }
        public virtual Utenti RisesplavNavigation { get; set; }
    }
}
