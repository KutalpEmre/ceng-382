using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ceng382.Models.Identity;

namespace Ceng382.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect(returnUrl ?? "~/");
        }
    }
}
