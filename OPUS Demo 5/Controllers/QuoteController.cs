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


        public ActionResult ShowInvoiceAddressPartial(string customerId)
        {
            CustomerAddress customerAddress = new CustomerAddress();

            if (customerId == null)
            {
                return Content("");
            }
            else
            {
                customerAddress = _context.CustomerAddresses.Where(a => a.CustomerId == customerId).Where(a=> a.IsInvoiceAddress == true).Single();
            }
            return PartialView("~/Views/Shared/_CustomerInvoiceAddress.cshtml", customerAddress);
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

        // GET
        public IActionResult AddBifoldItem()
        {
            BifoldItemViewModel bifoldItemViewModel = new BifoldItemViewModel();

            bifoldItemViewModel.thisBifoldItem = new BifoldItem();

            // Increment this from existing.
            bifoldItemViewModel.thisBifoldItem.ItemNumber = 1;

            bifoldItemViewModel.ProfileColourOptions = _context.ProfileColours.ToList();
            bifoldItemViewModel.HardwareColourOptions = _context.HardwareColours.ToList();


            return PartialView("~/Views/BifoldItem/_CreateBifoldItem.cshtml", bifoldItemViewModel);
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

                //quoteViewModel.ActiveCustomers = _context.Customers.ToList();
                //ViewBag.ActiveCustomers = quoteViewModel.ActiveCustomers;
            }
            else
            {
                // Load existing quote data for editing.


                quoteViewModel.thisQuote = _context.Quotes.Where(q => q.Id == Id).Single();
                quoteViewModel.thisBifoldItems = _context.BifoldItems.Where(b => b.QuoteId == Id).ToList();
            }

            quoteViewModel.ActiveCustomers = _context.Customers.ToList();
            ViewBag.ActiveCustomers = quoteViewModel.ActiveCustomers;


            return View(quoteViewModel);
        }

    
        // POST
        [HttpPost]
        public IActionResult CreateOrEdit(QuoteViewModel quoteViewModel)
        {




            return View(quoteViewModel);
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
    }
}
