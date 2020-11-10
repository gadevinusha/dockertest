using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularMongo.Models
{
    public class WorkorderViewModel
    {
        public string Workorder { get; set; }
        public string EquipmentCode { get; set; }
        public string SerialNo { get; set; }
        public string Status { get; set; }
        public string TestCode { get; set; }
        public int TestLevel { get; set; }
        public DateTime ActualEndDate { get; set; }
        public int AU { get; set; }
        public string AUDesc { get; set; }
        public string AssignedTo { get; set; }
    }
}
