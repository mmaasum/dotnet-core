using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Talent.DataModel.Models
{
    public class SPSchedulazioneGetSchedulazioni
    {
        [Key]
        public int sched_id { get; set; }
        public string sched_rich_id { get; set; }

        public string sched_key_1 { get; set; }
        public string sched_key_2 { get; set; }
        public string sched_key_3 { get; set; }
        public string sched_key_4 { get; set; }
        public string sched_key_5 { get; set; }
        public string sched_key_6 { get; set; }

        public string sched_citta { get; set; }
    }
}
