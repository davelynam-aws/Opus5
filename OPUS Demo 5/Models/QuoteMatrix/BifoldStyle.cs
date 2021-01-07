using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models.QuoteMatrix
{
    [Table("QuoteMatrix.BifoldStyle")]
    public class BifoldStyle
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("StyleCode")]
        public string StyleCode { get; set; }
        [Column("SashQty")]
        public int SashQty { get; set; }
        [Column("IsOpenOut")]
        public bool IsOpenOut { get; set; }
        [Column("IsEnabled")]
        public bool IsEnabled { get; set; }
    }
}
