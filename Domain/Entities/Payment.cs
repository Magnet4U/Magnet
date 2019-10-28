using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Payment
    {
        [Key]
        public int idPayment { get; set; }
        public float price { get; set; }
        public User idUser { get; set; }
    }
}
