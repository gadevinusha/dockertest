using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularMongo.Models
{
    public class DashboardViewModel
    {
        public string name { get; set; }
        public string url { set; get; }
        public string css { get; set; }
        public string desc { set; get; }
    }
    //public class DashboardViewModel
    //{
    //    public DashboardViewModel()
    //    {
    //        //items = new List<DashboardItem>();
    //    }
    //    public List<DashboardItem> items { get; set; }
    //}

    //public class DashboardItem
    //{
    //    public string name { get; set; }
    //    public string Url { set; get; }
    //    public string css { get; set; }
    //    public string desc { set; get; }
    //}
}
