using Microsoft.AspNetCore.Mvc;
using NisanAspNetMVCEgitimi.Models;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC08PartialController : Controller
    {
        private readonly UyeContext _context;

        public MVC08PartialController(UyeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Uyeler.FirstOrDefault()); // _context üzerindeki uyeler tablosunda bulduğun ilk kaydı ekrana yolla.
        }
    }
}
