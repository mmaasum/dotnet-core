using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class SoftskillsProfili
    {
        public string SskprofProfilo { get; set; }
        public int SskprofIdPlay { get; set; }
        public string SskprofDescrizione { get; set; }
        public string SskprofLingua { get; set; }
        public DateTime SskprofInsTimestamp { get; set; }
        public DateTime SskprofModTimestamp { get; set; }
    }
}
