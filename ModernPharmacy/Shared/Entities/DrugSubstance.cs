using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernPharmacy.Shared.Entities
{
    public class DrugSubstance
    {
        public int DrugSubstanceId { get; set; }
        public int DrugId { get; set; }
        public Drug Drug { get; set; }
        public int SubstanceId { get; set; }
        public Substance Substance { get; set; }
    }
}
