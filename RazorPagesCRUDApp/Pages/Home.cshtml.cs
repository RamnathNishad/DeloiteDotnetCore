using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCRUDApp.DataAccess;

namespace RazorPagesCRUDApp.Pages
{
    public class HomeModel : PageModel
    {
        public List<Employee> emps { get; set; }
        public ActionResult OnGet()
        {
            //get the username from the session 
            string username = HttpContext.Session.GetString("username");

            if (string.IsNullOrEmpty(username))
            {
                //redirect to login page
                return RedirectToPage("./Login");
            }
            else
            {   //get all the records using DAL component
                EmployeeDataAccess dal = new EmployeeDataAccess();
                emps = dal.GetEmps();
                return this.Page();
            }
        }

        public ActionResult OnPostDelete(int id)
        {
            //DELETE record using DAL component
            EmployeeDataAccess dal=new EmployeeDataAccess();
            dal.DeleteEmp(id);
            return RedirectToPage("./Home");
        }

        public ActionResult OnGetLogout()
        {
            //remove the username from the session
            HttpContext.Session.Remove("username");
            //redirect to login
            return RedirectToPage("./Login");
        }
    }
}
