using System;
using System.Collections.Generic;

namespace AspnetCoreFull.Models
{
    public partial class AgriSectorType
    {
        public AgriSectorType()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? AspUserId { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
