using AnimalShelter.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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

               
                     // Changing the default settings only for development mode... Do not do it for production mode
        builder.Services.Configure<IdentityOptions>(options =>
        {
          options.Password.RequireDigit = false;
          options.Password.RequireLowercase = false;
          options.Password.RequireNonAlphanumeric = false;
          options.Password.RequireUppercase = false;
          options.Password.RequiredLength = 0;
          options.Password.RequiredUniqueChars = 0;
        });

          /* /*
            The configuration above allows us to input a password of a single character to create a new user. Even though the RequiredLength property is 0, we can't actually put in an empty password because we have a validation attribute in place that states that some input for the RegisterViewModel.Password property is required.
            Keep in mind that the above settings should never be used in a production environment — only during development to make our lives a bit easier.
            Finally, note that when we change our password requirements in Program.cs, we need to make a corresponding update to our [RegularExpression] validation attribute for the RegisterViewModel.Password property.
          */


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