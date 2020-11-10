using DataModels.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class WorkOrderAsset:BasicProperties
    {
        public int EquipmentId { set; get; }
        public string Equipment_Code { set; get; }
        public string Serial_No { set; get; }
        public string Part_No { set; get; }

    }
}
