using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class CompetenzeTipi
    {
        public string CompetenzaTipo { get; set; }
        public string ComptipLabelDefault { get; set; }
        public string ComptipCompetenzaTipoDettaglio { get; set; }
        public string ComptipTipoDettaglioObb { get; set; }
        public string ComptipSeniorityDefault { get; set; }
        public string ComptipSeniorityObb { get; set; }
        public string ComptipRichSigla { get; set; }
        public string ComptipCliId { get; set; }

        public virtual Clienti ComptipCli { get; set; }
    }
}
