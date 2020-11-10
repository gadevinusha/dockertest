using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DataModels
{
    [BsonIgnoreExtraElements]
    public class WorkOrderCollection
    {
        [BsonId()]
        [BsonElement("_Id")]
        public ObjectId _Id { get; set; }

        [BsonElement("WorkOrder")]
        public WorkOrder WORKORDER { get; set; }

        [BsonElement("EQUIPMENT")]
        public WorkOrderAsset EQUIPMENT { get; set; }

        [BsonElement("ORGANIZATION_DETAILS")]
        public Organization ORGANIZATION_DETAILS { get; set; }

        //[BsonElement("LOCATED")]
        //public Located LOCATED { get; set; }

        [BsonElement("WorkOrderPart")]
        public WorkOrderPart PART { get; set; }

        [BsonElement("PACKET_RECEIVED_DATE")]
        public DateTime? PACKET_RECEIVED_DATE { get; set; }

        [BsonElement("DELETED")]
        public bool DELETED { get; set; }

        //[BsonElement("FILECODE")]
        //public FileCode FILECODE { get; set; }

        public int TotalCount { get; set; }
    }
}
