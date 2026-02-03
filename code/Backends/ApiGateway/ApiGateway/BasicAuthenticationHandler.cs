using ApiGateway.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using Z.EntityFramework.Plus;

namespace ApiGateway;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private IdentityContext _context;
    public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IdentityContext context) : base(options, logger, encoder, clock)
    {
        _context = context;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authorizationHeader = Request.Headers["Authorization"].ToString();
        if (authorizationHeader != null && authorizationHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
        {
            try
            {
                var token = authorizationHeader.Substring("Basic ".Length).Trim();
                var credentialsAsEncodedString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var credentials = credentialsAsEncodedString.Split(':');
                var clientId = credentials[0];
                var clientSecret = Sha256(credentials[1]);
                var authenticated = _context.clients.Include(x => x.ClientSecrets).FromCache().Any(x => x.ClientId == clientId && x.ClientSecrets.Any(y => y.Value == clientSecret));
                if (authenticated)
                {
                    var claims = new[] { new Claim("name", credentials[0]), new Claim(ClaimTypes.Role, "Intergration") };
                    var identity = new ClaimsIdentity(claims, "Basic");
                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
                }
            }
            catch (Exception ex) { }
        }
        Response.StatusCode = 401;
        Response.Headers.Add("WWW-Authenticate", "Basic realm=\"joydipkanjilal.com\"");
        return AuthenticateResult.Fail("Invalid Authorization Header");
    }

    public string Sha256(string input)
    {
        if (String.IsNullOrEmpty(input)) return string.Empty;

        using (var sha = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }
    }

}
