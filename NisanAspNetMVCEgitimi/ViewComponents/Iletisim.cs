using Microsoft.AspNetCore.Mvc;

namespace NisanAspNetMVCEgitimi.ViewComponents
{
    public class Iletisim : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
