using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OPUS_Demo_5.Models;
using OPUS_Demo_5.Models.CustomerManagement;
using OPUS_Demo_5.Models.DataContexts;
using OPUS_Demo_5.Models.QuoteMatrix;
using OPUS_Demo_5.ViewModels;

namespace OPUS_Demo_5.Controllers
{
    public class QuoteController : Controller
    {
        private readonly OpusContext _context;

        public QuoteController(OpusContext context)
        {
            _context = context;
        }

        public ActionResult ShowInvoiceAddressPartial(string customerId)
        {
            CustomerAddress customerAddress = new CustomerAddress();

            if (customerId == null)
            {
                return Content("");
            }
            else
            {
                customerAddress = _context.CustomerAddresses.Where(a => a.CustomerId == customerId && a.IsInvoiceAddress == true).Single();
            }
            return PartialView("~/Views/Shared/_CustomerInvoiceAddress.cshtml", customerAddress);
        }

        public ActionResult RefreshQuoteHeaderInformation(string jsonString)
        {

            QuoteViewModel quoteViewModel = JsonConvert.DeserializeObject<QuoteViewModel>(jsonString);

            quoteViewModel.thisCustomerInvoiceAddress = _context.CustomerAddresses.Where(a => a.CustomerId == quoteViewModel.thisQuote.CustomerId).Where(a => a.IsInvoiceAddress == true).FirstOrDefault();

            quoteViewModel.thisCustomer = _context.Customers.Where(c => c.Id == quoteViewModel.thisQuote.CustomerId).Single();

            return PartialView("_QuoteHeader", quoteViewModel);
        }

        public ActionResult RefreshQuoteHeader(string quoteId)
        {
            QuoteViewModel quoteViewModel = new QuoteViewModel();

            if (quoteId == null)
            {

            }
            else
            {
                quoteViewModel.thisQuote = _context.Quotes.Where(q => q.Id == quoteId).SingleOrDefault();
            }


            return PartialView("_QuoteHeader", quoteViewModel);
        }



        public ActionResult RefreshCustomerHeader(string customerId)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();

            customerViewModel.thisNewCustomer = _context.Customers.Where(c => c.Id == customerId).SingleOrDefault();

            customerViewModel.thisNewCustomerInvoiceAddress = _context.CustomerAddresses.Where(a => a.CustomerId == customerId && a.IsInvoiceAddress == true).SingleOrDefault();

            return PartialView("_QuoteCustomerHeader", customerViewModel);
        }




        // GET: Quote
        public async Task<IActionResult> Index()
        {
            List<QuoteViewModel> quoteViewModels = new List<QuoteViewModel>();
            QuoteViewModel quoteViewModel;


            List<Quote> quotes = await _context.Quotes.ToListAsync();

            //Build viewmodel of quote items etc.
            if (quotes.Count > 0)
            {
                foreach (Quote quote in quotes)
                {
                    quoteViewModel = new QuoteViewModel();
                    quoteViewModel.thisQuote = quote;

                    Customer customer = _context.Customers.Where(c => c.Id == quote.CustomerId).Single();


                    quoteViewModel.thisCustomer = customer;

                    List<BifoldItem> bifoldItems = new List<BifoldItem>();
                    
                    bifoldItems = await _context.BifoldItems.Where(b => b.QuoteId == quote.Id).OrderBy(b => b.ItemNumber).ToListAsync();
                    quoteViewModel.thisBifoldItems = bifoldItems;
                    //Do Extra Items, Glass Items, Peripheral Items etc.

                    List<ExtraItem> extraItems = new List<ExtraItem>();
                    List<GlassItem> glassItems = new List<GlassItem>();
                    List<PeripheralItem> peripheralItems = new List<PeripheralItem>();

                    if (bifoldItems.Count > 0)
                    {
                        foreach(BifoldItem bifoldItem in bifoldItems)
                        {

                            extraItems = await _context.ExtraItems.Where(e => e.BifoldItemId == bifoldItem.Id).ToListAsync();
                            glassItems = await _context.GlassItems.Where(g => g.BifoldItemId == bifoldItem.Id).ToListAsync();
                            peripheralItems = await _context.PeripheralItems.Where(p => p.BifoldItemId == bifoldItem.Id).ToListAsync();
                        }
                    }

                    quoteViewModel.thisExtraItems = extraItems;
                    quoteViewModel.thisGlassItems = glassItems;
                    quoteViewModel.thisPeripheralItems = peripheralItems;

                    quoteViewModels.Add(quoteViewModel);

                }
            }

            return View(quoteViewModels);
            //return View(await _context.Quotes.ToListAsync());
        }

