using Microsoft.AspNetCore.Mvc;
using MVCCorePrj.Models;
using System.Diagnostics;

using MVCCorePrj.Models; //for Models


namespace MVCCorePrj.Controllers
{
    //[Route("MyApp")]
    public class HomeController : Controller
    {
        private readonly IEmpDataAccess _dal;
        public HomeController(IEmpDataAccess dal)
        {
            _dal = dal;
        }       
        public IActionResult Display()
        {
            var message = "Welcome to India";
            ViewData.Add("msg", message);
            return View();
        }

        //[Route("GetEmps")]
        public IActionResult DisplayEmps()
        {
            var lstEmps = _dal.GetEmps();
            return View(lstEmps);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(/*[Bind(include:"Ecode,Deptid")]*/Employee emp)
        {
            if(emp.Deptid!=201 && emp.Deptid!=202 && emp.Deptid!=203)
            {
                ModelState.AddModelError("Deptid", "Deptid must be either 201,202 or 203");
            }


            if (ModelState.IsValid)
            {
                //insert record using DAL layer
                _dal.AddEmployee(emp);
                return RedirectToAction("DisplayEmps");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        //[Route("RemoveEmp/{id}")]
        public IActionResult Delete(int id)
        {
            //delete record using DAL
            _dal.DeleteEmployee(id);
            return RedirectToAction("DisplayEmps");
        }

        [HttpGet]
        //[Route("GetEmpById/{id:int}")]
        public IActionResult Details(int id)
        {
            //get emp by id using DAL layer
            var emp =_dal.GetEmpById(id);
            return View(emp);
        }

        [HttpGet]
        //[Route("ModifyEmp/{id}")]
        public IActionResult Edit(int id)
        {
            //get the emp by id for update view
            var emp=_dal.GetEmpById(id);
            //return view for update
            return View(emp);
        }

        [HttpPost]
        //[HttpGet]
        //[Route("SaveEmp/{ecode}/{ename}/{salary}/{deptid}")]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                //update the record using DAL layer
                _dal.UpdateEmployee(emp);
                return RedirectToAction("DisplayEmps");
            }
            else
            {
                return View();
            }
        }


        [Route("Add/{a:int}/{b:int}")]
        [HttpGet]
        public string AddNumbers(int a, int b)
        {
            return "sum of " + a + " and " + b + " is " + (a + b);
        }
    }
}
