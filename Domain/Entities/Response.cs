using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Response
    {
        [Key]
        public int IdResponse { get; set; }
        public DateTime ResponseDate { get; set; }
        public User user { get; set; }
        public string Content { get; set; }
    }
}
