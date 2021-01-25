using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models.CustomerManagement
{
    [Table("Customer.Address")]
    public class CustomerAddress
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }

        [Column("CustomerId")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "At least one main address line must be provided.")]
        [Display(Name = "Address Line 1")]
        [Column("AddressLine1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [Column("AddressLine2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Town/City")]
        [Required]
        [Column("TownCity")]
        public string TownCity { get; set; }

        [Required]
        [Display(Name = "County")]
        [Column("County")]
        public string County { get; set; }

        [Required]
        [Display(Name = "Post Code")]
        [Column("PostCode")]
        public string PostCode { get; set; }

        [Display(Name = "Invoice Address")]
        [Column("IsInvoiceAddress")]
        public bool IsInvoiceAddress { get; set; }

        [Display(Name = "Primary Delivery Address")]
        [Column("IsPrimaryDeliveryAddress")]
        public bool IsPrimaryDeliveryAddress { get; set; }

        [Display(Name = "Despatch Site")]
        [Required]
        [Column("DespatchSite")]
        public string DespatchSite { get; set; }

        [Column("CreatedByUserId")]
        public string CreatedByUserId { get; set; }

        [Column("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }
    }
}
