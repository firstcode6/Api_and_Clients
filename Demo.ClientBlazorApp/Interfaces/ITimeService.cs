using Demo.DataLibrary.Models;

namespace Demo.ClientBlazorApp.Interfaces
{
    public interface ITimeService
    {
        Task<CurrentTime> GetCurrentTime();
        //Task<string> GetTime();
    }
}
