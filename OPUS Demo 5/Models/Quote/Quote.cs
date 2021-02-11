using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models
{
    [Table("Quote.Quote")]
    public class Quote
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }

        [Column("CustomerId")]
        public string CustomerId { get; set; }

        [Column("CreatedByUserId")]
        public string CreatedByUserId { get; set; }

        [Column("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [Column("CustomerReference")]
        [Display(Name ="Customer Reference")]
        public string CustomerReference { get; set; }

        [Column("MasterInternalColourId")]
        [Display(Name ="Internal Colour")]
        [Required]
        public string MasterInternalColourId { get; set; }
     
        [Column("MasterExternalColourId")]
        [Display(Name ="External Colour")]
        [Required]
        public string MasterExternalColourId { get; set; }

        [Display(Name ="Quote Reference")]
        [Column("QuoteReferenceNumber")]
        public string QuoteReferenceNumber { get; set; }

        [Display(Name ="List Code")]
        [Column("ListCode")]
        public string ListCode { get; set; }

        [Column("RequestedDeliveryDate")]
        [Display(Name = "Shipping Date")]
        [DataType(DataType.Date)]
        public DateTime RequestedDeliveryDate { get; set; }

        [Column("ApprovedByUserId")]
        public string ApprovedByUserId { get; set; }

        [Column("ApprovedDateTime")]
        public DateTime? ApprovedDateTime { get; set; }

        [Column("DeliveryMethod")]
        [Display(Name ="Shipping Option")]
        public string DeliveryMethod { get; set; }

        [Column("IsGlassRequired")]
        public bool? IsGlassRequired { get; set; }

        [Column("IsCancelled")]
        public bool IsCancelled { get; set; }

        [Column("CancelledByUserId")]
        public string CancelledByUserId { get; set; }

        [Column("CancelledDateTime")]
        public DateTime? CancelledDateTime { get; set; }

        [Column("InvoiceAmountNet")]
        [Display(Name ="Invoice Amount Net")]
        public decimal? InvoiceAmountNet { get; set; }

        [Column("InvoiceAmountVat")]
        [Display(Name = "Invoice Amount Vat")]
        public decimal? InvoiceAmountVat { get; set; }

        [Column("DepositAmount")]
        [Display(Name = "Deposit Amount Net")]
        [DataType(DataType.Currency)]
        public decimal? DepositAmount { get; set; }

        [Column("IsTaxExempt")]
        [Display(Name = "Exempt From Tax")]
        public bool IsTaxExempt { get; set; }

        [Column("DeliveryAddress")]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }

        [Column("DespatchSite")]
        [Display(Name = "Despatch Site")]
        public string DespatchSite { get; set; }

        [Column("Priority")]
        [Display(Name = "Priority")]
        public string Priority { get; set; }

        [Column("LastModifiedByUserId")]
        public string LastModifiedByUserId { get; set; }

        [Column("LastModifiedDateTime")]
        public DateTime LastModifiedDateTime { get; set; }

        [Column("DespatchNotes")]
        [Display(Name = "Despatch Notes")]
        public string DespatchNotes { get; set; }

        [Column("AdditionalNotes")]
        [Display(Name = "Additional Notes")]
        [DataType(DataType.MultilineText)]
        public string AdditionalNotes { get; set; }

        [Column("NotifySalesWhenFabricated")]
        [Display(Name = "Notify Sales When Fabricated")]
        public bool NotifySalesWhenFabricated { get; set; }
    }
}
