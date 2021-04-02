using Microsoft.EntityFrameworkCore;
using System;
namespace SFHype.Models
{
  public class ShopContext : DbContext
  {
    public MessageContext(DbContextOptions<MessageContext> options)
      : base(options)
    {
    }

    public DbSet<Shop> Shops { get; set; }
  }
}