using System;
using System.Collections.Generic;

namespace AspnetCoreFull.Models
{
    public partial class AnimalMedicalCondtionType
    {
        public AnimalMedicalCondtionType()
        {
            AnimalMedicalHistories = new HashSet<AnimalMedicalHistory>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<AnimalMedicalHistory> AnimalMedicalHistories { get; set; }
    }
}
