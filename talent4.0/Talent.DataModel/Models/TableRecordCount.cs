using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Talent.DataModel.Models
{
    public class TableRecordCount
    {
        [Key]
        public int number_of_record { get; set; }
    }
}
