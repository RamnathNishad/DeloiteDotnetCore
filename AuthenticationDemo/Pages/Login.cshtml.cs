using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AuthenticationDemo.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            //if the user is valid in Database
            if(Username=="admin" && Password=="abc")
            {
                //sign the user and store user info in authenication cookie i.e. in browser
                List<Claim> claims = new List<Claim>
                {
                    new Claim("username",Username),
                    //new Claim("password",Password),
                    //new Claim("company","deloitte")
                    //new Claim("secretKey","djjshfhfhskjdhfdjgfd")
                };

                ClaimsIdentity identities = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identities);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                
                return RedirectToPage("/Home");
            }
            else
            {
                return Page();
            }
        }
    }
}
