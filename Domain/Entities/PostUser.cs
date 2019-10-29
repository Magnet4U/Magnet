﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PostUser
    {
        [Key]
        public int idPostU { get; set; }
        public string contenu { get; set; }
        public int like { get; set; }
        public User idUser { get; set; }
        public DateTime date_publication { get; set; }
        public List<Comment> comments { get; set; }
    }
}