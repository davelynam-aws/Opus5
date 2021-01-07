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
        [Column("AddressLine1")]
        public string AddressLine1 { get; set; }
        [Column("AddressLine2")]
        public string AddressLine2 { get; set; }
        [Column("TownCity")]
        public string TownCity { get; set; }
        [Column("County")]
        public string County { get; set; }
        [Column("PostCode")]
        public string PostCode { get; set; }
        [Column("IsInvoiceAddress")]
        public bool IsInvoiceAddress { get; set; }
        [Column("IsPrimaryDeliveryAddress")]
        public bool IsPrimaryDeliveryAddress { get; set; }
        [Column("DespatchSite")]
        public string DespatchSite { get; set; }
        [Column("CreatedByUserId")]
        public string CreatedByUserId { get; set; }
        [Column("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }
    }
}
