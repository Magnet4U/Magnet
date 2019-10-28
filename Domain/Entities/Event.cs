using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
        [Key]
        public int idEvent { get; set; }
        public Entreprise idEntreprise { get; set; }
    }
}
