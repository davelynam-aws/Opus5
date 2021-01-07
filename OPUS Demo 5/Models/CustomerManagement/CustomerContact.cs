using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models.CustomerManagement
{
    [Table("Customer.Contact")]
    public class CustomerContact
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }
        [Column("CustomerId")]
        public string CustomerId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("ContactNumber")]
        public string ContactNumber { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("IsPrimaryContact")]
        public bool IsPrimaryContact { get; set; }
        [Column("IsAccountContact")]
        public bool IsAccountContact { get; set; }
        [Column("CreatedByUserId")]
        public string CreatedByUserId { get; set; }
        [Column("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }
    }
}
