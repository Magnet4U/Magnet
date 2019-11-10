using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Domain.Entities
{
    public class PostUser
    {
        [Key]
        public int idPostU { get; set; }
        public string Picture { get; set; }
        public string contenu { get; set; }

        public User idUser { get; set; }
        public DateTime date_publication { get; set; }
        public List<Comment> comments { get; set; }
        public List<Like> lik { get; set; }
    }
}
