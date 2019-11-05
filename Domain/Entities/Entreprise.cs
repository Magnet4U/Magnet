using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public partial class Entreprise
    {
        [Key]
        public int idEntreprise { get; set; }
        
        public string name { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public bool IsEmailVerified { get; set; }
        public System.Guid ActivationCode { get; set; }
        public int telephone { get; set; }
       
        public string introduction { get; set; }
        public int nbEmployee { get; set; }
        public string image { get; set; }
        public List<JobOffer> joboffers { get; set; }
        public List<User> listuser { get; set; }


    }
}
