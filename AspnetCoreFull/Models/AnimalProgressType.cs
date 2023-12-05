using System;
using System.Collections.Generic;

namespace AspnetCoreFull.Models
{
    public partial class AnimalProgressType
    {
        public AnimalProgressType()
        {
            AnimalProgresses = new HashSet<AnimalProgress>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<AnimalProgress> AnimalProgresses { get; set; }
    }
}
