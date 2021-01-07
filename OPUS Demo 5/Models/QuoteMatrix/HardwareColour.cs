using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models.QuoteMatrix
{
    [Table("QuoteMatrix.HardwareColour")]
    public class HardwareColour
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("ColourName")]
        public string ColourName { get; set; }
        [Column("ColourCode")]
        public string ColourCode { get; set; }
        [Column("IsEnabled")]
        public bool IsEnabled { get; set; }
    }
}
