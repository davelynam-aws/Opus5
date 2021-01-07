using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models.QuoteMatrix
{
    [Table("QuoteMatrix.PricingFactor")]
    public class PricingFactor
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("PricingFactorName")]
        public string PricingFactorName { get; set; }
        [Column("Surcharge")]
        public Decimal Surcharge { get; set; }
    }
}
