using Microsoft.AspNetCore.Mvc;

namespace LibraryWebUI.ViewComponents.BookBarrowViewComponents
{
    public class _BookBarrowFormComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
