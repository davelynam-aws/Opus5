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
            new SelectListItem{ Value = "Monday",Text = "Monday" },
            new SelectListItem{ Value = "Tuesday", Text = "Tuesday" },
            new SelectListItem{ Value = "Wednesday", Text = "Wednesday" },
            new SelectListItem{ Value = "Thursday", Text = "Thursday" },
            new SelectListItem{ Value = "Friday", Text = "Friday" }
        };

            DespatchSiteOptions = new List<SelectListItem>()
            {
            new SelectListItem{ Value = "21st Altrincham",Text = "21st Altrincham" },
            new SelectListItem{ Value = "21st Poulton", Text = "21st Poulton" },
            new SelectListItem{ Value = "Leyland", Text = "Leyland" },
            new SelectListItem{ Value = "Marton", Text = "Marton" },
            new SelectListItem{ Value = "Marton 2 (Clifton Rd)", Text = "Marton 2 (Clifton Rd)" },
            new SelectListItem{ Value = "Stafford", Text = "Stafford" }
            };



        }


        public Customer thisNewCustomer { get; set; }

        public CustomerAddress thisNewCustomerInvoiceAddress { get; set; }

        public CustomerContact thisNewCustomerContact { get; set; }


        [Display(Name = "Choose Address")]
        public List<CustomerAddress> ProposedCustomerAddresses { get; set; }


        [Display(Name = "Choose Address")]
        public List<SelectListItem> ProposedAddresses { get; set; }

        public CustomerAddress SelectedCustomerAddress { get; set; }

        public List<SelectListItem> PreferredDeliveryDayOptions { get; set; }

        public List<SelectListItem> DespatchSiteOptions { get; set; }

        public bool FailedValidation { get; set; }

    }
}
