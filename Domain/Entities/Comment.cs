using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment
    {
        [Key]
        public int idComment { get; set; }
        public string contenuComment { get; set; }
        public DateTime date_publication { get; set; }
 
        public PostUser idPostUser
        { get; set; }
 
 


    }
}
