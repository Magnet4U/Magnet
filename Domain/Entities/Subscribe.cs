using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public  class Subscribe
    {
        [Key]
        public int numSub { get; set; }
        public int id_Subscriber { get; set; }
        public int id_subscription { get; set; }
    }
}
