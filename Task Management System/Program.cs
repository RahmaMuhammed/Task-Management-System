using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task_Management_System.Models;
using Task_Management_System.Models.Entites;

namespace Task_Management_System
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configures the AppDbContext to use SQL Server with the connection string from the configuration file.
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

            //  builder.Services.AddScoped<UserManager<ApplicationUser>>();
            builder.Services.AddAuthentication();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>

            {
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireDigit = true;
                option.Password.RequireUppercase = true;
                option.Password.RequireLowercase = true;
            }).AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await Seeders.DataSeeder.SeedRolesAndAdminAsync(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
