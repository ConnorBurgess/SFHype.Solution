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
            this.Scale = .001f;
            this.IpLog = "";
            this.Type = "Shop";
            this.Describe = "This shop does not have a description.";
            this.DecrementScale = .000001f;
        }
        [Key]
        public int ShopId { get; private set; }
        public int RemarkId { get; private set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public string Remark { get; private set; }
        public string Type { get; private set; }
        public string IpLog { get; private set; }
        public int Likes { get; private set; }
        public int Dislikes { get; private set; }
        public float Hype { get; private set; }
        public float Scale { get; private set; }
        public float DecrementScale { get; private set; }

        public DateTime Originated { get; private set; }
        public DateTime DayChange { get; private set; }
        public DateTime LastAccess { get; private set; }
        public ICollection<Remark> Remarks { get; private set; }

        // Set ID outside class for purposes of testing seed data
        public void SetId(int id)
        {
            ShopId = id;
        }
        public void SetScale(float scaleVal)
        {
            this.Scale = scaleVal;
        }
        public void SetOriginated(DateTime today)
        {
            this.Originated = today;
        }
        public void AddHype(float hypeVal)
        {
            this.Hype += hypeVal;
        }
        public void ResetIpLog() {
          this.IpLog = "";
        }
        public void AddIp(string ip, DateTime today) {
          this.IpLog += ip + ',' + DateTime.Now + ",";
        }
        //Used in ApiUtility to track if day has changed in order to reset daily hype scale / daily IP log
        public void SetDayChange(DateTime today)
        {
            this.DayChange = today;
        }
        //Used in ApiUtility to set last access time for instance of Shop
        public void SetLastAccess(DateTime today)
        {
            this.LastAccess = today;
        }

    }

}