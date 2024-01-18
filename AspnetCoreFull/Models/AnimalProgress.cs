using System;
using System.Collections.Generic;

namespace AspnetCoreFull.Models
{
    public partial class AnimalProgress
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal? Value { get; set; }
        public int AnimalProgressTypeId { get; set; }
        public int AnimalId { get; set; }
        public int AnimalAgriSectorId { get; set; }
        public int AnimalAnimalTypeId { get; set; }

        public virtual AnimalProgressType AnimalProgressType { get; set; } = null!;
        public virtual Animal Animal { get; set; } // Navigation property

    }
}
