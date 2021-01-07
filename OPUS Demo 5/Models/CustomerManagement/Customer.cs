using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models.CustomerManagement
{
    [Table("Customer.Customer")]
    public class Customer
    {
        [Column("Id")]
        public string Id { get; set; }
        [Column("CustomerName")]
        public string CustomerName { get; set; }
        [Column("PreferredDeliveryDate")]
        public string PreferredDeliveryDate { get; set; }
        [Column("PaymentTerms")]
        public string PaymentTerms { get; set; }
        [Column("CustomerIsLocked")]
        public bool CustomerIsLocked { get; set; }
        [Column("CreatedByUserId")]
        public string CreatedByUserId { get; set; }
        [Column("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [Column("CustomerSageAccountReference")]
        public string CustomerSageAccountReference { get; set; }
        [Column("CreatedByBranchCompanyId")]
        public string CreatedByBranchCompanyId { get; set; }
        [Column("IsAccountCustomer")]
        public bool IsAccountCustomer { get; set; }
        [Column("IsDepositAllowed")]
        public bool IsDepositAllowed { get; set; }
        [Column("IsTaxExempt")]
        public bool IsTaxExempt { get; set; }
        [Column("IsActiveCustomer")]
        public bool IsActiveCustomer { get; set; }
        [Column("CustomerLastOrderedDateTime")]
        public DateTime CustomerLastOrderedDateTime { get; set; }
        [Column("AutoInvoicingEnabled")]
        public bool AutoInvoicingEnabled { get; set; }
        [Column("SalesNotes")]
        public string SalesNotes { get; set; }
        [Column("ProductionOnlyNotes")]
        public string ProductionOnlyNotes { get; set; }
    }
}
