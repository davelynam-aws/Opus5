using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OPUS_Demo_5.Models;
using OPUS_Demo_5.Models.CustomerManagement;
using OPUS_Demo_5.Models.DataContexts;
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


        //public async Task<IActionResult> ShowCustomerDetails(string id = "")
        //{

        //    if (id == "")
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        CustomerAddress customerAddress = await _context.CustomerAddresses.Where(c => c.CustomerId == id).FirstAsync();
        //    }
        //    return View();
        //}

        public ActionResult PartialView(string customerId)
        {
            // string testCustomerId = "38bfd195-3c44-4505-b70d-165c519ce649";

            CustomerAddress customerAddress = new CustomerAddress();

            //if (customerId == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
          //      customerAddress = _context.CustomerAddresses.Where(a => a.CustomerId == customerId).Single();
          //  }

            if (customerId == null)
            {
                return Content("");
            }
            else
            {
                customerAddress = _context.CustomerAddresses.Where(a => a.CustomerId == customerId).Single();
            }


            return PartialView("~/Views/Shared/_CustomerInvoiceAddress.cshtml", customerAddress);
        }


        //public ActionResult PartialView(string countrylist, clsStakes clsStakes)
        //{
        //    if (countrylist == null)
        //    {
        //        clsStakes.Country = "IRE";
        //    }
        //    else
        //    {
        //        clsStakes.Country = countrylist;
        //    }

        //    StakesDetails stakesDetails = new StakesDetails();
        //    return PartialView("~/Views/Shared/_PartialStakes.cshtml", stakesDetails.StacksList(clsStakes.Country));

        //}


        //public ActionResult ShowCustomerInvoiceAddress(IFormCollection formCollection)
        //{

        //    string customerId = formCollection["CustomerId"];

        //    CustomerAddress customerAddress;

        //    if (customerId != "")
        //    {
        //         customerAddress = _context.CustomerAddresses.Where(a => a.CustomerId == customerId).Single();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }


        //    return PartialView("_CustomerInvoiceAddress.cshtml", customerAddress);
        //}






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
                    
                    bifoldItems = await _context.BifoldItems.Where(b => b.QuoteId == quote.Id).ToListAsync();
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

        // GET: Quote/Details/5
        public async Task<IActionResult> Details(string id)
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

        // GET: Quote/Create
        public IActionResult Create()
        {
            // Populate combo's etc


            //var activeCustomers = from c in _context.Customers
            //                      orderby c.CustomerName
            //                      select c;
            //ViewBag.ActiveCustomers = new SelectList(activeCustomers, "CustomerId", "CustomerName", null);

            QuoteViewModel quoteViewModel = new QuoteViewModel();
            quoteViewModel.thisQuote = new Quote();

            //List<Customer> activeCustomers = _context.Customers.Where(c => c.IsActiveCustomer == true).ToList();

           // quoteViewModel.ActiveCustomers = activeCustomers;

       
            //quoteViewModel.ActiveCustomers = new SelectList(activeCustomers, "CustomerId", "CustomerName", null);

            //quoteViewModel.thisQuote.CustomerId = ""; 

            //ViewBag.Customers = new SelectList(activeCustomers, "CustomerId", "CustomerName", null);



            quoteViewModel.ActiveCustomers = _context.Customers.ToList();
            ViewBag.ActiveCustomers = quoteViewModel.ActiveCustomers;


            return View(quoteViewModel);
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
    }
}
