using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Quiz
    {
        [Key]
        public int  idQuiz { get; set; }
        public User idUser { get; set; }
        public int score { get; set; }
    }
}
