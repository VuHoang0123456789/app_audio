using Admin.Application.TestTable.Dto;
using System.Security.Claims;

namespace AuthServer.IdentityServer
{
    public static class IdentityHelper
    {
        public const int TIME_EXPIRED = 30;
        public static List<Claim> ExtractClaimUser(TestTableDto nguoiDung)
        {
            var claims = new List<Claim>
                       {
                           new Claim("id", nguoiDung.id.ToString()),
                           new Claim("tai_khoan", nguoiDung.ten),
                           //new Claim("ten", nguoiDung.ten),
                           //new Claim("profiles", JsonSerializer.Serialize(nguoiDung),JsonClaimValueTypes.Json),
                       };
            return claims;
        }
    }
}


