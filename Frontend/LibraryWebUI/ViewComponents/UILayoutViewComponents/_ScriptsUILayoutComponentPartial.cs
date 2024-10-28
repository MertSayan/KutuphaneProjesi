using Microsoft.AspNetCore.Mvc;

namespace LibraryWebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptsUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
