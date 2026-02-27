using Duende.IdentityServer.Validation;
using MediatR;

namespace AuthServer.IdentityServer.CussomIdentityServer
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private ISender Mediator;
        public CustomResourceOwnerPasswordValidator(ISender mediator)
        {
            Mediator = mediator;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //Code xác thực tài khoản
        }
    }
}
