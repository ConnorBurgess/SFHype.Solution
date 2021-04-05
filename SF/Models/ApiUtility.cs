using System;
using System.Linq;
namespace SFHype.Models
{

    public class ApiUtility : Shop
    {
        public static void ShopUtils(Shop shop, string ip)
        {
            ApiUtility.AddHype(shop, ip);
            ApiUtility.LogShopId(shop, ip);
        }
        public static void LogShopId(Shop shop, string ip)
        {
            //Store to perpetual log
            // shop.IpAccessLog.Add(ip, DateTime.Now);
            // var lines = shop.IpAccessLog.Select(kvp => kvp.Key + ": " + kvp.Value.ToString());
            // Console.WriteLine(string.Join(Environment.NewLine, lines));

            //Store to temporary daily log
            shop.IpLog += ip + ',' + DateTime.Now + ",";
            Console.WriteLine(shop.IpLog);
        }
        public static void AddHype(Shop shop, string ip)
        {
            //Loop over shop.IpLog and check if there is a match for client IP
            string checkIp = "";
            for (int i = 0; i < shop.IpLog.Length; i++)
            {
                if (checkIp == ip)
                {
                    System.Console.WriteLine("match found");
                    return;
                }
                if (shop.IpLog[i] == ',')
                {
                    checkIp = "";
                    //Skip DateTime entry
                    i += 20;
                }
                checkIp += shop.IpLog[i];
            }
            // Console.WriteLine(DateTime.Now.DayOfYear);
            // Check if day has passed and reset IpLog
            if (shop.DayChange.DayOfYear < DateTime.Now.DayOfYear)
            {
                shop.IpLog = ip;
                shop.SetScale(.001f);
            }
            //If scale has not been modified today then note the day
            if (shop.Scale == .001f)
            {
                shop.DayChange = DateTime.Now;
            }
            //Allows hype to be incremented by 1000 GET requests before no longer having an affect
            if (shop.Scale <= 0)
            {
                shop.LastAccess = DateTime.Now;
            }
            shop.Hype += (shop.Scale - shop.DecrementScale);
            shop.LastAccess = DateTime.Now;
        }

    }

}