using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiAzioneCategoria
    {
        public TipiAzioneCategoria()
        {
            TipiAzione = new HashSet<TipiAzione>();
            TipiAzioneCategoriaDescr = new HashSet<TipiAzioneCategoriaDescr>();
        }

        public string TipazionecatCodice { get; set; }
        public string TipazionecatDescrizione { get; set; }
        public DateTime TipazionecatInsTimestamp { get; set; }
        public DateTime TipazionecatModTimestamp { get; set; }

        public virtual ICollection<TipiAzione> TipiAzione { get; set; }
        public virtual ICollection<TipiAzioneCategoriaDescr> TipiAzioneCategoriaDescr { get; set; }
    }
}
