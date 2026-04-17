using AuthServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthServer.IdentityServer.Account
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var vm = new ErrorViewModel();
            vm.Error = new Duende.IdentityServer.Models.ErrorMessage
            {
                Error = "403",
                ErrorDescription = "Tài khoản của bạn không có quyền truy cập. Vui lòng liên hệ quản trị"
            };

            vm.urlReturn = "/login";

            return View(vm);
        }
    }
}
