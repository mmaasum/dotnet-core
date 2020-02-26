using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RisorseCvSchemi
    {
        public long RiscvschemId { get; set; }
        public int RiscvschemRisId { get; set; }
        public string RiscvschemCvschemCodice { get; set; }
        public string RiscvschemCvschemideId { get; set; }
        public string RiscvschemRisCvTesto { get; set; }
        public string RiscvschemNote { get; set; }
        public DateTime RiscvschemInsTimestamp { get; set; }
        public string RiscvschemInsUteId { get; set; }
        public DateTime RiscvschemModTimestamp { get; set; }
        public string RiscvschemModUteId { get; set; }
        public string RiscvschemCliId { get; set; }

        public virtual Utenti Riscvschem { get; set; }
        public virtual Risorse Riscvschem1 { get; set; }
        public virtual CvSchemi RiscvschemC { get; set; }
        public virtual Clienti RiscvschemCli { get; set; }
        public virtual Utenti RiscvschemNavigation { get; set; }
    }
}
