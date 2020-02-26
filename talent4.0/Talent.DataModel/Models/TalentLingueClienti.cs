using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentLingueClienti
    {
        public string LngcliCliId { get; set; }
        public string LngcliLingua { get; set; }
        public string LngcliCv { get; set; }
        public string LngcliUi { get; set; }
        public string LngcliDefault { get; set; }
        public DateTime LngcliInsTimestamp { get; set; }
        public DateTime LngcliModTimestamp { get; set; }

        public virtual Clienti LngcliCli { get; set; }
        public virtual TalentLingue LngcliLinguaNavigation { get; set; }
    }
}
