using Microsoft.AspNetCore.Mvc;

namespace NisanAspNetMVCEgitimi.ViewComponents
{
    public class Urunler : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
