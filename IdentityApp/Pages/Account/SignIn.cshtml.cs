using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace IdentityApp.Pages.Account
{
    public class SignInModel : PageModel
    {
        public SignInModel(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }
        public SignInManager<AppUser> SignInManager { get; set; }
        public UserManager<AppUser> UserManager { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [BindProperty]
        public bool RememberMe { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                SignInResult result = await SignInManager.PasswordSignInAsync(Email, Password, true, true);
                if (result.Succeeded)
                {
                    return Redirect(ReturnUrl ?? "/");
                    
                }
            }
            return Page();

        }


    }
}
