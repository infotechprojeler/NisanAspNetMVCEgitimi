﻿using Microsoft.AspNetCore.Mvc;

namespace NisanAspNetMVCEgitimi.Areas.Admin.Controllers
{
    [Area("Admin")] // aşağıdaki controller admin altında çalışsın
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