        // GET
        public IActionResult AddBifoldItem(string id)
        {

            BifoldItemViewModel bifoldItemViewModel = new BifoldItemViewModel();

            bifoldItemViewModel.ParentQuote = _context.Quotes.Where(q => q.Id == id).FirstOrDefault();

            bifoldItemViewModel.thisBifoldItem = new BifoldItem();

            int lastItemNumber = _context.BifoldItems.Where(b => b.QuoteId == id).Take(1).OrderByDescending(b => b.ItemNumber).Select(b => b.ItemNumber).FirstOrDefault();

            // Increment this from existing.
            bifoldItemViewModel.thisBifoldItem.ItemNumber = lastItemNumber += 1;

            bifoldItemViewModel.ProfileColourOptions = _context.ProfileColours.ToList();
            bifoldItemViewModel.HardwareColourOptions = _context.HardwareColours.ToList();

            bifoldItemViewModel.PricingFactors = _context.PricingFactors.Where(p => p.Id == 1).Single();

            bifoldItemViewModel.SelectedBifoldStyleCode = "Default";

            bifoldItemViewModel.thisBifoldItem.IsMarineOrHazardousCoating = bifoldItemViewModel.ParentQuote.IsMarineOrHazardousCoating;
            bifoldItemViewModel.thisBifoldItem.InternalColourId = bifoldItemViewModel.ParentQuote.MasterInternalColourId;
            bifoldItemViewModel.thisBifoldItem.ExternalColourId = bifoldItemViewModel.ParentQuote.MasterExternalColourId;

            return PartialView("~/Views/BifoldItem/_CreateBifoldItem.cshtml", bifoldItemViewModel);
        }


        // POST
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddBifoldItem(BifoldItemViewModel bifoldItemViewModel)
        {
            if (ModelState.IsValid)
            {
                // Test debug
                int i = 1;

                i += 1; 

                // Save et
            }

            //bifoldItemViewModel.ProfileColourOptions = _context.ProfileColours.ToList();
            //bifoldItemViewModel.HardwareColourOptions = _context.HardwareColours.ToList();

            //bifoldItemViewModel.SelectedBifoldStyleCode = "Default";

            return PartialView("~/Views/BifoldItem/_CreateBifoldItem.cshtml", bifoldItemViewModel);
        }

