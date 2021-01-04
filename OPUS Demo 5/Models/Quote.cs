using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models
{
    [Table("Quote.Quote")]
    public class Quote
    {
        [Column("Id")]
        public string Id { get; set; }
        [Column("CustomerId")]
        public string CustomerId { get; set; }
        [Column("CreatedByUserId")]
        public string CreatedByUserId { get; set; }
        [Column("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [Column("CustomerReference")]
        public string CustomerReference { get; set; }
        [Column("MasterInternalColourId")]
        public string MasterInternalColourId { get; set; }
        [Column("MasterExternalColourId")]
        public string MasterExternalColourId { get; set; }
        [Column("QuoteReferenceNumber")]
        public string QuoteReferenceNumber { get; set; }
        [Column("ListCode")]
        public string ListCode { get; set; }
        [Column("RequestedDeliveryDate")]
        public DateTime RequestedDeliveryDate { get; set; }
        [Column("ApprovedByUserId")]
        public string ApprovedByUserId { get; set; }
        [Column("ApprovedDateTime")]
        public string ApprovedDateTime { get; set; }
        [Column("DeliveryMethod")]
        public string DeliveryMethod { get; set; }
        [Column("IsGlassRequired")]
        public bool IsGlassRequired { get; set; }
        [Column("IsCancelled")]
        public bool IsCancelled { get; set; }
        [Column("CancelledByUserId")]
        public string CancelledByUserId { get; set; }
        [Column("CancelledDateTime")]
        public DateTime CancelledDateTime { get; set; }
        [Column("InvoiceAmountNet")]
        public decimal InvoiceAmountNet { get; set; }
        [Column("InvoiceAmountVat")]
        public decimal InvoiceAmountVat { get; set; }
        [Column("DepositAmount")]
        public decimal DepositAmount { get; set; }
        [Column("IsTaxExempt")]
        public bool IsTaxExempt { get; set; }
        [Column("DeliveryAddress")]
        public string DeliveryAddress { get; set; }
        [Column("DespatchSite")]
        public string DespatchSite { get; set; }
        [Column("Priority")]
        public string Priority { get; set; }
        [Column("LastModifiedByUserId")]
        public string LastModifiedByUserId { get; set; }
        [Column("LastModifiedDateTime")]
        public DateTime LastModifiedDateTime { get; set; }
        [Column("DespatchNotes")]
        public string DespatchNotes { get; set; }
        [Column("AdditionalNotes")]
        public string AdditionalNotes { get; set; }
        [Column("NotifySalesWhenFabricated")]
        public bool NotifySalesWhenFabricated { get; set; }
    }
}
