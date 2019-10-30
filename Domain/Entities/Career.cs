using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Career
    {
        [Key]
        public int idCAR { get; set; }
        public string Career_title { get; set; }
        public string Carrer_description { get; set; }
        [DataType("datetime2")]
        public DateTime? Start_date { get; set; }
        public DateTime? End_date { get; set; }
        public int MyCondidatId { get; set; }
        public Condidat MyCondidat { get; set; }
    }
}
