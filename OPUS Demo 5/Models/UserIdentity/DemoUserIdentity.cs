using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models.UserIdentity
{
    [Table("UserAccount")]
    public class DemoUserIdentity
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("PasswordHash")]
        [Display(Name ="Password")]
        public string PasswordHash { get; set; }
        [Column("UserName")]
        public string UserName { get; set; }
        [Column("FullName")]
        public string FullName { get; set; }
        [Column("BranchCompanyId")]
        public string BranchCompanyId { get; set; }

    }
}
