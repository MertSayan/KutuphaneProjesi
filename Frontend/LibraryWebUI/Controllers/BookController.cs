using Microsoft.AspNetCore.Mvc;

namespace LibraryWebUI.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Kitaplarımız";
            ViewBag.v2 = "En çok ödünç alınanlar";
            return View();
        }
    }
}
