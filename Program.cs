using PulcsiShop.DAL;
using Microsoft.EntityFrameworkCore;
using PulcsiShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace PulcsiShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("PulcsiShopConnection") ?? throw new InvalidOperationException("Connection string 'PulcsiShopConnection' not found.");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            /*builder.Services.AddDbContext<PulcsiShopDbContext>(opts => {
                opts.UseSqlServer("name=ConnectionStrings:PulcsiShopConnection");
            });*/
            builder.Services.AddDbContext<PulcsiShopDbContext>(opts =>
            {
                opts.UseSqlServer("name=ConnectionStrings:PulcsiShopConnection").
            ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
            });

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<PulcsiShopDbContext>();

            builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(30); });

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

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            /*app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");*/

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app);
            app.Run();
        }
    }
}
