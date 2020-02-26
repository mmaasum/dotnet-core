using System;
using System.Collections.Generic;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public class ViewSoftSkillWsResult
    {
        // Fields of [softskills_test_ws_result] table
        public decimal SsktestresPlayField1 { get; set; }
        public decimal SsktestresPlayField2 { get; set; }
        public decimal SsktestresPlayField3 { get; set; }
        public decimal SsktestresPlayField4 { get; set; }
        // Fields of [softskills_profili] table
        public string SskprofProfilo { get; set; }
        public int SskprofIdPlay { get; set; }
        public string SskprofDescrizione { get; set; }
    }
}
