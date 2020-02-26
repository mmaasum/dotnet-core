using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RpSottoCommesseUtenti
    {
        public int RpscommutId { get; set; }
        public string RpscommutUteId { get; set; }
        public string RpscommutRpscommCodice { get; set; }
        public DateTime RpscommutDataInizio { get; set; }
        public DateTime RpscommutDataFine { get; set; }
        public string RpscommutNote { get; set; }
        public DateTime RpscommutInsTimestamp { get; set; }
        public string RpscommutInsUteId { get; set; }
        public DateTime RpscommutModTimestamp { get; set; }
        public string RpscommutModUteId { get; set; }
        public string RpscommutCliId { get; set; }

        public virtual Utenti Rpscommut { get; set; }
        public virtual Clienti RpscommutCli { get; set; }
        public virtual Utenti RpscommutNavigation { get; set; }
    }
}
