using LibraryDtos.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace LibraryWebUI.ViewComponents.BookBarrowViewComponents
{
    public class _BookBarrowComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpFactory;

        public _BookBarrowComponentPartial(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Books/GetBookWithBarrowCount");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultTopGiveBooks>>(jsonData);
                return View(values);
            }
            
            return View();
        }
    }
}
