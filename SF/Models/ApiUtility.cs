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
            //Future implementation to include perpetual IP log in addition to current daily log
            shop.AddIp(ip, DateTime.Now);
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
                    return;
                }
                if (shop.IpLog[i] == ',')
                {
                    checkIp = "";
                    //Increment i to skip DateTime entry
                    i += 20;
                }
                checkIp += shop.IpLog[i];
            }
            // Check if day has passed and reset IpLog
            if (shop.DayChange.DayOfYear < DateTime.Now.DayOfYear)
            {
                shop.ResetIpLog();
                shop.AddIp(ip, DateTime.Now);
                shop.SetScale(.001f);
            }
            // If scale has not been modified today then note the day
            if (shop.Scale == .001f)
            {
                shop.SetDayChange(DateTime.Now);
            }
            if (shop.Scale <= 0)
            {
                shop.SetLastAccess(DateTime.Now);
                return;
            }

            shop.AddHype(shop.Scale - shop.DecrementScale);
            shop.SetLastAccess(DateTime.Now);
        }

    }

}