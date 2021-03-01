using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using getAddress.Sdk;
using getAddress.Sdk.Api;
using getAddress.Sdk.Api.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OPUS_Demo_5.Models.CustomerManagement;
using OPUS_Demo_5.Models.DataContexts;
using OPUS_Demo_5.ViewModels;

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






        // GET
        public IActionResult Create()
        {

            CustomerViewModel newCustomer = new CustomerViewModel();
            newCustomer.thisNewCustomer = new Customer();
            newCustomer.thisNewCustomerContact = new CustomerContact();
            newCustomer.thisNewCustomerInvoiceAddress = new CustomerAddress();

            newCustomer.SelectedCustomerAddress = new CustomerAddress();

            // Set default values.
            newCustomer.thisNewCustomer.IsDepositAllowed = true;
            newCustomer.thisNewCustomer.IsTaxExempt = false;
            newCustomer.thisNewCustomer.IsAccountCustomer = false;

            return PartialView("_CreateCustomerModal", newCustomer);
        }


        // POST
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(CustomerViewModel newCustomer)
        {
            // Set properties that are not set from form input.
            newCustomer.thisNewCustomer.Id = Guid.NewGuid().ToString();
            newCustomer.thisNewCustomer.IsActiveCustomer = true;
            newCustomer.thisNewCustomer.CustomerIsLocked = false;
            newCustomer.thisNewCustomer.CreatedDateTime = DateTime.Now;
            newCustomer.thisNewCustomer.AutoInvoicingEnabled = true;
            newCustomer.thisNewCustomer.CustomerLastOrderedDateTime = DateTime.Parse("01/01/1753");
            // Globally Acquired
            newCustomer.thisNewCustomer.CreatedByUserId = HttpContext.Session.GetString("UserId");
            newCustomer.thisNewCustomer.CreatedByBranchCompanyId = HttpContext.Session.GetString("UserBranchId"); 

            newCustomer.thisNewCustomerContact.Id = Guid.NewGuid().ToString();
            newCustomer.thisNewCustomerContact.CreatedDateTime = DateTime.Now;
            newCustomer.thisNewCustomerContact.CustomerId = newCustomer.thisNewCustomer.Id;
            newCustomer.thisNewCustomerContact.IsAccountContact = true;
            newCustomer.thisNewCustomerContact.IsPrimaryContact = true;
            //Globally Acquired
            newCustomer.thisNewCustomerContact.CreatedByUserId = HttpContext.Session.GetString("UserId"); 

            newCustomer.thisNewCustomerInvoiceAddress.Id = Guid.NewGuid().ToString();
            //Globally Acquired
            newCustomer.thisNewCustomerInvoiceAddress.CreatedByUserId = HttpContext.Session.GetString("UserId"); 
            newCustomer.thisNewCustomerInvoiceAddress.CreatedDateTime = DateTime.Now;
            newCustomer.thisNewCustomerInvoiceAddress.CustomerId = newCustomer.thisNewCustomer.Id;
            newCustomer.thisNewCustomerInvoiceAddress.IsInvoiceAddress = true;
            newCustomer.thisNewCustomerInvoiceAddress.IsPrimaryDeliveryAddress = true;

            int lastLegacyId;

            lastLegacyId = _context.Customers.OrderByDescending(c => c.LegacyId).Take(1).FirstOrDefault().LegacyId;

            newCustomer.thisNewCustomer.LegacyId = lastLegacyId += 1;

            if (ModelState.IsValid)
            {
                // Bespoke Validation?
               
                // Update database etc.
                _context.Customers.Add(newCustomer.thisNewCustomer);
                _context.SaveChanges();

                _context.CustomerAddresses.Add(newCustomer.thisNewCustomerInvoiceAddress);
                _context.CustomerContacts.Add(newCustomer.thisNewCustomerContact);
                _context.SaveChanges();

                // Set flag to refresh parent options. i.e. Add the new customer to the customer selection.
                newCustomer.thisNewCustomer.IsNewCustomer = true;

                return PartialView("_CreateCustomerModal", newCustomer);

                // Return a view or redirect after success.
                // return RedirectToAction("Create", "Quote");

            }
            else
            {
                newCustomer.FailedValidation = true;
            }

            // Return the original view model if input does not pass validation.
            return PartialView("_CreateCustomerModal", newCustomer);
        }





        public IEnumerable<SelectListItem> GetActiveCustomers()
        {
            List<SelectListItem> ActiveCustomersList = new List<SelectListItem>();

            List<Customer> ActiveCustomers = _context.Customers.Where(c => c.IsActiveCustomer == true).ToList();

            if (ActiveCustomers != null)
            {
                foreach(Customer cust in ActiveCustomers)
                {
                    ActiveCustomersList.Add(new SelectListItem
                    {
                        Value = cust.Id,
                        Text = cust.CustomerName
                    });
                }
            }

            return new SelectList(ActiveCustomersList, "Value", "Text");
        }




        public async Task<IActionResult> GoogleApiGetAddresses(string postCode, CustomerViewModel customerViewModel)
        {
           List<SelectListItem> proposedAddresses = new List<SelectListItem>();

            var apiKey = new ApiKey("zLIh4NnlNkqQeGp-mqc67w30396");

            IAddressService addressService = new AddressService(apiKey);
            
            var result = await addressService.Get(new GetAddressRequest(postCode));



            //int increment = 0;
            List<CustomerAddress> ProposedAddresses = new List<CustomerAddress>();
            CustomerAddress customerAddress;
            if (result.IsSuccess)
            {
                int increment = 0;
                foreach(var address in result.SuccessfulResult.Addresses)
                {
                    customerAddress = new CustomerAddress();
                    customerAddress.IncrementForSelectList = increment;
                    customerAddress.AddressLine1 = address.Line1;
                    customerAddress.AddressLine2 = $"{address.Line2} {address.Line3} {address.Line4}".Trim();
                    customerAddress.TownCity = address.TownOrCity;
                    customerAddress.County = address.County;
                    customerAddress.PostCode = postCode.ToUpper();
                    customerAddress.DisplayAddress = $"{customerAddress.AddressLine1}, {customerAddress.AddressLine2}, {customerAddress.TownCity}, {customerAddress.County}";
                    increment += 1;
                    ProposedAddresses.Add(customerAddress);
                }
                customerViewModel.ProposedCustomerAddresses = ProposedAddresses;
                customerViewModel.SelectedCustomerAddress = new CustomerAddress();
     
                ViewBag.ProposedAddresses = new SelectList(ProposedAddresses, "IncrementForSelectList", "DisplayAddress");

            }
            else
            {
                ViewBag.ProposedAddresses = null;
            }

            //customerViewModel = new CustomerViewModel();
            //customerViewModel.thisNewCustomer = new Customer();
            //customerViewModel.thisNewCustomerContact = new CustomerContact();
            //customerViewModel.thisNewCustomerInvoiceAddress = new CustomerAddress();

            // ViewBag.ProposedAddresses = proposedAddresses;
            //ViewBag.ProposedAddresses = result.SuccessfulResult.Addresses;
            return PartialView("~/Views/Shared/_ProposedAddresses.cshtml", customerViewModel);
           // What do I Return??
        }

        //public ActionResult Search(string term)
        //{
        //    var films = from f in db.Films
        //                select new
        //                {
        //                    id = f.FilmId,
        //                    label = f.Title
        //                };

        //    films = films.Where(f => f.label.Contains(term));

        //    return Json(films);
        //}

    }
}
