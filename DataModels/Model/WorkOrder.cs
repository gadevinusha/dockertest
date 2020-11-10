using DataModels.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace DataModels
{
    public class WorkOrder:BasicProperties
    {
        public int WorkOrderId { get; set; }
        public string MaintenanceId { set; get; }
        public string WOType { set; get; }
        public string TestCode { set; get; }
        public int TestLevel { set; get; }
        public string Status { set; get; }
        public string AssignedTo { set; get; }
        public string WOSource { set; get; }
        //public DateTime CreatedFrom { get; set; }
        //public DateTime CreatedTo { get; set; }
        //public DateTime ActualCompletionDateFrom { set; get; }
        public DateTime WODate { set; get; }

    }
}
