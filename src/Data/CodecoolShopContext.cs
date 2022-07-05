using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data;

public class CodecoolShopContext : DbContext
{

    public CodecoolShopContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<PaymentInfo> PaymentInfos { get; set; }
    public DbSet<OrderedProduct> OrderedProducts { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}