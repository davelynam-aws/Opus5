using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models
{
    [Table("QuoteMatrix.PeripheralOption")]
    public class PeripheralOption
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("ItemCode")]
        public string ItemCode { get; set; }
        [Column("IsHeadPlacementAllowed")]
        public bool IsHeadPlacementAllowed { get; set; }
        [Column("IsBottomPlacementAllowed")]
        public bool IsBottomPlacementAllowed { get; set; }
        [Column("IsLeftPlacementAllowed")]
        public bool IsLeftPlacementAllowed { get; set; }
        [Column("IsRightPlacementAllowed")]
        public bool IsRightPlacementAllowed { get; set; }
        [Column("FrameDeduction")]
        public int FrameDeduction { get; set; }
        [Column("IsCill")]
        public bool IsCill { get; set; }
        [Column("IsAddon")]
        public bool IsAddon { get; set; }
        [Column("Surcharge")]
        public decimal Surcharge { get; set; }
        [Column("IsEnabled")]
        public bool IsEnabled { get; set; }
    }
}
