using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.IdentityServer.Account
{
    public class ExternalController : Controller
    {
        public IActionResult Challenge(string scheme, string returnUrl)
        {
            var props = new AuthenticationProperties
            {
                //RedirectUri = Url.Action(nameof(Callback)),
                RedirectUri = "",
                Items =
                {
                    { "returnUrl", returnUrl },
                    { "scheme", scheme },
                }
            };

            return Challenge(props, scheme);
        }
    }
}
