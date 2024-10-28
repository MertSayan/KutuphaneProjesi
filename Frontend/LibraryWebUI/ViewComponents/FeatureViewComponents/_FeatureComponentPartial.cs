﻿using LibraryDtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryWebUI.ViewComponents.FeatureViewComponents
{
    public class _FeatureComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Features");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            
            return View();
        }
    }
}
