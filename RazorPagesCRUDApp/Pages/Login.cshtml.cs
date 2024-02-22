using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace RazorPagesCRUDApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage {  get; set; }
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            //validate the user from Database
            if (Username == "admin" && Password == "abc")
            {
                //valid user
                //1. store the username in the session
                //2. redirect to Home page
                HttpContext.Session.SetString("username", Username);
                return RedirectToPage("./Home");              

            }
            else
            {
                //invalid user
                //return the same login page
                ErrorMessage = "invalid username/password!!!";
                return this.Page();
            }
        }
    }
}
