using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Entities;

public class WebAPIDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Country> Countries { get; set; }

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