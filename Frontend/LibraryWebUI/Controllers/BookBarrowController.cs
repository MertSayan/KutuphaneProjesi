using LibraryDtos.BookBarrowDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LibraryWebUI.Controllers
{
    public class BookBarrowController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookBarrowController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            ViewBag.v1 = "Kitaplar";
            ViewBag.v2 = "En poüler kitaplar";
            return View();
        }
        //[HttpGet]
        //public async Task<IActionResult> Barrow()
        //{
        //    return View();  
        //}
        //[HttpPost]
        //public async Task<IActionResult> Barrow(CreateBookBarrowDto createBookBarrowDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = client.GetAsync("https://localhost:7227/api/Users");
        //    if(responseMessage.)



        //    //var jsonData = JsonConvert.SerializeObject(createBookBarrowDto);
        //    //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    //var responseMessage = await client.PostAsync("https://localhost:7227/api/Barrows", stringContent);
        //    //if(responseMessage.IsSuccessStatusCode)
        //    //{
        //    //    return RedirectToAction("Index","Book");
        //    //}
        //    //return View();
        //}
    }
}
