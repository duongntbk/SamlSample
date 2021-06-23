using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SamlSample.Pages
{
    [AllowAnonymous]
    public class AccountModel : PageModel
    {
        public IActionResult OnGetLogin(string returnUrl)
        {
            var redirectUri = Url.Page("account", "callback", new { returnUrl });
            return new ChallengeResult("Saml2",
                new AuthenticationProperties() { IsPersistent = true, RedirectUri = redirectUri });
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl)
        {
            var auth = await HttpContext.AuthenticateAsync();

            if (!auth.Succeeded)
            {
                return Unauthorized();
            }

            await HttpContext.SignInAsync(auth.Principal, auth.Properties);

            return LocalRedirect(returnUrl);
        }
    }
}
