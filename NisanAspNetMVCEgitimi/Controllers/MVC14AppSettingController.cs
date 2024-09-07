using Microsoft.AspNetCore.Mvc;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC14AppSettingController : Controller
    {
        private readonly IConfiguration _configuration; // appsettings.json dosyasına erişebilmek için gerekli nesne

        public MVC14AppSettingController(IConfiguration configuration)
        {
            _configuration = configuration; // yukardaki boş nesne burada dolduruluyor
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
