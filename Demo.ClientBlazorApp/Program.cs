using Demo.ClientBlazorApp.Data;
using Demo.ClientBlazorApp.Interfaces;
using Demo.ClientBlazorApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Demo.ClientBlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddSingleton<TimeService>();
            builder.Services.AddHttpClient<ITimeService, TimeService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7077/");
            });

            builder.Services.AddSingleton<FilmService>();
            builder.Services.AddHttpClient<IFilmService, FilmService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7077/");
            });

           

            //builder.Services.AddSingleton<HttpClient>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.Run();
        }
    }
}