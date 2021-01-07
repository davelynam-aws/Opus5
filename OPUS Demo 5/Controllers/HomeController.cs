using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OPUS_Demo_5.Models;
using OPUS_Demo_5.Models.DataContexts;

namespace OPUS_Demo_5.Controllers
{
    public class HomeController : Controller
    {
        private readonly OpusContext _db;

        public IActionResult Index()
        {
            //_db.ThisUser = new Models.UserIdentity.DemoUserIdentity();
            //_db.ThisUser.FullName = "David McVey";


            return View(_db);
        }
        //private readonly ApplicationDbContext _db;

        //public CategoryController(ApplicationDbContext db)
        //{
        //    _db = db;
        //}
     

        public HomeController(OpusContext db)
        {
            _db = db;
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            List<Quote> Quotes = _db.Quotes.ToList();

     
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
