using System;
using System.Linq;
namespace SFHype.Models 
{
  public class ApiUtility
  {
    public static void ShopUtils(Shop shop, string ip) {
      ApiUtility.LogShopId(shop, ip);
      ApiUtility.AddHype(shop, ip);
    }
    public static void LogShopId(Shop shop, string ip) {
      //Store to perpetual log
      // shop.IpAccessLog.Add(ip, DateTime.Now);
      // var lines = shop.IpAccessLog.Select(kvp => kvp.Key + ": " + kvp.Value.ToString());
      // Console.WriteLine(string.Join(Environment.NewLine, lines));

      //Store to temporary daily log
      shop.IpLog += ip + ',' + DateTime.Now + ",";
      Console.WriteLine(shop.IpLog);
    }
    public static void AddHype(Shop shop, string ip) {
      //Loop over shop.IpLog and check if there is a match for client IP
      string checkIp = "";
      for (int i = 0; i < shop.IpLog.Length; i++) {
        if (checkIp == ip) {
          System.Console.WriteLine("match found");
          return;
        }
        if(shop.IpLog[i] == ',') {
          checkIp = "";
          //Skip DateTime entry
          i += 20;
        }
        checkIp += shop.IpLog[i];
      }
      // Console.WriteLine(DateTime.Now.DayOfYear);
      // Check if day has passed
      if(shop.DayChange.DayOfYear < DateTime.Now.DayOfYear) {
        shop.HypeRatio = .001f;
      }
      //If HR has not been modified today then note the day
      if (shop.HypeRatio == .001f) {
         shop.DayChange = DateTime.Now;
      }
      //Allows hype to be incremented by 1000 GET requests before no longer having an affect
      if (shop.HypeRatio <=0) {
        shop.LastAccess = DateTime.Now;
      }
      shop.Hype +=(shop.HypeRatio-.000001f);
      shop.LastAccess = DateTime.Now;
    }

  }

}