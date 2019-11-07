using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PackOffe
    {
        [Key]
        public int IdPackOffer { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public string description { get; set; }
    }
}
