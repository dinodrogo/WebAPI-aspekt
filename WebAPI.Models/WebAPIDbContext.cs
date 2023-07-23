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

        modelBuilder.Entity<Country>().HasData(
            new Country { CountryId = 1, CountryName = "Macedonia" },
            new Country { CountryId = 2, CountryName = "Serbia" },
            new Country { CountryId = 3, CountryName = "Brazil" },
            new Country { CountryId = 4, CountryName = "France" },
            new Country { CountryId = 5, CountryName = "Germany" }
            );

        modelBuilder.Entity<Company>().HasData(
            new Company { CompanyId= 1, CompanyName = "Aspekt" },
            new Company { CompanyId= 2, CompanyName = "Makpetrol" },
            new Company { CompanyId= 3, CompanyName = "Mcdonald's" },
            new Company { CompanyId= 4, CompanyName = "Microsoft" },
            new Company { CompanyId= 5, CompanyName = "Spotify" }
            );

        modelBuilder.Entity<Contact>().HasData(
            new Contact { ContactId = 1, ContactName = "Quincy Bell", CompanyId = 1, CountryId = 1},
            new Contact { ContactId = 2, ContactName = "Kendra Cartwright", CompanyId = 2, CountryId = 3},
            new Contact { ContactId = 3, ContactName = "Random Name", CompanyId = 2, CountryId = 2},
            new Contact { ContactId = 4, ContactName = "Andrew Smith", CompanyId = 4, CountryId = 3},
            new Contact { ContactId = 5, ContactName = "Darell Overton", CompanyId = 5, CountryId = 3}
            );


    }
}