using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SFHype.Models
{
  public class ShopContext : DbContext
  {
    public ShopContext(DbContextOptions<ShopContext> options)
      : base(options)
    {
    } 

    public DbSet<Shop> Shops { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
{

  builder.Entity<Shop>()
      .HasData(
        
          new Shop {ShopId = -2, Name = "SF Shop 1", Describe = "A cool shop.", Type = "Restaurant"},
          new Shop {ShopId = -1, Name = "SF Shop 2", Describe = "Another cool shop.", Type = "Shop"}
      );
}
  }
}