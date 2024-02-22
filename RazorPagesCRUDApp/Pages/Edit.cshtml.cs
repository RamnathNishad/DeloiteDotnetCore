using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCRUDApp.DataAccess;

namespace RazorPagesCRUDApp.Pages
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public Employee emp {  get; set; }
        public void OnGet(int id)
        {
            //DAL to get Emp By Id
            EmployeeDataAccess dal=new EmployeeDataAccess();
            emp=dal.GetEmpById(id);
        }

        public ActionResult OnPost()
        {
            EmployeeDataAccess dal = new EmployeeDataAccess();
            dal.UpdateEmployee(emp);
            return RedirectToPage("./Home");
        }
    }
}
