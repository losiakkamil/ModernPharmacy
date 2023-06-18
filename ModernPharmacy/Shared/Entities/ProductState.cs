using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernPharmacy.Shared.Entities
{
    public class ProductState
    {
        public int Id { get; set; }
        public int PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Range(0, 100000, ErrorMessage = $"The field {nameof(AmountOfProducts)} must be greater than 0")]
        public int AmountOfProducts { get; set; }
        [Range(0, 100000, ErrorMessage = $"The field {nameof(PriceForOne)} must be greater than 0")]
        public decimal PriceForOne { get; set; }
        [Range(0, 100000, ErrorMessage = $"The field {nameof(HowMuchHasBeenSold)} must be greater than 0")]
        public int HowMuchHasBeenSold { get; set; } = 0;

    }
}
