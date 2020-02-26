using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RpRapportini
    {
        public int RprappId { get; set; }
        public string RprappUteId { get; set; }
        public DateTime RprappMese { get; set; }
        public string RprappConsolidato { get; set; }
        public string RprappNote { get; set; }
        public DateTime RprappInsTimestamp { get; set; }
        public string RprappInsUteId { get; set; }
        public DateTime RprappModTimestamp { get; set; }
        public string RprappModUteId { get; set; }
        public string RprappCliId { get; set; }

        public virtual Utenti Rprapp { get; set; }
        public virtual Clienti RprappCli { get; set; }
        public virtual Utenti RprappNavigation { get; set; }
    }
}
