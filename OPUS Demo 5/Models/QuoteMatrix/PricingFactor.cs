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

        [Required]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Sash Height Above 2100mm")]
        [Column("SashHeightAbove2100MMSurcharge")]
        public decimal SashHeightAbove2100MMSurcharge { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Display(Name = "Mullion Splits Under 1000mm")]
        [Column("MullionSplitsUnder1000MMSurcharge")]
        public Decimal MullionSplitsUnder1000MMSurcharge { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Display(Name = "Mullion Splits Between 1000mm and 1200mm")]
        [Column("MullionSplits1000MMAndOverSurcharge")]
        public Decimal MullionSplits1000MMAndOverSurcharge { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Display(Name = "UPVC Trickle Vent")]
        [Column("UPVCTrickleVentSurcharge")]
        public Decimal UPVCTrickleVentSurcharge { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Display(Name = "Aluminium Trickle Vent")]
        [Column("AluminiumTrickleVentSurCharge")]
        public Decimal AluminiumTrickleVentSurCharge { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Non-Stock Single Colour")]
        [Column("NonStockSingleColourSurCharge")]
        public Decimal NonStockSingleColourSurCharge { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Non-Stock Dual Colour")]
        [Column("NonStockDualColourSurCharge")]
        public Decimal NonStockDualColourSurCharge { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Smart Sensation Coating")]
        [Column("SmartSensationSurCharge")]
        public Decimal SmartSensationSurCharge { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Smart Alchemy Coating")]
        [Column("SmartAlchemySurcharge")]
        public Decimal SmartAlchemySurcharge { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Marine/Hazardous Coating")]
        [Column("MarineHazardousCoatingSurcharge")]
        public Decimal MarineHazardousCoatingSurcharge { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Display(Name = "Ultion Burglar Proof Cylinder")]
        [Column("UltionBurglarProofCylinderSurcharge")]
        public Decimal UltionBurglarProofCylinderSurcharge { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Display(Name = "Stainless Steel Lever On Rose With Separate Excutcheon")]
        [Column("SSLeverOnRoseWithExcutcheonSurcharge")]
        public Decimal SSLeverOnRoseWithExcutcheonSurcharge { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Display(Name = "Stainless Steel Shoot Bolt Handle")]
        [Column("SSShootboltHandleSurcharge")]
        public Decimal SSShootboltHandleSurcharge { get; set; }

    }
}
