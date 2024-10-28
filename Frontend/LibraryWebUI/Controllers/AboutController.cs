using Microsoft.AspNetCore.Mvc;

namespace LibraryWebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Hakkımızda";
            ViewBag.v2 = "Biz Kimiz?";
            return View();
        }
    }
}
