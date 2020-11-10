using DataModels.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class WorkOrderPart:BasicProperties
    {
        public int PartId { get; set; }
        public string Part_No { get; set; }
        public string Fr_No { get; set; }
    }
}
