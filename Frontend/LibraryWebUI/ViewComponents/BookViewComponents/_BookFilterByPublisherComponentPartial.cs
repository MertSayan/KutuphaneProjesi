using LibraryDtos.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryWebUI.ViewComponents.BookViewComponents
{
    public class _BookFilterByPublisherComponentPartial:ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public _BookFilterByPublisherComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string publisherName)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7227/api/Books/GetAllBookSamePublisherName?publisherName="+publisherName);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBooksDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
