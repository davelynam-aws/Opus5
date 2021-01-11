using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OPUS_Demo_5.Models.DataContexts;
using OPUS_Demo_5.Models.QuoteMatrix;

namespace OPUS_Demo_5.Controllers
{
    public class PricingFactorController : Controller
    {

        private readonly OpusContext _context;

        public PricingFactorController(OpusContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return RedirectToAction("Details");
        }


        public IActionResult Details()
        {
            PricingFactor pricingFactor = new PricingFactor();

            pricingFactor = _context.PricingFactors.Where(p => p.Id == 1).Single();


            return View(pricingFactor);
        }

        //GET - EDIT
        public IActionResult Edit()
        {

            PricingFactor pricingFactor = _context.PricingFactors.Find(1);

            if (pricingFactor == null)
            {
                return NotFound();
            }

            return View(pricingFactor);
        }
    }
}
