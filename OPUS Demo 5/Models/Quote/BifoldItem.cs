using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models
{
    [Table("Quote.BifoldItem")]
    public class BifoldItem
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }
        [Column("QuoteId")]
        public string QuoteId { get; set; }
        [Column("Width")]
        public int Width { get; set; }
        [Column("Height")]
        public int Height { get; set; }
        [Column("StyleId")]
        public int StyleId { get; set; }
        [Column("InternalColourId")]
        public string InternalColourId { get; set; }
        [Column("ExternalColourId")]
        public string ExternalColourId { get; set; }
        [Column("UPVCTrickleVentQty")]
        public int UPVCTrickleVentQty { get; set; }
        [Column("AluminiumTrickleVentQty")]
        public int AluminiumTrickleVentQty { get; set; }
        [Column("IsMarineOrHazardousCoating")]
        public bool IsMarineOrHazardousCoating { get; set; }
        [Column("HasUltionCylinder")]
        public bool HasUltionCylinder { get; set; }
        [Column("HasLeverOnRoseEscutcheon")]
        public bool HasLeverOnRoseEscutcheon { get; set; }
        [Column("HasShootboltHandle")]
        public bool HasShootboltHandle { get; set; }
        [Column("IsLowThreshold")]
        public bool IsLowThreshold { get; set; }
        [Column("HasRamps")]
        public bool HasRamps { get; set; }
        [Column("IsKitForm")]
        public bool IsKitForm { get; set; }
        [Column("Location")]
        public string Location { get; set; }
        [Column("ItemNumber")]
        public int ItemNumber { get; set; }
        [Column("CreatedByUserId")]
        public string CreatedByUserId { get; set; }
        [Column("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [Column("AdditionalNotes")]
        public string AdditionalNotes { get; set; }
        [Column("HardwareColourId")]
        public int HardwareColourId { get; set; }
    }
}
