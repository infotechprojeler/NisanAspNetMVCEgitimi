using Microsoft.AspNetCore.Mvc;
using NisanAspNetMVCEgitimi.Models;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC17ViewComponentController : Controller
    {
        private readonly UyeContext _context;

        public MVC17ViewComponentController(UyeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
