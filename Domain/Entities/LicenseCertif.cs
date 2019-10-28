using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public  class LicenseCertif
    {
        [Key]
        public int idLC { get; set; }
        public string name { get; set; }
        public int nbr { get; set; }
    }
}