        //GET
        public IActionResult AddDeliveryAddress()
        {
            AddressViewModel addressViewModel = new AddressViewModel();

            addressViewModel.thisAddress = new CustomerAddress();

            return PartialView("~/Views/Shared/_NewDeliveryAddress.cshtml", addressViewModel);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDeliveryAddress(AddressViewModel addressViewModel)
        {


            if (ModelState.IsValid)
            {

            }

            return PartialView("~/Views/Shared/_NewDeliveryAddress.cshtml", addressViewModel);
        }



        // GET: Quote/Create
        public IActionResult CreateOrEdit(string Id = "")
        {
            QuoteViewModel quoteViewModel = new QuoteViewModel();
            

            // Populate combo's etc
            if (Id == "")
            {
                // Create new quote with default values
                quoteViewModel.thisQuote = new Quote();
                quoteViewModel.IsNewQuote = true;
                quoteViewModel.thisBifoldItems = new List<BifoldItem>();
                quoteViewModel.thisBifoldItemViewModels = new List<BifoldItemViewModel>();
                quoteViewModel.thisCustomer = new Customer();
                quoteViewModel.thisCustomerDeliveryAddress = new AddressViewModel();
                quoteViewModel.thisCustomerInvoiceAddress = new CustomerAddress();
                quoteViewModel.thisExtraItems = new List<ExtraItem>();
                quoteViewModel.thisGlassItems = new List<GlassItem>();
                quoteViewModel.thisPeripheralItems = new List<PeripheralItem>();
                quoteViewModel.IsNewQuote = true;


                quoteViewModel.thisCustomerDeliveryAddress.thisAddress = new CustomerAddress();

                //quoteViewModel.ActiveCustomers = _context.Customers.ToList();
                //ViewBag.ActiveCustomers = quoteViewModel.ActiveCustomers;
            }
            else
            {
                // Load existing quote data for editing.

                quoteViewModel.IsNewQuote = false;
                quoteViewModel.thisQuote = _context.Quotes.Where(q => q.Id == Id).Single();
                quoteViewModel.thisBifoldItems = _context.BifoldItems.Where(b => b.QuoteId == Id).OrderBy(b => b.ItemNumber).ToList();

                quoteViewModel.thisBifoldItemViewModels = new List<BifoldItemViewModel>();
                BifoldItemViewModel bifoldItemViewModel;

                if (quoteViewModel.thisBifoldItems.Count > 0)
                {
                    foreach (BifoldItem bifoldItem in quoteViewModel.thisBifoldItems)
                    {
                        bifoldItemViewModel = new BifoldItemViewModel();
                        bifoldItemViewModel.thisBifoldItem = bifoldItem;
                        // bifoldItemViewModel.InternalColourName = _context.ProfileColours.Where(c => c.Id == bifoldItem.InternalColourId).Select(c => c.ColourName).Single();
                        //bifoldItemViewModel.ExternalColourName = _context.ProfileColours.Where(c => c.Id == bifoldItem.ExternalColourId).Select(c => c.ColourName).Single();

                        ProfileColour internalColour = _context.ProfileColours.Where(p => p.Id == bifoldItem.InternalColourId).Single();

                        if (internalColour.IsAffordableStockColour == true)
                        {
                            quoteViewModel.IsStockColourChosen = true;
                        }
                        else
                        {
                            quoteViewModel.IsStockColourChosen = false;
                        }


                        quoteViewModel.thisBifoldItemViewModels.Add(bifoldItemViewModel);
                    }
                }
            }

          

           

            quoteViewModel.ActiveCustomers = _context.Customers.ToList();
            ViewBag.ActiveCustomers = quoteViewModel.ActiveCustomers;


            //quoteViewModel.StockProfileColours = _context.ProfileColours.Where(p => p.IsAffordableStockColour == true && p.IsEnabled == true).OrderBy(p => p.ColourCode).ToList();


            quoteViewModel.StockProfileColours = _context.ProfileColours.Where(p => p.IsAffordableStockColour == true && p.IsEnabled == true).OrderBy(p => p.ColourCode).ToList();

            quoteViewModel.NonStockProfileColours = _context.ProfileColours.Where(p => p.IsAffordableStockColour == false && p.IsEnabled == true).OrderBy(p => p.ColourCode).ToList();

            foreach (ProfileColour col in quoteViewModel.StockProfileColours)
            {
                col.ColourDisplayName = $"{col.ColourCode} {col.ColourName} {col.ColourFinish}";
            }

            foreach (ProfileColour col in quoteViewModel.NonStockProfileColours)
            {
                col.ColourDisplayName = $"{col.ColourCode} {col.ColourName} {col.ColourFinish}";
            }


            return View(quoteViewModel);
        }

    
        // POST
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateOrEdit(QuoteViewModel quoteViewModel)
        {
            if(quoteViewModel.thisQuote.Id == null)
            {
                // New Quote
                quoteViewModel.thisQuote.Id = Guid.NewGuid().ToString();
                quoteViewModel.thisQuote.CreatedByUserId = HttpContext.Session.GetString("UserId");
                quoteViewModel.thisQuote.CreatedDateTime = DateTime.Now;
                quoteViewModel.thisQuote.LastModifiedByUserId = HttpContext.Session.GetString("UserId");
                quoteViewModel.thisQuote.LastModifiedDateTime = DateTime.Now;

                quoteViewModel.thisCustomer = _context.Customers.Where(c => c.Id == quoteViewModel.thisQuote.CustomerId).Single();

                quoteViewModel.thisQuote.IsTaxExempt = quoteViewModel.thisCustomer.IsTaxExempt;

                // Extract despatch site from delivery/collection address.

                if (quoteViewModel.thisQuote.DeliveryAddress != null)
                {
                    quoteViewModel.thisQuote.DespatchSite =
    quoteViewModel.thisQuote.DeliveryAddress.Substring(quoteViewModel.thisQuote.DeliveryAddress.IndexOf("[")).Replace("[", "").Replace("]", "").TrimEnd();
                }
  

                // Establish next quote ref
                string lastRef = "";
                lastRef = _context.Quotes
                    .Where(q => (q.QuoteReferenceNumber).Substring(0, q.QuoteReferenceNumber.IndexOf("-")) == quoteViewModel.thisQuote.CustomerId.Substring(0, 3))
                    .OrderByDescending(x => x.CreatedDateTime)
                    .Take(1)
                    .Select(q => q.QuoteReferenceNumber).FirstOrDefault();

                if (lastRef != null)
                {
                    int increment = Convert.ToInt32(lastRef.Substring(9));
                    quoteViewModel.thisQuote.QuoteReferenceNumber = $"{quoteViewModel.thisQuote.CustomerId.Substring(0, 3)}-{DateTime.Now.Year}-{increment += 1}";
                }
                else
                {
                    quoteViewModel.thisQuote.QuoteReferenceNumber = $"{quoteViewModel.thisQuote.CustomerId.Substring(0, 3)}-{DateTime.Now.Year}-1";
                }

                
                
                if (ModelState.IsValid)
                {
                    if(quoteViewModel.thisCustomerDeliveryAddress.DeliverySaveAddress == true)
                    {
                        // Save new delivery address to customer record.
                        CustomerAddress newDeliveryAddress = new CustomerAddress();
                        newDeliveryAddress.AddressLine1 = quoteViewModel.thisCustomerDeliveryAddress.DeliveryAddressLine1;
                        newDeliveryAddress.AddressLine2 = quoteViewModel.thisCustomerDeliveryAddress.DeliveryAddressLine2;
                        newDeliveryAddress.TownCity = quoteViewModel.thisCustomerDeliveryAddress.DeliveryTownCity;
                        newDeliveryAddress.County = quoteViewModel.thisCustomerDeliveryAddress.DeliveryCounty;
                        newDeliveryAddress.PostCode = quoteViewModel.thisCustomerDeliveryAddress.DeliveryPostCode;
                        newDeliveryAddress.CreatedByUserId = HttpContext.Session.GetString("UserId");
                        newDeliveryAddress.CreatedDateTime = DateTime.Now;
                        newDeliveryAddress.CustomerId = quoteViewModel.thisQuote.CustomerId;
                        newDeliveryAddress.DespatchSite = quoteViewModel.thisCustomerDeliveryAddress.DeliveryDespatchSite;

                        newDeliveryAddress.Id = Guid.NewGuid().ToString();
                        newDeliveryAddress.IsInvoiceAddress = false;

                        newDeliveryAddress.IsPrimaryDeliveryAddress = false;
                        newDeliveryAddress.ValidatedByGoogleAPI = quoteViewModel.thisCustomerDeliveryAddress.ValidatedByGoogleAPI;

                        _context.CustomerAddresses.Add(newDeliveryAddress);
                        _context.SaveChanges();
                    }



                    _context.Quotes.Add(quoteViewModel.thisQuote);
                    _context.SaveChanges();

                    return RedirectToAction("CreateOrEdit", new { id = quoteViewModel.thisQuote.Id });
                }
                else
                {
                    // Populate collections etc so validation form is populated with options.
                    quoteViewModel.ActiveCustomers = _context.Customers.ToList();
                    ViewBag.ActiveCustomers = quoteViewModel.ActiveCustomers;

                    List<CustomerAddress> customerAddresses = new List<CustomerAddress>();
                    customerAddresses = _context.CustomerAddresses.Where(c => c.CustomerId == quoteViewModel.thisQuote.CustomerId).ToList();

                    List<SelectListItem> stringAddresses = new List<SelectListItem>();

                    if (customerAddresses.Count > 0){

                     

                        //'<option selected="selected" selected disabled value="-1">-- Select Delivery Address --</option>'
                        if (quoteViewModel.thisQuote.DeliveryAddress == null)
                        {
                            stringAddresses.Add(new SelectListItem {Selected=true, Disabled = true, Value = "-1", Text = "-- Select Delivery Address --" });
                        }
                        else
                        {
                            stringAddresses.Add(new SelectListItem { Disabled = true, Value = "-1", Text = "-- Select Delivery Address --" });
                        }
                        

                        foreach (CustomerAddress address in customerAddresses)
                        {

                            stringAddresses.Add(new SelectListItem
                            {
                                Value = $"{address.AddressLine1}, {address.AddressLine2}, {address.TownCity}, {address.County}, {address.PostCode}, [{address.DespatchSite}]",
                                Text = $"{address.AddressLine1}, {address.AddressLine2}, {address.TownCity}, {address.County}, {address.PostCode}, [{address.DespatchSite}]"
                            });
               
                        }
                    }

                    quoteViewModel.DeliveryAddresses = stringAddresses;

                    quoteViewModel.StockProfileColours = _context.ProfileColours.Where(p => p.IsAffordableStockColour == true && p.IsEnabled == true).OrderBy(p => p.ColourCode).ToList();

                    quoteViewModel.NonStockProfileColours = _context.ProfileColours.Where(p => p.IsAffordableStockColour == false && p.IsEnabled == true).OrderBy(p => p.ColourCode).ToList();

                    foreach (ProfileColour col in quoteViewModel.StockProfileColours)
                    {
                        col.ColourDisplayName = $"{col.ColourCode} {col.ColourName} {col.ColourFinish}";
                    }

                    foreach (ProfileColour col in quoteViewModel.NonStockProfileColours)
                    {
                        col.ColourDisplayName = $"{col.ColourCode} {col.ColourName} {col.ColourFinish}";
                    }


                    quoteViewModel.thisBifoldItems = new List<BifoldItem>();
                    quoteViewModel.thisExtraItems = new List<ExtraItem>();
                    quoteViewModel.thisGlassItems = new List<GlassItem>();
                    quoteViewModel.thisPeripheralItems = new List<PeripheralItem>();
                    quoteViewModel.IsNewQuote = true;

                    return View("CreateOrEdit", quoteViewModel);
                }

            }
            else
            {
                // Edit Existing Quote


                if (ModelState.IsValid)
                {
                    //Save edit details

                    quoteViewModel.thisQuote.LastModifiedByUserId = HttpContext.Session.GetString("UserId");
                    quoteViewModel.thisQuote.LastModifiedDateTime = DateTime.Now;

                    bool updateBifoldItem = false;

                    foreach (BifoldItemViewModel bifoldItemViewModel in quoteViewModel.thisBifoldItemViewModels)
                    {
                        if(bifoldItemViewModel.thisBifoldItem.InternalColourId != quoteViewModel.thisQuote.MasterInternalColourId)
                        {
                            bifoldItemViewModel.thisBifoldItem.InternalColourId = quoteViewModel.thisQuote.MasterInternalColourId;
                            updateBifoldItem = true;
                        }

                        if (bifoldItemViewModel.thisBifoldItem.ExternalColourId != quoteViewModel.thisQuote.MasterExternalColourId)
                        {
                            bifoldItemViewModel.thisBifoldItem.ExternalColourId = quoteViewModel.thisQuote.MasterExternalColourId;
                            updateBifoldItem = true;
                        }

                        if (bifoldItemViewModel.thisBifoldItem.IsMarineOrHazardousCoating != quoteViewModel.thisQuote.IsMarineOrHazardousCoating)
                        {
                            bifoldItemViewModel.thisBifoldItem.IsMarineOrHazardousCoating = quoteViewModel.thisQuote.IsMarineOrHazardousCoating;
                            updateBifoldItem = true;
                        }

            

                        //Update Bifold Item

                        updateBifoldItem = false;
                        
                    }


                    return RedirectToAction("CreateOrEdit", new { id = quoteViewModel.thisQuote.Id });
                }
                else
                {
                  


                    // Populate collections etc so validation form is populated with options.
                    quoteViewModel.ActiveCustomers = _context.Customers.ToList();
                    ViewBag.ActiveCustomers = quoteViewModel.ActiveCustomers;

                    List<CustomerAddress> customerAddresses = new List<CustomerAddress>();
                    customerAddresses = _context.CustomerAddresses.Where(c => c.CustomerId == quoteViewModel.thisQuote.CustomerId).ToList();

                    List<SelectListItem> stringAddresses = new List<SelectListItem>();

                    if (customerAddresses.Count > 0)
                    {



                        //'<option selected="selected" selected disabled value="-1">-- Select Delivery Address --</option>'
                        if (quoteViewModel.thisQuote.DeliveryAddress == null)
                        {
                            stringAddresses.Add(new SelectListItem { Selected = true, Disabled = true, Value = "-1", Text = "-- Select Delivery Address --" });
                        }
                        else
                        {
                            stringAddresses.Add(new SelectListItem { Disabled = true, Value = "-1", Text = "-- Select Delivery Address --" });
                        }


                        foreach (CustomerAddress address in customerAddresses)
                        {

                            stringAddresses.Add(new SelectListItem
                            {
                                Value = $"{address.AddressLine1}, {address.AddressLine2}, {address.TownCity}, {address.County}, {address.PostCode}, [{address.DespatchSite}]",
                                Text = $"{address.AddressLine1}, {address.AddressLine2}, {address.TownCity}, {address.County}, {address.PostCode}, [{address.DespatchSite}]"
                            });

                        }
                    }

                    quoteViewModel.DeliveryAddresses = stringAddresses;

                    quoteViewModel.StockProfileColours = _context.ProfileColours.Where(p => p.IsAffordableStockColour == true && p.IsEnabled == true).OrderBy(p => p.ColourCode).ToList();


                    quoteViewModel.thisBifoldItems = _context.BifoldItems.Where(b => b.QuoteId == quoteViewModel.thisQuote.Id).OrderBy(b => b.ItemNumber).ToList();

                    quoteViewModel.thisBifoldItemViewModels = new List<BifoldItemViewModel>();
                    BifoldItemViewModel bifoldItemViewModel;

                    if (quoteViewModel.thisBifoldItems.Count > 0)
                    {
                        foreach (BifoldItem bifoldItem in quoteViewModel.thisBifoldItems)
                        {
                            bifoldItemViewModel = new BifoldItemViewModel();
                            bifoldItemViewModel.thisBifoldItem = bifoldItem;
                            // bifoldItemViewModel.InternalColourName = _context.ProfileColours.Where(c => c.Id == bifoldItem.InternalColourId).Select(c => c.ColourName).Single();
                            //bifoldItemViewModel.ExternalColourName = _context.ProfileColours.Where(c => c.Id == bifoldItem.ExternalColourId).Select(c => c.ColourName).Single();

                            ProfileColour internalColour = _context.ProfileColours.Where(p => p.Id == bifoldItem.InternalColourId).Single();

                            if (internalColour.IsAffordableStockColour == true)
                            {
                                quoteViewModel.IsStockColourChosen = true;
                            }
                            else
                            {
                                quoteViewModel.IsStockColourChosen = false;
                            }


                            quoteViewModel.thisBifoldItemViewModels.Add(bifoldItemViewModel);
                        }
                    }


                    quoteViewModel.thisExtraItems = new List<ExtraItem>();
                    quoteViewModel.thisGlassItems = new List<GlassItem>();
                    quoteViewModel.thisPeripheralItems = new List<PeripheralItem>();
                    quoteViewModel.IsNewQuote = false;

                    



                    return View("CreateOrEdit", quoteViewModel);
                }



            }



           
        }




        public IActionResult GetActiveCustomersRefresh()
        {

            

            return PartialView("");
        }


        // POST: Quote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,CreatedByUserId,CreatedDateTime,CustomerReference,MasterInternalColourId,MasterExternalColourId,QuoteReferenceNumber,ListCode,RequestedDeliveryDate,ApprovedByUserId,ApprovedDateTime,DeliveryMethod,IsGlassRequired,IsCancelled,CancelledByUserId,CancelledDateTime,InvoiceAmountNet,InvoiceAmountVat,DepositAmount,IsTaxExempt,DeliveryAddress,DespatchSite,Priority,LastModifiedByUserId,LastModifiedDateTime,DespatchNotes,AdditionalNotes,NotifySalesWhenFabricated")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quote);
        }

