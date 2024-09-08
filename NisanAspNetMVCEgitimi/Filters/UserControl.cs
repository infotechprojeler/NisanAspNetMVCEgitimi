using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; // Filtre kullanabilmek için gerekli kütüphane

namespace NisanAspNetMVCEgitimi.Filters
{
    public class UserControl : ActionFilterAttribute
    {
        // override filtre için kullanılabilecek metotları görebilmemizi sağlayan anahtar kelime, ActionFilterAttribute sınıfından geliyor.
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // bu filtrenin kullanılacağı action çalıştırılmak istendiğinde bu metot çalışır.
            base.OnActionExecuted(context);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // bu filtrenin kullanılacağı action çalıştırıldığında bu metot çalışır.
            var UserGuidSession = context.HttpContext.Session.GetString("userguid"); // o anda çalışan uygulamadaki sessionda istediğimiz değeri yakalıyoruz
            var userGuidCookie = context.HttpContext.Request.Cookies["userguid"]; // UserGuid isimli cookie yi yakalıyoruz
            if (UserGuidSession == null) // session veye cookie boşsa
            {
                context.Result = new RedirectResult("/MVC12Session?msg=ErisimEngellendi");
            }
            base.OnActionExecuting(context);
        }
    }
}
