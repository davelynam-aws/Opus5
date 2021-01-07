using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OPUS_Demo_5.Models;
using OPUS_Demo_5.Models.DataContexts;

namespace OPUS_Demo_5.Controllers
{
    public class QuoteController : Controller
    {
        private readonly OpusContext _context;

        public QuoteController(OpusContext context)
        {
            _context = context;
        }

        // GET: Quote
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quotes.ToListAsync());
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
            return View();
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
