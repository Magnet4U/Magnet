using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AffectationJob
    {
        [Key]
        public int id_AJ { get; set; }
        public JobOffer id_JobOffer { get; set; }
        public User idCandidate { get; set; }
    }
}
