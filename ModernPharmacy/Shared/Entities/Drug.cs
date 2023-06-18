using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernPharmacy.Shared.Entities
{
    public class Drug
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public virtual List<Substance> Substances { get; set; }
        public int? NumberOfTablets { get; set; }
        [Range(0, 10000000, ErrorMessage = $"The field {nameof(MilligramsPerTablets)} must be greater than 0")]
        public int? MilligramsPerTablets { get; set; }
        [Range(0, 10000000, ErrorMessage = $"The field {nameof(MilligramsForTheWholeDrug)} must be greater than 0")]
        public int? MilligramsForTheWholeDrug { get; set; }
        public bool LumpSumDrug { get; set; } = true;
        public bool PrescriptionRequired { get; set; } = true;
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
