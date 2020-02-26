using System;
using System.Collections.Generic;
using System.Text;

namespace Talent.BLL.DTO
{
    public class UtentiAbilitazioniDto
    {
        public int UteabId { get; set; }
        public string UteabUteId { get; set; }
        public string TipoabilitProcedura { get; set; }
        public string UteabAbilitato { get; set; }
        public DateTime UteabInsTimestamp { get; set; }
        public string UteabInsUteId { get; set; }
        public DateTime UteabModTimestamp { get; set; }
        public string UteabModUteId { get; set; }
        public string UteabCliId { get; set; }
        
    }
}
