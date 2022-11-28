using API.Painting.Domain.Models;
using API.Training.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Provider> Providers { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Author's Table
        builder.Entity<Author>().ToTable("Authors");
        builder.Entity<Author>().HasKey(p => p.Id);
        builder.Entity<Author>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Author>().Property(p => p.FirstName).IsRequired();
        builder.Entity<Author>().Property(p => p.LastName).IsRequired();
        builder.Entity<Author>().HasKey(p => new {p.FirstName, p.LastName});
        builder.Entity<Author>().Property(p => p.NickName).IsRequired();
        
        
        // Provider's Table
        builder.Entity<Provider>().ToTable("Providers");
        builder.Entity<Provider>().HasKey(p => p.Id);
        builder.Entity<Provider>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Provider>().Property(p => p.Name).IsRequired();
        builder.Entity<Provider>().Property(p => p.KeyRequired).HasDefaultValue(false);
    }
}