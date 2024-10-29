using LibraryDtos.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryWebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            ViewBag.v1 = "Kitaplarımız";
            ViewBag.v2 = "Tüm kitaplar";
            return View();
        }

        public async Task<IActionResult> FilterByCategory(string categoryName)
        {
            ViewBag.v1 = "Kitaplarımız";
            ViewBag.v2 = $""+categoryName.ToUpper()+" Kategorisine Göre Sonuçlar";
            ViewBag.categoryName = categoryName;
            return View();
        }

        public async Task<IActionResult> FilterByAuthor(string authorName)
        {
            ViewBag.v1 = "Kitaplarımız";
            ViewBag.v2 = $"" + authorName.ToUpper() + " Yazarına Göre Sonuçlar";
            ViewBag.authorName = authorName;
            return View();
        }

        public async Task<IActionResult> FilterByPublisher(string publisherName)
        {
            ViewBag.v1 = "Kitaplarımız";
            ViewBag.v2 = $"" + publisherName.ToUpper() + " e Göre Sonuçlar";
            ViewBag.publisherName = publisherName;
            return View();
        }
    }
}
