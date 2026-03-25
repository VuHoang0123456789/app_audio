namespace AuthServer.IdentityServer.Account
{
    public class LoginViewModel : LoginInputModel
    {
        public bool AllowRememberLogin { get; set; } = true; //có show checkbox không
        public bool EnableLocalLogin { get; set; } = true; //có show form user/pass không

        public IEnumerable<ExternalProvider> ExternalProviders { get; set; } //danh sách login ngoài
            = Enumerable.Empty<ExternalProvider>();

        public IEnumerable<ExternalProvider> VisibleExternalProviders =>
            ExternalProviders.Where(x => !string.IsNullOrWhiteSpace(x.DisplayName)); //filter để hiển thị

        public bool IsExternalLoginOnly =>
            EnableLocalLogin == false && ExternalProviders?.Count() == 1; //nếu true → auto redirect

        public string ExternalLoginScheme =>
            IsExternalLoginOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;  //provider dùng để redirect
    }
}
