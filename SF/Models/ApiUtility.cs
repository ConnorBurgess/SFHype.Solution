using System;
namespace SFHype.Models 
{
  public class ApiUtility
  {
    public static void ShopUtils(Shop shop, string ip) {
      LogShopId(shop, ip);
      AddHype(shop, ip);
    }
    public static void LogShopId(Shop shop, string ip) {
      
      shop.IpLog += ip + ',';
    }
    public static void AddHype(Shop shop, string ip) {
      shop.Hype += .003f;
      shop.LastAccess = DateTime.Now;
    }

  }

}