using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Entreprise
    {
        [Key]
        public int idEntreprise { get; set; }
        public int nbEmployee { get; set; }
        public string name { get; set; }
        public int telephone { get; set; }
        public string introduction { get; set; }
        public List<Event>Events { get; set; }
        public List<JobOffer> joboffers { get; set; }


    }
}
