using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExperiencePro
    {
        [Key]
        public int idEP { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int nbr { get; set; }
    }
}
