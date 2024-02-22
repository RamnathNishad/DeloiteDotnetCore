using Microsoft.AspNetCore.Mvc;
using StatemanagementPrj.Models;
using System.Diagnostics;

namespace StatemanagementPrj.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "welcome home";

            //TempData.Add("y", 100);

            return View();
        }

        [HttpPost]
        public IActionResult Display(int accnum)
        {
            //ViewData.Add("accnum", accnum);

            //write data to the cookie file
            HttpContext.Response.Cookies.Append("accnum", accnum.ToString());
            return View();
        }

        [HttpPost]
        public IActionResult InfoPage() 
        {
            //ViewData.Add("accnum", accnum);

            //read from the cookie file
            var accnum = HttpContext.Request.Cookies["accnum"];
            ViewData.Add("accnum", accnum);
            return View(); 
        }


    }
}
