using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Diploma
    {
        [Key]
        public int idD { get; set; }
        [DataType("datetime2")]
        public DateTime ObtentionDate { get; set; }
        public string DegreeTitle { get; set; }
    }
}
