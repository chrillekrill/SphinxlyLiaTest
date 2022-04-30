using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SphinxlyLiaTest.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public bool IsLoggedIn { get; set; }
        [BindProperty]
        public string? LoginName { get; set; }


        public void OnGet(string loginName, bool isLoggedIn = false)
        {
            this.LoginName = loginName;

            IsLoggedIn = isLoggedIn;

            if(isLoggedIn)
            {      
                if(Request.Cookies["UserCookie"] != null)
                {
                    if (!Request.Cookies["UserCookie"].Equals(loginName))
                    {
                        CreateNewUser();
                    }
                    else
                    {
                        ViewData["Returning"] = "Välkommen tillbaka! Du är inloggad som";
                        ViewData["UserName"] = LoginName;
                    }
                } else
                {
                    CreateNewUser();
                }
      
            } 
        }

        private void CreateNewUser()
        {
            ViewData["Returning"] = "Du är inloggad som";
            Response.Cookies.Append("UserCookie", LoginName);
            ViewData["UserName"] = LoginName;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("Index", new { loginName = LoginName, isLoggedIn = true });
            }

            IsLoggedIn = false;

            return Page();
        }
    }
}