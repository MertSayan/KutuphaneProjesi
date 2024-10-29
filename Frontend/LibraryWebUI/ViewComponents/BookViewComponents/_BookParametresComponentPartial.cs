using LibraryDtos.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryWebUI.ViewComponents.BookViewComponents
{
    public class _BookParametresComponentPartial:ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public _BookParametresComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Books/GetAllCategoryAuthorPublisher");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultBookCategoriesAuthorsAndPublishersDto>>(jsonData);
                return View(values);
            }
            return View();  
        }
    }
}
