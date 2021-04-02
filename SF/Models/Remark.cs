using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SFHype.Models 
{
  public class Remark
  {
    public Remark()
    {
      this.Originated = DateTime.Now;
    }
    [Key]
    public int RemarkId { get; set; }    
    public string RemarkContent { get; set; }
    public int ShopId {get; set;}
    public DateTime Originated { get; set; }


  }
  
}