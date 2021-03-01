using Microsoft.AspNetCore.Mvc.Rendering;
using OPUS_Demo_5.Models.CustomerManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.ViewModels
{
    public class AddressViewModel
    {
        public CustomerAddress thisAddress { get; set; }


        public AddressViewModel()
        {
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


        public List<SelectListItem> DespatchSiteOptions { get; set; }





        public string DeliveryPostCode { get; set; }
        public string DeliveryAddressLine1 { get; set; }
        public string DeliveryAddressLine2 { get; set; }
        public string DeliveryTownCity { get; set; }
        public string DeliveryCounty { get; set; }
        public string DeliveryDespatchSite { get; set; }
        public bool DeliverySaveAddress { get; set; }
        public string DeliveryAddressString { get; set; }



    }
}
