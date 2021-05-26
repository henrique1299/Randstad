using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Randstad.Models
{
    public class Convert
    {
        [Key]
        public int convertId { get; set; }
        public int id1 { get; set; }
        public int id2 { get; set; }
        public double converted { get; set; }
    }
}
