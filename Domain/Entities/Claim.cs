﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Claim
    {
        [Key]
        public int idClaim { get; set; }
        public string subject { get; set; }
        public string  body { get; set; }
        public User idUser { get; set; }
    }
}