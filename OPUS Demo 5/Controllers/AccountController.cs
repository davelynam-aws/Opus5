using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OPUS_Demo_5.Models;
using OPUS_Demo_5.Models.UserIdentity;
using OPUS_Demo_5.Models.DataContexts;
using Microsoft.AspNetCore.Http;

namespace OPUS_Demo_5.Controllers
{


    public class AccountController : Controller
    {
        private OpusContext _db;

        public AccountController(OpusContext db)
        {
            _db = db;
        }

        private static string loggedInUser;

        public IActionResult Index()
        {
            


            return RedirectToAction("Login");
        }


        //Get this working from a view and _layout
        // Get.
        public IActionResult LogIn()
        {
            //loggedInUser = options.loggedInUser;

            //options.loggedInUser = "new value";

            //loggedInUser = options.loggedInUser;



            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(DemoUserIdentity loginUser)
        {
           // Just for DEMO purposes. Mock user login.

            var results = _db.UserIdentities.Where(u => u.Email == loginUser.Email).Where(u => u.DemoPassword == loginUser.PasswordHash);

            if (results != null)
            {
                foreach(var result in results)
                {
                    HttpContext.Session.SetString("LoggedInUser", result.FullName);
                    HttpContext.Session.SetString("Id", result.Id);
                    HttpContext.Session.SetString("BranchCompanyId", result.BranchCompanyId);
                    HttpContext.Session.SetString("Email", result.Email);
                  
                    break;
                }
            }


            //if (ModelState.IsValid)
            //{
            //    return RedirectToAction("Index", "Home");
            //}


            return RedirectToAction("Index", "Home");
        }
    }
}
