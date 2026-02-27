namespace AuthServer.IdentityServer.CussomIdentityServer
{
    public static class IdentityExtensions
    {
        public static IIdentityServerBuilder AddCustomUserStore(this IIdentityServerBuilder builder) {
            builder.AddProfileService<CustomProfileService>();
            builder.AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>();
            return builder;
        }
    }
}
