using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Condidat")]
    public class Condidat : User
    {
        public string Condidat_firstname { get; set; }
        public string Condidat_lastname { get; set; }
        public int cin { get; set; }
        public int telephone { get; set; }
        public string email { get; set; }
        public List<Career> MyCareers { get; set; }
        public List<Certification> MyCertif { get; set; }
        public List <Competence> MyComp { get; set; }
        public List<Diploma> MyDip { get; set; }
        public List<Interview> MyInterview { get; set; }
    }
}
