using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RuoliUtentiDescr
    {
        public string RuolodescrRuolo { get; set; }
        public string RuolodescrDescrizione { get; set; }
        public string RuolodescrDescrizioneBreve { get; set; }
        public string RuolodescrDescrizioneEstesa { get; set; }
        public string RuolodescrLingua { get; set; }
        public DateTime RuolodescrInsTimestamp { get; set; }
        public string RuolodescrInsUteId { get; set; }
        public DateTime RuolodescrModTimestamp { get; set; }
        public string RuolodescrModUteId { get; set; }
        public string RuolodescrCliId { get; set; }

        public virtual Utenti Ruolodescr { get; set; }
        public virtual RuoliUtenti Ruolodescr1 { get; set; }
        public virtual TalentLingue RuolodescrLinguaNavigation { get; set; }
        public virtual Utenti RuolodescrNavigation { get; set; }
    }
}
