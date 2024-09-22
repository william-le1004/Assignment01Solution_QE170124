using Assignment01Solution_QE170124.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment01Solution_QE170124.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Define DbSets for each entity in the database
    public DbSet<Member> Members { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    // Optional: Fluent API configurations can be applied here
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define relationships, keys, etc.
        modelBuilder.Entity<Member>().HasData(
            new Member { MemberID = 1, Email = "admin@estore.com", Password = "admin@@", FullName = "Admin", Role = "Admin" },
            new Member { MemberID = 2, Email = "user@estore.com", Password = "user@@", FullName = "User", Role = "User" }
        );

        // You can add more configurations here if needed
    }
}