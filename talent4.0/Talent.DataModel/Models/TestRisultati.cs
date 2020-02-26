using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TestRisultati
    {
        public int TsrisId { get; set; }
        public int TsrisRisId { get; set; }
        public string TsrisTitoloTest { get; set; }
        public DateTime TsrisDataCompletamento { get; set; }
        public int TsrisScore { get; set; }
        public int? TsrisRisposteCorrette { get; set; }
        public int? TsrisMinutiTrascorsi { get; set; }
        public string TsrisTestLink { get; set; }
        public DateTime TsrisInsTimestamp { get; set; }
        public DateTime TsrisModTimestamp { get; set; }
    }
}
