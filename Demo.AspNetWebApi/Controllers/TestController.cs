using Microsoft.AspNetCore.Mvc;
using Demo.DataLibrary.Models;

namespace Demo.AspNetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return $"Server time: {DateTime.UtcNow:f}";
        }

        //[HttpGet]
        //[Route("GetTime")]
        //public async Task<ActionResult<string>> GetTime()
        //{
        //    var time = $"Server time: {DateTime.UtcNow:f}";
        //    return Ok(time);
        //}

        [HttpGet]
        [Route("GetCurrentTime")]
        public async Task<ActionResult<CurrentTime>> GetCurrentTime()
        {
            CurrentTime time = new CurrentTime();
            time.Time = $"Server time: {DateTime.UtcNow:f}";
            return Ok(time);
        }
    }
}
