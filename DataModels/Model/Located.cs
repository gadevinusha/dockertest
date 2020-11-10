using DataModels.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Located:BasicProperties
    {
        public string Located_Site { get; set; }

        public string Located_Type { get; set; }

        public string Located_Sub_Type { get; set; }
    }
}
