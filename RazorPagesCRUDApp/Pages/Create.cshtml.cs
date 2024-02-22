using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCRUDApp.DataAccess;

namespace RazorPagesCRUDApp.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Employee emp {  get; set; }
        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            //INSERT record using DAL component
            EmployeeDataAccess dal = new EmployeeDataAccess();
            dal.AddEmployee(emp);

            return RedirectToPage("./Home");
        }
    }
}
