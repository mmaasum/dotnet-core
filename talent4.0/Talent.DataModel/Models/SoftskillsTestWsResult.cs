using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class SoftskillsTestWsResult
    {
        public int SsktestresId { get; set; }
        public int SsktestresTestId { get; set; }
        public string SsktestresTipoTestQuiz { get; set; }
        public int? SsktestresRisId { get; set; }
        public string SsktestresRichId { get; set; }
        public DateTime SsktestresRisDataRisposta { get; set; }
        public decimal SsktestresPlayField1 { get; set; }
        public decimal SsktestresPlayField2 { get; set; }
        public decimal SsktestresPlayField3 { get; set; }
        public decimal SsktestresPlayField4 { get; set; }
        public int SsktestresProfilo { get; set; }
        public DateTime SsktestresInsTimestamp { get; set; }
        public DateTime SsktestresModTimestamp { get; set; }
    }
}
