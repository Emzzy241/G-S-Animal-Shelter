using AnimalShelter.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models;

public class AnimalShelterContext  : IdentityDbContext<ApplicationUser>
{
    public DbSet<Animal> AllAnimals { get; set; }

    public DbSet<AnimalDetail> AnimalDetails { get; set; }

    public AnimalShelterContext(DbContextOptions options) : base(options) { }
}