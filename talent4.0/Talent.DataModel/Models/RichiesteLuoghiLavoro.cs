using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RichiesteLuoghiLavoro
    {
        public int RichllavId { get; set; }
        public string RichllavRichId { get; set; }
        public int RichllavAzId { get; set; }
        public string RichllavCliId { get; set; }
        public int? RichllavAzsedeId { get; set; }
        public int? RichllavClifinId { get; set; }

        public virtual Aziende Richllav { get; set; }
        public virtual Richieste RichllavNavigation { get; set; }
    }
}
