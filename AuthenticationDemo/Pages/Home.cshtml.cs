using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthenticationDemo.Pages
{
    public class HomeModel : PageModel
    {
        public void OnGet()
        {
        }

        public ActionResult OnGetLogout()
        {
            HttpContext.SignOutAsync();
            return RedirectToPage("/Home");
        }
    }
}
