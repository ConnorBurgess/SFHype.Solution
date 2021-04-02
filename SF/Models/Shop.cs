using System;
using System.ComponentModel.DataAnnotations;
namespace SFHype.Models
{
  public class Shop
  {
    [Key]
    public int ShopId { get;  set; }
    public string Name { get; set; }
    public string Describe {get; set; }
    public string Type { get; set; }
    public int Likes {get; set; }
    public int Dislikes {get; set; }
    public float Hype {get;  set;}
    public DateTime Originated { get; set; }

  }
}