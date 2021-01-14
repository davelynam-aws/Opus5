using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models
{
    public class EmpClass
    {
        [Key]
        public int Empid { get; set; }

        public string Empname { get; set; }


    }
}
