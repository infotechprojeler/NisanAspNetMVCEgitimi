using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // ToListAsync metodu için
using NisanAspNetMVCEgitimi.Models; // classı ViewComponent haline getirmek için

namespace NisanAspNetMVCEgitimi.ViewComponents
{
    public class Uyeler : ViewComponent // Uyeler sınıfına ViewComponent sınıfından kalıtım alıyoruz.
    {
        private readonly UyeContext _context; // _context e sağ klik ampul üzerinden açılan menüden generate constructor a basıyoruz.
        
        public Uyeler(UyeContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Uyeler.ToListAsync());
        }
    }
}
