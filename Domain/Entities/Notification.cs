using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notification
    {
        [Key]
        public int idNotif { get; set; }
        public string contenu { get; set; }
        public User idUser { get; set; }
    }
}
