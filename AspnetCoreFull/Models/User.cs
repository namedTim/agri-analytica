using System;
using System.Collections.Generic;

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
        public DateTime? DateCreated { get; set; }
        public string? Password { get; set; }
        public string? AspUserId { get; set; }

        public virtual ICollection<AgriSectorType> Ids { get; set; }
    }
}
