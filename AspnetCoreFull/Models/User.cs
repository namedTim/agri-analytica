﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreFull.Models
{
    public partial class User
    {
        public User()
        {
            Ids = new HashSet<AgriSectorType>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        [Column("date_created")]
        public DateTime DateCreated { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<AgriSectorType> Ids { get; set; }
    }
}
