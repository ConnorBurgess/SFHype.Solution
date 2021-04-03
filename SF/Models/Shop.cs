using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SFHype.Models 
{
  public class Shop
  {

    public Shop()
    {
      this.Remarks = new HashSet<Remark>();
      this.Originated = DateTime.Now;
      this.HypeRatio = .001f;
    }
    [Key]
    public int ShopId { get; set; }
    public int RemarkId {get; set; }
    public string Name { get; set; }
    public string Describe {get; set; }
    public string Remark {get; set;}
    public string Type { get; set; }
    public string IpLog { get; set; }
    public int Likes {get; set; }
    public int Dislikes {get; set; }
    public float Hype {get;  set;}
    public float HypeRatio {get; set;}
    public DateTime Originated { get; set; }
    public DateTime DayChange {get; set; }
    public DateTime LastAccess { get; set; }
    public ICollection<Remark> Remarks { get; set; }

    // Set ID outside class for purposes of testing seed data if necessary
    public void SetId(int id) 
    {
        ShopId = id;
    }
  }
  
}