using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models
{
    [Table("Customer")]
    public class TestCustomer
    {
        [Key]
        [Column("CustomerId")]
        public int CustomerId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Country")]
        public string Country { get; set; }
    }
}
