using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OPUS_Demo_5.Models;
using OPUS_Demo_5.Models.DataContexts;

namespace OPUS_Demo_5.Controllers
{
    public class EmpClassController : Controller
    {

        private readonly OpusContext _context;

        public EmpClassController(OpusContext context)
        {
            _context = context;
        }

        public IEnumerable<EmpClass> displaydata { get; set; }

        public IActionResult Index()
        {
           
            displaydata = _context.Employee.ToList();
            ViewBag.displaydata = displaydata;
            return View();
        }
    }
}
