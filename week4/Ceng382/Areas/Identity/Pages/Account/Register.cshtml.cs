using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ceng382.Models.Identity;
using Ceng382.Models.ViewModels.Account;

namespace Ceng382.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public RegisterInputModel Input { get; set; } = new();

        public string? ReturnUrl { get; set; }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid)
                return Page();

            var user = new ApplicationUser
            {
                UserName = Input.Email,
                Email = Input.Email,
                FullName = Input.FullName
            };

            if (Input.ProfilePhoto != null && Input.ProfilePhoto.Length > 0)
            {
                using var ms = new MemoryStream();
                await Input.ProfilePhoto.CopyToAsync(ms);
                user.ProfilePhoto = ms.ToArray();
                user.ProfilePhotoType = Input.ProfilePhoto.ContentType;
            }

            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
