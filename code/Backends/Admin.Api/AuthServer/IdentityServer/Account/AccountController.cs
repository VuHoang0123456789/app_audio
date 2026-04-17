using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace AuthServer.IdentityServer.Account
{
    public class AccountController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        public AccountController(IIdentityServerInteractionService interaction, IAuthenticationSchemeProvider schemeProvider)
        {
            _interaction = interaction;
            _schemeProvider = schemeProvider;
        }

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
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);

            if (context.IdP != null && await _schemeProvider.GetSchemeAsync(context.IdP) != null)
            {
                var local = context.IdP == Duende.IdentityServer.IdentityServerConstants.LocalIdentityProvider;

                vm.ReturnUrl = returnUrl;
                vm.EnableLocalLogin = local;

                if (!local)
                {
                    vm.ExternalProviders = new[] { new ExternalProvider {AuthenticationScheme = context.IdP} };
                }
            }

            var scheme = await _schemeProvider.GetAllSchemesAsync();

            var provider = scheme.Where(d => d.DisplayName != null).Select(s => new ExternalProvider { DisplayName = s.DisplayName, AuthenticationScheme = s.Name }).ToList();

            vm.ExternalProviders = provider;
            return vm;
        }
    }
}
