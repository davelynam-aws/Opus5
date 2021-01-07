using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models
{
    [Table("Role")]
    public class DemoRole
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

    }
}
