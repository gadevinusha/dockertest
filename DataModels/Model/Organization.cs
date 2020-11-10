using DataModels.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Organization:BasicProperties
    {
        public int AU { get; set; }
        public string AUDesc { get; set; }
        //public int PAU { get; set; }
        //public string PAUDesc { get; set; }
    }
}
