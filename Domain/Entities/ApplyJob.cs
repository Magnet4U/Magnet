using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApplyJob
    {
        [Key]
        public int id_ApplyJob { get; set; }
        public User idUser { get; set; }
        public JobOffer id_JobOffer { get; set; }
        public DateTime date_applu { get; set; }
    }
}
