using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.Services;
using Microsoft.Extensions.Caching.Memory;

namespace AuthServer;

public class CorsPolicyService : ICorsPolicyService
{
    private readonly ConfigurationDbContext _configurationDbContext;
    private readonly IMemoryCache _memoryCache;
    public CorsPolicyService(ConfigurationDbContext configurationDbContext, IMemoryCache memoryCache)
    {
        _configurationDbContext = configurationDbContext;
        _memoryCache = memoryCache;
    }
    public Task<bool> IsOriginAllowedAsync(string origin)
    {
        var AllowOrigins = _memoryCache.Get<string[]>("AllowOrigins");
        if (AllowOrigins is null)
        {
            AllowOrigins = _configurationDbContext.ClientCorsOrigins.Select(x => x.Origin).ToArray();
            _memoryCache.Set("AllowOrigins", AllowOrigins);
        }
        if (AllowOrigins.Contains(origin))
            return Task.FromResult(true);

        return Task.FromResult(false);
    }
}
