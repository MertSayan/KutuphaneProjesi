using LibraryDtos.BookBarrowDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persistence.Context;
using System.Text;

namespace LibraryWebUI.Controllers
{
    public class BookBarrowController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly LibraryContext _context;

        public BookBarrowController(IHttpClientFactory httpClientFactory, LibraryContext context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.v1 = "Kitaplar";
            ViewBag.v2 = "En poüler kitaplar";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Barrow(int bookId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Books/" + bookId);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<CreateBookBarrowDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Barrow(CreateBookBarrowDto createBookBarrowDto)
        {
            var value = await _context.Users.Where(x => x.Email.Equals(createBookBarrowDto.UserMail) && x.Password.Equals(createBookBarrowDto.Password)).FirstAsync();
            if(value!=null)
            {   
                
                createBookBarrowDto.UserId=value.UserId;
                //createBookBarrowDto.BookId = bookId;
                var client= _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createBookBarrowDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7227/api/Barrows", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Book");
                }
                
            }
            return View();
        }
    }
}
