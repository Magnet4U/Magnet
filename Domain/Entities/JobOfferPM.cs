using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class JobOfferPM
    {
        [Key]
        public int id_JobOfferPM { get; set; }
        public string Job_title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public int hours { get; set; }
        public DateTime Date_publication { get; set; }
        public Entreprise idEntreprise { get; set; }
    }
}
