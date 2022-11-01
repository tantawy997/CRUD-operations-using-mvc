using LabFour.Data;
using Microsoft.EntityFrameworkCore;

namespace LabFour
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication("Cookie").AddCookie("Cookie",
                a =>
                {
                    a.LoginPath = "/account/login";
                    a.AccessDeniedPath = "/account/accessdenied";
                    a.LogoutPath = "/account/logout";

                }
                );
            builder.Services.AddDbContext<ITIDB>(
                a =>
                {
                    a.UseSqlServer(builder.Configuration.GetConnectionString("con1"));
                }
                );

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}