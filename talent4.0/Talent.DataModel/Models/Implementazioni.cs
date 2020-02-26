using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Implementazioni
    {
        public int ImplId { get; set; }
        public DateTime ImplDataRichiesta { get; set; }
        public int ImplPriorita { get; set; }
        public string ImplRichiedenteUteId { get; set; }
        public string ImplTipo { get; set; }
        public string ImplImplprocId { get; set; }
        public string ImplDescrizione { get; set; }
        public string ImplStato { get; set; }
        public DateTime? ImplRifEmail { get; set; }
        public DateTime? ImplDataImplementazione { get; set; }
        public string ImplDescImplementazione { get; set; }
        public DateTime ImplInsTimestamp { get; set; }
        public string ImplInsUteId { get; set; }
        public DateTime ImplModTimestamp { get; set; }
        public string ImplModUteId { get; set; }
        public string ImplAssegnatarioUteId { get; set; }
        public int? ImplStimaOre { get; set; }
        public string ImplCodice { get; set; }
        public DateTime? ImplDataRilascio { get; set; }
        public string ImplInclusoInRelease { get; set; }
        public string ImplNoteSviluppo { get; set; }
        public string ImplCodiceRelease { get; set; }
        public string ImplFrequenza { get; set; }
        public string ImplPersCoinvolte { get; set; }
        public string ImplTempoPerso { get; set; }
        public int? ImplTotTempi { get; set; }
        public string ImplEsportata { get; set; }
        public string ImplCliId { get; set; }

        public virtual ImplementazioniProcedure Impl { get; set; }
        public virtual Utenti Impl1 { get; set; }
        public virtual Clienti ImplCli { get; set; }
        public virtual Utenti ImplNavigation { get; set; }
    }
}
