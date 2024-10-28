using Microsoft.AspNetCore.Mvc;

namespace LibraryWebUI.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "İmkanlar";
            ViewBag.v2 = "İmkanlarımız";
            return View();
        }
    }
}
