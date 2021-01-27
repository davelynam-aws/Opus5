using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
            // TEMPORARILLY DISABLE LOGIN FOR TESTING.
            HttpContext.Session.SetString("LoggedInUser", "David Lynam");

            HttpContext.Session.SetString("UserId", "fa3d1bee-a4d1-4689-adb6-9388eb3879e5");

            HttpContext.Session.SetString("UserBranchId", "1fcf0d2c-b73f-4f10-b1f6-9c282569c4a3");


            //if (HttpContext.Session.GetString("LoggedInUser") == null || HttpContext.Session.GetString("LoggedInUser") == "")
            //{
            //    return RedirectToAction("SignIn", "Account");
            //}
            //else
            //{
            //    return View();
            //}
            return View();
        }


       


        public HomeController(OpusContext db)
        {
            _db = db;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
