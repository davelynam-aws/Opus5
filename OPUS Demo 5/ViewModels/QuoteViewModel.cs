using Microsoft.AspNetCore.Mvc.Rendering;
using OPUS_Demo_5.Models;
using OPUS_Demo_5.Models.CustomerManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
  


        public IEnumerable<Customer> ActiveCustomers { get; set; }


        [Display(Name = "Shipping Options")]
        public List<SelectListItem> ShippingOptions = new List<SelectListItem>()
    {
        new SelectListItem() {Text="AWS Vehicle Delivery", Value="AWS Vehicle Delivery"},
        new SelectListItem() { Text="Collection", Value="Collection"}

    };



        [Display(Name = "Collection Address")]
        public List<SelectListItem> CollectionAddresses = new List<SelectListItem>()
    {
        new SelectListItem() { Text="[Marton] Unit 20 Cornford House, Cornford Road, Marton, Lancashire, FY4 4QQ", Value="0"},
        new SelectListItem() { Text="[Stafford] 21st Century Trade Centre, Stafford Road, Stafford, Staffordshire, ST20 0JR", Value="1"},
        new SelectListItem() { Text="[21st Altrincham] 21st Century Trade Centre, Stafford Road, Stafford, Staffordshire, ST20 0JR", Value="2"},
        new SelectListItem() { Text="[21st Poulton] Unit 1 Beacon Road, Poulton Industrial Estate, Poulton-Le-Fylde, Lancashire, FY6 8JE", Value="3"},
        new SelectListItem() { Text="[Marton 2 (Clifton Rd)] Tangerine House, Clifton Road, Marton, Lancashire, FY4 4QB", Value="4"},
        new SelectListItem() { Text="[Leyland] Unit 28, Tomlinson Road, Leyland, Lancashire, PR25 2DY", Value="5"},
    };


     


        [Display(Name = "Delivery Address")]
        public List<SelectListItem> DeliveryAddresses = new List<SelectListItem>();


    }
}
