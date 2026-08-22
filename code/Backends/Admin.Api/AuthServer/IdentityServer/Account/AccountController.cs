using Admin.Domain.Entities;
using Duende.IdentityServer;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SharedKernel.Application.Exceptions;

namespace AuthServer.IdentityServer.Account
{
    public class AccountController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IEventService _events;

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
        public async Task<IActionResult> Login(LoginInputModel model, string button)
        {
            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
            try
            {
                if (button != "login")
                {
                    if (context != null && model.ReturnUrl != "")
                    {
                        // if the user cancels, send a result back into IdentityServer as if they 
                        // denied the consent (even if this client does not require consent).
                        // this will send back an access denied OIDC error response to the client.
                        await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);

                        // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                        if (context.IsNativeClient())
                        {
                            // The client is native, so this change in how to
                            // return the response is for better UX for the end user.
                            return this.LoadingPage("Redirect", model.ReturnUrl);
                        }

                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        // since we don't have a valid context, then we just go back to the home page
                        return Redirect("~/");
                    }
                }

                if (ModelState.IsValid)
                {
                    var count_err = MemoryCacheHelper.GetValue(model.Username);

                    if (count_err != null && int.Parse(count_err.ToString()) >= 5)
                    {
                        ModelState.AddModelError("lock_account", AccountOptions.LockingAccountMessage);
                    }
                    else
                    {
                        //Kiểm tra thông tin đăng nhập
                        var user = "";

                        //var claims = IdentityHelper.ExtractClaimUser(user);
                        //// issue authentication cookie with subject ID and username
                        //var isuser = new IdentityServerUser(nguoiDung.id.ToString())
                        //{
                        //    DisplayName = nguoiDung.tai_khoan,
                        //    AdditionalClaims = claims,
                        //};

                        //await HttpContext.SignInAsync(isuser, props);

                        // Chuyển tiếp đến bước tiếp theo của flow oidc
                        if (context != null)
                        {
                            if (context.IsNativeClient())
                            {
                                // The client is native, so this change in how to
                                // return the response is for better UX for the end user.
                                return this.LoadingPage("Redirect", model.ReturnUrl);
                            }

                            // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                            return Redirect(model.ReturnUrl);
                        }

                        // request for a local page
                        if (Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        else if (string.IsNullOrEmpty(model.ReturnUrl) || model.ReturnUrl != "")
                        {
                            return Redirect("~/");
                        }
                        else
                        {
                            // user might have clicked on a malicious link - should be logged
                            throw new Exception("invalid return URL");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                await _events.RaiseAsync(new UserLoginFailureEvent(model.Username, "invalid credentials", clientId: context?.Client.ClientId));
                ModelState.AddModelError(err.errorCode.ToString(), err.description ?? "");
            }


            var vm = BuildLoginViewModelAsync(model.ReturnUrl);
            return View(vm);
        }


        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            LoginViewModel vm = new LoginViewModel();
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);

            if (context != null && context.IdP != null && await _schemeProvider.GetSchemeAsync(context.IdP) != null)
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
