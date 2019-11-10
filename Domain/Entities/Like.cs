using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public  class Like
    {
        [Key]
        public int idlike { get; set; }
        public int likes { get; set; }
        public int Dislikes { get; set; }
        public PostUser idPostUser { get; set; }
        public User idUser { get; set; }
    }
}
