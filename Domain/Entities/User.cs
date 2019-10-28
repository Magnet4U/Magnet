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
        public int cin { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int telephone { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string experience_prof { get; set; }
        public string formation { get; set; }
        public string certification { get; set; }
        public List<Competence> competence { get; set; }
        public string liste_activite { get; set; }
        public Entreprise idEntreprise { get; set; }



    }
}
