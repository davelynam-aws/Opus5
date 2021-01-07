using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models.UserIdentity
{
    [Table("UserRole")]
    public class DemoUserRole
    {
        [Key]
        [Column("UserId")]
        public string UserId { get; set; }
        [Key]
        [Column("RoleId")]
        public string RoleId { get; set; }
    }
}