        // GET: Quote/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            return View(quote);
        }

        // POST: Quote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,CustomerId,CreatedByUserId,CreatedDateTime,CustomerReference,MasterInternalColourId,MasterExternalColourId,QuoteReferenceNumber,ListCode,RequestedDeliveryDate,ApprovedByUserId,ApprovedDateTime,DeliveryMethod,IsGlassRequired,IsCancelled,CancelledByUserId,CancelledDateTime,InvoiceAmountNet,InvoiceAmountVat,DepositAmount,IsTaxExempt,DeliveryAddress,DespatchSite,Priority,LastModifiedByUserId,LastModifiedDateTime,DespatchNotes,AdditionalNotes,NotifySalesWhenFabricated")] Quote quote)
        {
            if (id != quote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteExists(quote.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(quote);
        }

        // GET: Quote/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // POST: Quote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var quote = await _context.Quotes.FindAsync(id);
            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuoteExists(string id)
        {
            return _context.Quotes.Any(e => e.Id == id);
        }



        [HttpPost]
        public ActionResult CalculateItemQuote(BifoldItemViewModel bifoldItemViewModel)
        {
            
            // Add Validation to cancel calculation if missing values.


            bifoldItemViewModel.PricingFactors = _context.PricingFactors.Where(p => p.Id == 1).Single();


            // Reset base to zero.
            bifoldItemViewModel.ItemQuoteValue = 0.00M;

            // Set base bifold cost depending on sash widths.
            if ((bifoldItemViewModel.thisBifoldItem.Width / bifoldItemViewModel.SelectedDoorQuantity) < 1000)
            {
                bifoldItemViewModel.ItemQuoteValue = Math.Round(bifoldItemViewModel.PricingFactors.MullionSplitsUnder1000MMSurcharge * bifoldItemViewModel.SelectedDoorQuantity, 2);
            }
            else
            {
                bifoldItemViewModel.ItemQuoteValue = Math.Round(bifoldItemViewModel.PricingFactors.MullionSplits1000MMAndOverSurcharge * bifoldItemViewModel.SelectedDoorQuantity, 2);
            }

            // Add surcharge for sash height's over 2100mm.
            if(bifoldItemViewModel.thisBifoldItem.Height > 2100)
            {
                bifoldItemViewModel.ItemQuoteValue = bifoldItemViewModel.ItemQuoteValue + (Math.Round((bifoldItemViewModel.ItemQuoteValue / 100) * bifoldItemViewModel.PricingFactors.SashHeightAbove2100MMSurcharge, 2));
            }

            // Add surcharge for Marine Grade Coating.
            if (bifoldItemViewModel.thisBifoldItem.IsMarineOrHazardousCoating)
            {
                bifoldItemViewModel.ItemQuoteValue = bifoldItemViewModel.ItemQuoteValue + (Math.Round((bifoldItemViewModel.ItemQuoteValue / 100) * bifoldItemViewModel.PricingFactors.MarineHazardousCoatingSurcharge, 2));
            }


            ProfileColour internalColour = _context.ProfileColours.Where(p => p.Id == bifoldItemViewModel.thisBifoldItem.InternalColourId).FirstOrDefault();
            ProfileColour externalColour = _context.ProfileColours.Where(p => p.Id == bifoldItemViewModel.thisBifoldItem.ExternalColourId).FirstOrDefault();


            if (externalColour.IsSmartSensations == true|| internalColour.IsSmartSensations == true)
            {
                // Add surcharge for Sensations Coating
                bifoldItemViewModel.ItemQuoteValue = bifoldItemViewModel.ItemQuoteValue + (Math.Round((bifoldItemViewModel.ItemQuoteValue / 100) * bifoldItemViewModel.PricingFactors.SmartSensationSurCharge, 2));
            }
            else if (externalColour.IsSmartAlchemy == true || internalColour.IsSmartAlchemy == true)
            {
                // Add surcharge for Alchemy Coating
                bifoldItemViewModel.ItemQuoteValue = bifoldItemViewModel.ItemQuoteValue + (Math.Round((bifoldItemViewModel.ItemQuoteValue / 100) * bifoldItemViewModel.PricingFactors.SmartAlchemySurcharge, 2));
            }
            else if (internalColour.IsAffordableStockColour == false || externalColour.IsAffordableStockColour == false)
            {
                if (externalColour.Id == internalColour.Id)
                {
                    // Add Surcharge for Non stock single RAL colour
                    bifoldItemViewModel.ItemQuoteValue = bifoldItemViewModel.ItemQuoteValue + (Math.Round((bifoldItemViewModel.ItemQuoteValue / 100) * bifoldItemViewModel.PricingFactors.NonStockSingleColourSurCharge, 2));
                }
                else
                {
                    // Add surcharge for non stock dual RAL colour
                    bifoldItemViewModel.ItemQuoteValue = bifoldItemViewModel.ItemQuoteValue + (Math.Round((bifoldItemViewModel.ItemQuoteValue / 100) * bifoldItemViewModel.PricingFactors.NonStockDualColourSurCharge, 2));
                }

            }



            return PartialView("~/Views/BifoldItem/_BifoldItemHeader.cshtml", bifoldItemViewModel);
        }




    }
}
