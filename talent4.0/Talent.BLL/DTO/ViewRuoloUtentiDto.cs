using System;
using System.Collections.Generic;
using System.Text;

namespace Talent.BLL.DTO
{
    public class ViewRuoloUtentiDto
    {
        public string Ruolo { get; set; }
        public DateTime RuoloInsTimestamp { get; set; }
        public string RuoloInsUteId { get; set; }
        public DateTime RuoloModTimestamp { get; set; }
        public string RuoloModUteId { get; set; }
        public string RuoloCliId { get; set; }
        public string RuoloAbilitato { get; set; }
        public string RuoloSystem { get; set; }

        public string RuolodescrDescrizione { get; set; }
        public string RuolodescrDescrizioneBreve { get; set; }
        public string RuolodescrDescrizioneEstesa { get; set; }
        public string RuolodescrLingua { get; set; }

        public int? NoOfPermission { get; set; }
        public int? NoOfActiveUser { get; set; }
    }
}
