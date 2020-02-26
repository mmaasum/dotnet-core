using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Allegati
    {
        public int AllId { get; set; }
        public string AllCodice { get; set; }
        public string AllTipoAllegato { get; set; }
        public string AllNomeFile { get; set; }
        public byte[] AllAllegato { get; set; }
        public long? AllDimInKb { get; set; }
        public DateTime AllDataInserimento { get; set; }
        public string AllRiferimentoId { get; set; }
        public string AllRiferimentoTabella { get; set; }
        public int AllRiferimentoContatoreInterno { get; set; }
        public string AllTesto { get; set; }
        public DateTime AllInsTimestamp { get; set; }
        public string AllInsUteId { get; set; }
        public DateTime AllModTimestamp { get; set; }
        public string AllModUteId { get; set; }
        public string AllCliId { get; set; }

        public virtual Utenti All { get; set; }
        public virtual Clienti AllCli { get; set; }
        public virtual Utenti AllNavigation { get; set; }
    }
}
