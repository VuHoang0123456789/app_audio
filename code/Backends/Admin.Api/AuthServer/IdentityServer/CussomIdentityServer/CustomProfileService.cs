using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using MediatR;

namespace AuthServer.IdentityServer.CussomIdentityServer
{
    public class CustomProfileService : IProfileService
    {
        private ISender Mediator;
        public CustomProfileService(ISender mediator)
        {
            Mediator = mediator;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //code xử lý lấy claim...
            context.IssuedClaims = context.Subject.Claims.ToList();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            //code xử lý lấy ng dùng
            context.IsActive = true;
        }
    }
}
