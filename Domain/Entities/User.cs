using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int idUser { get; set; }
        
        public string username { get; set; }
        public string password { get; set; }
       
        public string role { get; set; }
        public string image { get; set; }
       
        public Entreprise idEntreprise { get; set; }



    }
}
