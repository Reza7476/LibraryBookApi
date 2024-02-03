
using BookLibrary.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary;

public class LibraryDbContext:DbContext
{



    public LibraryDbContext(DbContextOptions<LibraryDbContext> option) :base(option)
    {
        
    }
    public DbSet<Auther> Authers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(User).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
}
