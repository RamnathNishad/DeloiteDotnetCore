using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloWorldRazorWebApp.Pages
{
    public class HomeModel : PageModel
    {

        public string Message { get; set; }

        public Employee EmpObj { get; set; }

        public List<Employee> EmpList { get; set; }
        public void OnGet()
        {
            Message = "Welcome to India";

            EmpObj = new Employee
            {
                Ecode=101,
                Ename="Ramnath",
                Salary=1111,
                Deptid=201
            };
            //DAL 
            EmpList = new List<Employee>
            {
                new Employee{Ecode=101,Ename="Ravi",Salary=1111,Deptid=201},
                new Employee{Ecode=102,Ename="Rahul",Salary=2222,Deptid=202},
                new Employee{Ecode=103,Ename="Raman",Salary=3333,Deptid=203},
                new Employee{Ecode=104,Ename="Rohit",Salary=4444,Deptid=202},
                new Employee{Ecode=105,Ename="Suresh",Salary=5555,Deptid=201}
            };
        }
    }
}
