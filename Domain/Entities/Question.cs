using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question
    {
        [Key]
        public int idQuestion { get; set; }
        public int GroupingId { get; set; }
        public string description { get; set; }
        public string rep1 { get; set; }
        public string rep2 { get; set; }
        public string rep3 { get; set; }
        public string correctAnswer { get; set; }





    }
}
