using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class ParametriGenerali
    {
        public string NomeParametro { get; set; }
        public string Valore { get; set; }
        public string CliId { get; set; }

        public virtual Clienti Cli { get; set; }
    }
}
