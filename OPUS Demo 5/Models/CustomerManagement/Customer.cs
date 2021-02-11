using OPUS_Demo_5.Models.DataContexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models.CustomerManagement
{
    [Table("Customer.Customer")]
    public class Customer
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }

        [Required]
        [Column("CustomerName")]
        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }

        [Column("PreferredDeliveryDate")]
        [Display(Name = "Preferred Delivery Date")]
        public string PreferredDeliveryDate { get; set; }

        [Column("PaymentTerms")]
        [Display(Name = "Payment Terms")]
        public string PaymentTerms { get; set; }

        [Column("CustomerIsLocked")]
        [Display(Name = "Customer Is Locked")]
        public bool CustomerIsLocked { get; set; }

        [Column("CreatedByUserId")]
        public string CreatedByUserId { get; set; }

        [Column("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [Column("CustomerSageAccountReference")]
        [Display(Name = "Customer Sage Account Reference")]
        public string CustomerSageAccountReference { get; set; }

        [Column("CreatedByBranchCompanyId")]
        public string CreatedByBranchCompanyId { get; set; }

        [Column("IsAccountCustomer")]
        [Display(Name = "Is Account Customer")]
        public bool IsAccountCustomer { get; set; }

        [Column("IsDepositAllowed")]
        [Display(Name = "Is Deposit Allowed")]
        public bool IsDepositAllowed { get; set; }

        [Column("IsTaxExempt")]
        [Display(Name = "Is Tax Exempt")]
        public bool IsTaxExempt { get; set; }

        [Column("IsActiveCustomer")]
        [Display(Name = "Is Active Customer")]
        public bool IsActiveCustomer { get; set; }

        [Column("CustomerLastOrderedDateTime")]
        public DateTime CustomerLastOrderedDateTime { get; set; }

        [Column("AutoInvoicingEnabled")]
        [Display(Name = "Is Auto-Invoicing Enabled")]
        public bool AutoInvoicingEnabled { get; set; }

        [Column("SalesNotes")]
        [Display(Name = "Sales Notes")]
        public string SalesNotes { get; set; }

        [Column("ProductionOnlyNotes")]
        [Display(Name = "Production Only Notes")]
        public string ProductionOnlyNotes { get; set; }

        [Column("LegacyId")]
        public int LegacyId { get; set; }



        [NotMapped]
        public bool IsNewCustomer { get; set; }



    }
}
