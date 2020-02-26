using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public class StaticResult
    {
        [Key]
        public int result { get; set; }
    }
}
