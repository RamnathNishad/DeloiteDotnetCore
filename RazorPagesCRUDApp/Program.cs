using Microsoft.AspNetCore.Authentication.Cookies;

namespace RazorPagesCRUDApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.  

            builder.Services.AddRazorPages();

            //configure session service
            builder.Services.AddSession();

          
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthorization();

            app.MapRazorPages();

            //use the session service
            app.UseSession();

            app.Run();
        }
    }
}
