using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class UnipiRisorseAnnotate
    {
        public int RisId { get; set; }
        public string RisCvTestoAnnotato { get; set; }
        public string RisCvTestoLingua { get; set; }
        public DateTime RisCvTestoDataAnnotazione { get; set; }
    }
}
