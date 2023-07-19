using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using WebAPI.Models.Entities;

public class WebAPIDbContext : DbContext
{
    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<Contact> Contacts { get; set; }
    public virtual DbSet<Country> Countries { get; set; }

    public WebAPIDbContext(DbContextOptions<WebAPIDbContext> options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Set up the database connection to MSSQL LocalDB
        optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=WebAPIAspektDB;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure any entity relationships here if needed
        // In this case, we define the relationships between entities
        modelBuilder.Entity<Company>()
            .HasMany(e => e.Contact)
            .WithOne();
        modelBuilder.Entity<Country>()
            .HasMany(e => e.Contact)
            .WithOne();
    }
}