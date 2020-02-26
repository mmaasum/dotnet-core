using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Talent.DataModel.Models
{
    public class SPAuthRole
    {
        [Key]
        public string tipoabilit_procedura { get; set; }
        public string ruoltipab_ruolo { get; set; }
    }
}
