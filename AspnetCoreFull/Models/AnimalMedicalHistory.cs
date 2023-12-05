using System;
using System.Collections.Generic;

namespace AspnetCoreFull.Models
{
    public partial class AnimalMedicalHistory
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public string Date { get; set; } = null!;
        public int AnimalMedicalCondtionTypeId { get; set; }
        public int AnimalId { get; set; }
        public int AnimalAgriSectorId { get; set; }
        public int AnimalAnimalTypeId { get; set; }

        public virtual AnimalMedicalCondtionType AnimalMedicalCondtionType { get; set; } = null!;
    }
}
