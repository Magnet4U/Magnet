using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class JobRequest
    {
        [Key]
        public int id_JobRequest { get;set; }
        public string Job_title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public User idUser { get; set; }
    }
}
