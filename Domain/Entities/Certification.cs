using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public  class Certification
    {
        [Key]
        public int idC { get; set; }
        [DataType("datetime2")]
        public DateTime? ObtentionDateC { get; set; }
        public DateTime? ExpirationDateC { get; set; }
    }
}
