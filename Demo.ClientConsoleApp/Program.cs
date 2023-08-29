namespace Demo.ClientConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press Enter for request to Api...");
            Console.ReadLine();

            using (System.Net.Http.HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7077/api/Test");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine($"Response error code: {response.StatusCode}");
                }
            }

            Console.ReadLine();
            Console.WriteLine("Hello, World!");
        }
    }
}