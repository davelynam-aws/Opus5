using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OPUS_Demo_5.Models;
using OPUS_Demo_5.Models.UserIdentity;

namespace OPUS_Demo_5.Controllers
{


    public class AccountController : Controller
    {

        private static string _mduDb;

        public IActionResult Index()
        {



            return RedirectToAction("Login");
        }


        //Get this working from a view and _layout
        // Get.
        public IActionResult LogIn(/*GlobalVariables options*/)
        {
            //_mduDb = options.loggedInUser;

            //options.loggedInUser = "new value";

            //_mduDb = options.loggedInUser;


            return View();
        }
    }
}
