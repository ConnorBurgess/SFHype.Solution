using System;

namespace SFHype.Models
{
  public class Shop
  {
    public int ShopID { get; private set; }
    public string Name { get; set; }
    public string Describe {get; set; }
    public int Hype {get; set;}
    public DateTime Posted { get; set; }

  }
}