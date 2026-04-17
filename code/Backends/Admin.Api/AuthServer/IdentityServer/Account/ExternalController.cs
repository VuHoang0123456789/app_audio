using Admin.Application.TestTable.Dto;
using AuthServer.Models;
using Duende.IdentityServer;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthServer.IdentityServer.Account;

public class ExternalController : Controller
{
    private readonly IIdentityServerInteractionService _interaction;
    private readonly ILogger<ExternalController> _logger;
    private readonly IEventService _events;
    public ExternalController(IIdentityServerInteractionService interaction, ILogger<ExternalController> logger, IEventService events) {
        _interaction = interaction;
        _logger = logger;
        _events = events;
    }

    public IActionResult Challenge(string scheme, string returnUrl)
    {
        //Không có returnUrl thì return về url root http://domain.com
        if (string.IsNullOrEmpty(returnUrl)) returnUrl = "~/";

        if(!Url.IsLocalUrl(returnUrl) && !_interaction.IsValidReturnUrl(returnUrl))
        {
            throw new Exception("invalid return url");
        }

        var props = new AuthenticationProperties
        {
            RedirectUri = Url.Action(nameof(Callback)),
            Items =
            {
                { "returnUrl", returnUrl },
                { "scheme", scheme },
            }
        };

        return Challenge(props, scheme);
    }

    public async Task<IActionResult> Callback()
    {
        var result = await HttpContext.AuthenticateAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);

        if (!result.Succeeded)
        {
            var vm = new ErrorViewModel();
            vm.Error = new Duende.IdentityServer.Models.ErrorMessage()
            {
                Error = "400",
                ErrorDescription = "Quá trình login bị gián đoạn. Vui lòng thử lại sau ít phút"
            };

            vm.urlReturn = "/login";
            return View(vm);
        }

        var returnUrl = result.Properties.Items.ContainsKey("returnUrl") ? result.Properties.Items["returnUrl"] : "~/";
        //log claims khi bật debug
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            var externalClaims = result.Principal.Claims.Select(s => $"{s.Type}: {s.Value}");
            _logger.LogDebug("External claims: {claims}", string.Join(", ", externalClaims));
        }

        var provider = result.Properties.Items.ContainsKey("scheme") ? result.Properties.Items["scheme"] : "external";
        var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
        var externalUser = result.Principal;

        if (externalUser == null)
        {
            throw new Exception("External user is null");
        }

        var claims = new List<Claim>();
        TestTableDto nguoiDung = null;

        #region Xử lý logic với bên t3 là các hệ thống ngoài như google, facebook....
        try
        {
            //Xử lý login
        }
        catch (Exception ex)
        {
            var vm = new ErrorViewModel();
            vm.Error = new Duende.IdentityServer.Models.ErrorMessage()
            {
                Error = "400",
                ErrorDescription = "Quá trình login bị gián đoạn. Vui lòng thử lại sau ít phút"
            };

            vm.urlReturn = "/login";
            return View(vm);
        }
        #endregion

        if (nguoiDung == null) {
            var vm = new ErrorViewModel();
            vm.Error = new Duende.IdentityServer.Models.ErrorMessage
            {
                Error = "403",
                ErrorDescription = "Tài khoản của bạn không có quyền truy cập. Vui lòng liên hệ quản trị"
            };

            vm.urlReturn = "/login";
            return View(vm);
        }

        var claimsLocal = IdentityHelper.ExtractClaimUser(nguoiDung);
        claims.AddRange(claimsLocal);

        var localSignInProps = new AuthenticationProperties();
        ProcessLoginCallback(result, claims, localSignInProps);

        // issue authentication cookie for user
        var isuser = new IdentityServerUser(nguoiDung.id.ToString())
        {
            DisplayName = nguoiDung.ten,
            IdentityProvider = provider,
            AdditionalClaims = claims,
        };
        //tạo cookie idsrv
        await HttpContext.SignInAsync(isuser, localSignInProps);

        //tạo event log để ghi log khi login thành công
        await _events.RaiseAsync(new UserLoginSuccessEvent(nguoiDung.ten, nguoiDung.id.ToString(), nguoiDung.ten, clientId: context?.Client.ClientId));

        if (context != null)
        {
            if (context.IsNativeClient())
            {
                // The client is native, so this change in how to
                // return the response is for better UX for the end user.
                return this.LoadingPage("Redirect", returnUrl);
            }
        }

        // delete temporary cookie used during external authentication
        await HttpContext.SignOutAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);

        return Redirect(returnUrl);
    }

    // if the external login is OIDC-based, there are certain things we need to preserve to make logout work
    // this will be different for WS-Fed, SAML2p or other protocols
    private void ProcessLoginCallback(AuthenticateResult externalResult, List<Claim> localClaims, AuthenticationProperties localSignInProps)
    {
        // if the external system sent a session id claim, copy it over
        // so we can use it for single sign-out
        var sid = externalResult.Principal?.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.SessionId);
        if (sid != null)
        {
            localClaims.Add(new Claim(JwtClaimTypes.SessionId, sid.Value));
        }

        // if the external provider issued an id_token, we'll keep it for signout
        var idToken = externalResult.Properties?.GetTokenValue("id_token");
        if (idToken != null)
        {
            localSignInProps.StoreTokens(new[] { new AuthenticationToken { Name = "id_token", Value = idToken } });
        }
    }
}
