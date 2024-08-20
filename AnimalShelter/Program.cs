using AnimalShelter.Models;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;


namespace AnimalShelter.Models;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();

        // Implementing the connectionstrings; making the ConnectionStrings a property in our code
        builder.Services.AddDbContext<AnimalShelterContext>(
            dbContextOptions => dbContextOptions
            .UseMySql(
                builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                )
            )
        );

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AnimalShelterContext>()
                .AddDefaultTokenProviders();


        WebApplication app = builder.Build();
        app.UseRouting();
        app.UseStaticFiles();
        app.UseHttpsRedirection();

        /*
            // TODO:
            app.UseAuthentication();
            app.UseAuthorization();
        */
        app.MapControllerRoute(
            name: "default",
            pattern: "{Controller=Home}/{action=Index}/{id?}"
        );
        app.Run();
    }    
}