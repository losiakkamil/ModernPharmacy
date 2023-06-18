using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernPharmacy.Shared.Entities
{
    public class SubstanceSubstanceCategory
    {
        public int SubstanceSubstanceCategoryId { get; set; }
        public int SubstanceId { get; set; }
        public Substance Substance { get; set; }
        public int SubstanceCategoryId { get; set; }
        public SubstanceCategory SubstanceCategory { get; set; }
    }
}
