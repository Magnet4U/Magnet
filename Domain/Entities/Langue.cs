using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Langue
    {
        [Key]
        public int idL { get; set; }
        public string name { get; set; }
        public string level { get; set; }
    }
}
