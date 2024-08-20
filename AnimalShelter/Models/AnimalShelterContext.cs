using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models;

public class AnimalShelterContext  : IdentityDbContext<ApplicationUser>
{
    public DbSet<Animals> Animals { get; set; }

    public DbSet<AnimalDetails> AnimalDetails { get; set; }

    public AnimalShelterContext(DbContextOptions options) : base(options) { }
}