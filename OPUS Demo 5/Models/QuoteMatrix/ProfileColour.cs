using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models.QuoteMatrix
{
    [Table("QuoteMatrix.ProfileColour")]
    public class ProfileColour
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }
        [Column("ColourCode")]
        public string ColourCode { get; set; }
        [Column("ColourName")]
        public string ColourName { get; set; }
        [Column("ColourFinish")]
        public string ColourFinish { get; set; }
        [Column("IsAffordableStockColour")]
        public bool IsAffordableStockColour { get; set; }
        [Column("IsSmartSensations")]
        public bool IsSmartSensations { get; set; }
        [Column("IsSmartAlchemy")]
        public bool IsSmartAlchemy { get; set; }
        [Column("Surcharge")]
        public decimal Surcharge { get; set; }
        [Column("IsEnabled")]
        public bool IsEnabled { get; set; }
    }
}
