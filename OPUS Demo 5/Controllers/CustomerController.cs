using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OPUS_Demo_5.Models.CustomerManagement;
using OPUS_Demo_5.Models.DataContexts;

namespace OPUS_Demo_5.Controllers
{
    public class CustomerController : Controller
    {

        private readonly OpusContext _context;
        
        public CustomerController(OpusContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Returns a Json object for populating a select list drop down of Customer Addresses for a specific CustomerId
        public IActionResult GetCustomerAddresses(string customerId)
        {
            List<CustomerAddress> addresses;

            List<SelectListItem> stringAddresses = new List<SelectListItem>();

            if (customerId == null)
            {
                return Json(stringAddresses);
            }
            else
            {
                addresses = _context.CustomerAddresses.Where(a => a.CustomerId == customerId).ToList();

                int i = 0;

                foreach (CustomerAddress address in addresses)
                {
                    stringAddresses.Add(new SelectListItem
                    {
                        Value = $"{i}",
                        Text = $"{address.AddressLine1}, {address.AddressLine2}, {address.TownCity}, {address.County}, {address.PostCode}, [{address.DespatchSite}]"
                    });
                    i += 1;
                }
            }           
            return Json(stringAddresses);
        }

    }
}
