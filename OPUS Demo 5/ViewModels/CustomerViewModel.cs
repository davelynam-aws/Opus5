using Microsoft.AspNetCore.Mvc.Rendering;
using OPUS_Demo_5.Models.CustomerManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.ViewModels
{
    public class CustomerViewModel
    {

        public CustomerViewModel()
        {
            PreferredDeliveryDayOptions = new List<SelectListItem>()
        {
            new SelectListItem{ Value = "0",Text = "Monday" },
            new SelectListItem{ Value = "1", Text = "Tuesday" },
            new SelectListItem{ Value = "2", Text = "Wednesday" },
            new SelectListItem{ Value = "3", Text = "Thursday" },
            new SelectListItem{ Value = "4", Text = "Friday" }
        };

            DespatchSiteOptions = new List<SelectListItem>()
            {
            new SelectListItem{ Value = "0",Text = "21st Altrincham" },
            new SelectListItem{ Value = "1", Text = "21st Poulton" },
            new SelectListItem{ Value = "2", Text = "Leyland" },
            new SelectListItem{ Value = "3", Text = "Marton" },
            new SelectListItem{ Value = "4", Text = "Marton 2 (Clifton Rd)" },
            new SelectListItem{ Value = "5", Text = "Stafford" }
            };



        }
        public Customer thisNewCustomer { get; set; }

        public CustomerAddress thisNewCustomerInvoiceAddress { get; set; }

        public CustomerContact thisNewCustomerContact { get; set; }




        [Display(Name = "Choose Address")]
        public List<SelectListItem> ProposedAddresses { get; set; }

  
        public List<SelectListItem> PreferredDeliveryDayOptions { get; set; }

        public List<SelectListItem> DespatchSiteOptions { get; set; }
    }
}
