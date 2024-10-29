using Microsoft.AspNetCore.Mvc;

namespace LibraryWebUI.Controllers
{
    public class BookBarrowController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Kitaplar";
            ViewBag.v2 = "En poüler kitaplar";
            return View();
        }
    }
}
