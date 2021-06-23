using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SamlSample.Extensions;

namespace SamlSample.Pages
{
    [Authorize(AuthenticationSchemes = AuthenticationScheme.Saml)]
    public class SecretModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
