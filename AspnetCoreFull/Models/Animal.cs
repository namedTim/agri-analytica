using System;
using System.Collections.Generic;

namespace AspnetCoreFull.Models
{
    public partial class Animal
    {
        public int Id { get; set; }
        public int AgriSectorId { get; set; }
        public string? EarTag { get; set; }
        public DateTime Birth { get; set; }
        public DateTime? Death { get; set; }
        public string? Description { get; set; }
        public decimal BoughtPrice { get; set; }
        public decimal SoldPrice { get; set; }
        public int AnimalTypeId { get; set; }
        public int GenderId { get; set; }
        public int? ParentFemaleId { get; set; }
        public int? ParentMaleId { get; set; }

        public virtual AnimalType AnimalType { get; set; } = null!;
        public virtual Gender Gender { get; set; } = null!;
    }
}
