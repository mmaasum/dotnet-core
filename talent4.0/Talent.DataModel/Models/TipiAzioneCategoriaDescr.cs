using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiAzioneCategoriaDescr
    {
        public string TpazcatdescrTipazionecatCodice { get; set; }
        public string TpazcatdescrLingua { get; set; }
        public string TpazcatdescrDescrizione { get; set; }
        public DateTime TpazcatdescrInsTimestamp { get; set; }
        public DateTime TpazcatdescrModTimestamp { get; set; }

        public virtual TipiAzioneCategoria TpazcatdescrTipazionecatCodiceNavigation { get; set; }
    }
}
