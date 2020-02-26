using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TestValutazione
    {
        public TestValutazione()
        {
            TestCompetenze = new HashSet<TestCompetenze>();
        }

        public string TsvalTitolo { get; set; }
        public string TsvalLink { get; set; }
        public string TsvalDescrizione { get; set; }
        public string TsvalNote { get; set; }
        public string TsvalAttivo { get; set; }
        public DateTime TsvalInsTimestamp { get; set; }
        public string TsvalInsUteId { get; set; }
        public DateTime TsvalModTimestamp { get; set; }
        public string TsvalModUteId { get; set; }
        public string TsvalCliId { get; set; }

        public virtual ICollection<TestCompetenze> TestCompetenze { get; set; }
    }
}
