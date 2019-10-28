using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Interview
    {
        [Key]
        public int idInterview { get; set; }
        public User idUSer { get; set; }
        public DateTime DateInterview { get; set; }
        public string lieu { get; set; }

    }
}
