using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernPharmacy.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int? DifferentProductId { get; set; }
        public DifferentProduct? DifferentProduct { get; set; }
        public int? DrugId { get; set; }
        public Drug? Drug { get; set; }
        [Range(0.00, 100000, ErrorMessage = $"The field {nameof(ProposedPrice)} must be greater than 0")]
        public decimal? ProposedPrice { get; set; }
        public bool ShippingOption { get; set; } = false;
        public virtual List<ProductState> ProductStates { get; set; } = new List<ProductState>();
    }
}
