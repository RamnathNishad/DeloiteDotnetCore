using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCorePrj.Models;

namespace MVCCorePrj.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateWT()
        {
            var cities = new List<SelectListItem>
            {
                new SelectListItem{Text="Bangalore",Value="BLR"},
                new SelectListItem{Text="Mysore",Value="MYS"},
                new SelectListItem{Text="Delhi",Value="DLI"},
                new SelectListItem{Text="Chennai",Value="CHN"}
            };
            ViewData.Add("cities", cities);
            return View();
        }
        [HttpPost]
        public IActionResult CreateWT(DataDisplay data )
        {
            ViewData.Add("ecode", data.ecode);
            ViewData.Add("password", data.password);
            ViewData.Add("gender", data.gender);
            ViewData.Add("hobbies", data.hobbies.Where(o=>o!="false").ToList());
            ViewData.Add("city", data.city);

            return View("Display");
        }

        [HttpGet]
        public IActionResult CreateST()
        {
            var citiesList = new List<SelectListItem>
            {
                new SelectListItem{Text="Bangalore",Value="BLR"},
                new SelectListItem{Text="Mysore",Value="MYS"},
                new SelectListItem{Text="Delhi",Value="DLI"},
                new SelectListItem{Text="Chennai",Value="CHN"}
            };
            var modelData = new DataDisplay
            {
                genders=new List<string> {"Male","Female" },
                hobbies=new List<string> { "Singing","Dancing","Painting"},
                cities=citiesList
            };

            //ViewData.Add("cities", cities);
            return View(modelData);
        }

        [HttpPost]
        public IActionResult CreateST(DataDisplay data)
        {
            ViewData.Add("ecode", data.ecode);
            ViewData.Add("password", data.password);
            ViewData.Add("gender", data.gender);
            //ViewData.Add("hobbies", data.hobbies.Where(o => o != "false").ToList());
            ViewData.Add("city", data.city);

            return View("Display");
        }
    }
}
