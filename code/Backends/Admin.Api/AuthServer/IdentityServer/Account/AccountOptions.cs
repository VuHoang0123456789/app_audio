namespace AuthServer.IdentityServer.Account
{
    public class AccountOptions
    {
        public static bool AllowLocalLogin = true;
        public static bool AllowRememberLogin = true;
        public static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);

        public static bool ShowLogoutPrompt = false;
        public static bool AutomaticRedirectAfterSignOut = true;

        public static string InvalidCredentialsErrorMessage = "Invalid username or password";
        //public static string LockAccountMessage = string.Concat("Nhập sai mật khẩu quá 5 lần. Vui lòng đăng nhập lại sau ", AppConst.TIME_EXPIRED," phút!");
        public static string LockAccountMessage = string.Concat("Nhập sai mật khẩu quá 5 lần. Vui lòng đăng nhập lại sau ", 5, " phút!");
        public static string LockingAccountMessage = "Tài khoản đang bị tạm khóa. Vui lòng đăng nhập lại sau!";

    }
}
