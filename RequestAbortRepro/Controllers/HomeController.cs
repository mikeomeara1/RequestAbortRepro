using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RequestAbortRepro.Models;

namespace RequestAbortRepro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Breakpoint Here. Debug Using IIS Express and Cancel Using the Browser
            //  Then Do it Again Debugging Under Kestrel
            var a = HttpContext.RequestAborted.IsCancellationRequested;
            HttpContext.RequestAborted.ThrowIfCancellationRequested();
            return View();
        }

        public IActionResult About()
        {

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
