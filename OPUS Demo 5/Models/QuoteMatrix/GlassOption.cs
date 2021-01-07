using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models.QuoteMatrix
{
    [Table("QuoteMatrix.GlassOption")]
    public class GlassOption
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Surcharge")]
        public decimal Surcharge { get; set; }
        [Column("IsEnabled")]
        public bool IsEnabled { get; set; }
    }
}
