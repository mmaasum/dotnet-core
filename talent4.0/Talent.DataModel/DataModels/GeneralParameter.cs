using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public class GeneralParameter
    {
        [Key]
        public string ParamName { get; set; }
        public string ClientId { get; set; }
        public string ParamValue { get; set; }
    }
}
