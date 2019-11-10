using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Niveau
    {
        [Key]
        public int idNiveau { get; set; }
        public float score { get; set; }
        public int idQuestion { get; set; }
        public Question question { get; set; }
    }
}
