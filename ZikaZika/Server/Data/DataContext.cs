using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using ZikaZika.Shared;

namespace ZikaZika.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();    
    }

    public DbSet<Category> Categories { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DbSet<Product> Products { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<Stats> Stats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductVariant>()
            .HasKey(p => new { p.ProductId, p.EditionId });
    }
}