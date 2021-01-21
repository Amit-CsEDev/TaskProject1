﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TaskProject.Bussiness.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
