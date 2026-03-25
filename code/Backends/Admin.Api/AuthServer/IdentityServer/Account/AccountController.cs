using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.IdentityServer.Account
{
    public class AccountController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var vm = await BuildLoginViewModelAsync(returnUrl);
            if (vm.IsExternalLoginOnly)
            {
                return RedirectToAction("Challenge", "External", new { scheme = vm.ExternalLoginScheme, returnUrl });
            }


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            var vm = BuildLoginViewModelAsync(model.ReturnUrl);
            return View(vm);
        }


        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            LoginViewModel vm = new LoginViewModel();
            return vm;
        }
    }
}
