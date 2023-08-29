using Demo.ClientBlazorApp.Interfaces;
using Demo.DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.ClientBlazorApp.Services
{
    public class TimeService : ITimeService
    {
        private readonly HttpClient _httpClient;

        public TimeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<string> GetTime()
        //{
        //    return await _httpClient.GetFromJsonAsync<string>("api/Test/GetTime");
        //    //string result;
        //    //try
        //    //{
        //    //    //result = await _httpClient.GetFromJsonAsync<JsonResult>("https://localhost:7206/Test");
        //    //    result = await _httpClient.GetFromJsonAsync<string>("api/Test");
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    result = ex.Message;
        //    //}

        //    //var result = await _httpClient.GetFromJsonAsync<string>("api/Test");
        //    //return result;
        //}
        public async Task<CurrentTime> GetCurrentTime()
        {
            return await _httpClient.GetFromJsonAsync<CurrentTime>("api/Test/GetCurrentTime");
        }



    }
}
