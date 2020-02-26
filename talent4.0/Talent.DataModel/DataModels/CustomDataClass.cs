using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public class CustomDataClass
    {
        [Key]
        public string CustomDataString { get; set; }
    }
}
