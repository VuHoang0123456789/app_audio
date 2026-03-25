using System.ComponentModel.DataAnnotations;

namespace AuthServer.IdentityServer.Account
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get; set; } //Tên tài khoản

        [Required(ErrorMessage = "Mât khẩu không được để trống")]
        public string Password { get; set; } //Mật khẩu   

        public bool RememberLogin { get; set; } //nhớ đăng nhập (cookie persistent)
        public string ReturnUrl { get; set; } //redirect về authorize flow
    }
}
