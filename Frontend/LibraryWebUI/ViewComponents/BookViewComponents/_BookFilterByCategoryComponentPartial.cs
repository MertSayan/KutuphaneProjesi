using LibraryDtos.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryWebUI.ViewComponents.BookViewComponents
{
    public class _BookFilterByCategoryComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BookFilterByCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync(string categoryName)
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7227/api/Books/GetAllBookSameCategorName?categoryName="+categoryName);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAllBooksDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
