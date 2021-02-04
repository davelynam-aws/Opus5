using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OPUS_Demo_5.ViewModels;

namespace OPUS_Demo_5.Controllers
{
    public class BifoldItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
