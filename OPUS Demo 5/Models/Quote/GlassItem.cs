using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models
{
    [Table("Quote.GlassItem")]
    public class GlassItem
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }
        [Column("GlassOptionId")]
        public int GlassOptionId { get; set; }
        [Column("BifoldItemId")]
        public string BifoldItemId { get; set; }
        [Column("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [Column("CreatedByUserId")]
        public string CreatedByUserId { get; set; }
    }
}
