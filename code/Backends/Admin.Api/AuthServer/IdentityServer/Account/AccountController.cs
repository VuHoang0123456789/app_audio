using Microsoft.AspNetCore.Mvc;

namespace AuthServer.IdentityServer.Account
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
