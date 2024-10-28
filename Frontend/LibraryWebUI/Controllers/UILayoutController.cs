using Microsoft.AspNetCore.Mvc;

namespace LibraryWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
