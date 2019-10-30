using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Competence
    {
        [Key]
        public int idComp { get; set; }
        public User idCandidate  { get; set; }
        public string descriptionCompetence { get; set; }
        public int MyCondidatId { get; set; }
        public Condidat MyCondidat { get; set; }

    }
}
