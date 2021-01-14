using Microsoft.AspNetCore.Mvc.Rendering;
using OPUS_Demo_5.Models;
using OPUS_Demo_5.Models.CustomerManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.ViewModels
{
    public class QuoteViewModel
    {
        public Quote thisQuote { get; set; }
        public Customer thisCustomer { get; set; }

        public List<BifoldItem> thisBifoldItems { get; set; }
        public List<ExtraItem> thisExtraItems { get; set; }
        public List<GlassItem> thisGlassItems { get; set; }
        public List<PeripheralItem> thisPeripheralItems { get; set; }





        [Display(Name = "Created By")]
        public string CreatedByUsername { get; set; }

        [Display(Name = "Created By")]
        public string ApprovedByUsername { get; set; }

        [Display(Name = "Created By")]
        public string LastModifiedByUsername { get; set; }






        // View Options
    //    public List<Customer> ActiveCustomers { get; set; }




        public IEnumerable<Customer> ActiveCustomers { get; set; }
    }
}
