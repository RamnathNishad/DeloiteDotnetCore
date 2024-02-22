using EFCoreDBFirstDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDBFirstDemo.Controllers
{
    public class EFCrudController : Controller
    {
        private readonly EmpDbContext dbCtx;
        public EFCrudController(EmpDbContext empDbContext)
        {
            this.dbCtx = empDbContext;
        }
        public IActionResult Index()
        {
            var lstEmps = dbCtx.TblEmployees.ToList();

            return View(lstEmps);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TblEmployee emp)
        {
            //insert record using DbCtx
            dbCtx.TblEmployees.Add(emp);
            dbCtx.SaveChanges(); //this is imp to make changes in database permanent

            return RedirectToAction("Index");
        }
    }
}
