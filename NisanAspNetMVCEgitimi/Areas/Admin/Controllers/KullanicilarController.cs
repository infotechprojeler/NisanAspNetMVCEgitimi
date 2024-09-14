using Microsoft.AspNetCore.Mvc;
using NisanAspNetMVCEgitimi.Models;

namespace NisanAspNetMVCEgitimi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullanicilarController : Controller
    {
        private readonly UyeContext _context;

        public KullanicilarController(UyeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Uyeler.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Uye uye)
        {
            return View();
        }
    }
}
