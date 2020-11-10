using DataModels;
using DataModels.ViewModel;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class WorkOrderOperations : IWorkOrderOperations
    {
        private IMongoDatabase _mongoDB;
        private readonly IWorkOrderOperations _context;
        private readonly string collectionName="RITEWorkOrderCollection";
        public IMongoCollection<WorkOrderCollection> WorkOrderCollection => _mongoDB.GetCollection<WorkOrderCollection>("RITEWorkOrderCollection");

        public IMongoCollection<BsonDocument> WorkOrder => _mongoDB.GetCollection<BsonDocument>("RITEWorkOrderCollection");

        public WorkOrderOperations(IConfiguration configuration)
        {
            _mongoDB = new MongoDBContext(configuration).DBConnection;
            _context = this;
            var filter = new BsonDocument("name", collectionName);
            if(!_mongoDB.ListCollectionNames(new ListCollectionNamesOptions { Filter = filter }).Any())
            {
                _mongoDB.CreateCollection(collectionName);
            }

        }
        public IList<WorkOrderCollection> GetAllWorkOrderData()
        {
            try
            {
                var result = _context.WorkOrderCollection.Find(_ => true).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IList<WorkOrderCollection>> GetFilteredWorkOrderDataCollection(WorkOrderSearchCriteria equipment)
        {
            try
            {
                var query = _context.WorkOrderCollection.AsQueryable();
                var coll = query.Where(x => x.WORKORDER.WOSource == "RITE-UI").ToListAsync();
                List<WorkOrderCollection> collOutput = await coll;
                return collOutput;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public WorkOrderCollection GetWorkOrderById(int woId)
        {
            try
            {
                var query = _context.WorkOrderCollection.AsQueryable();
                var woColl = query.Where(x => x.WORKORDER.WorkOrderId == woId).FirstOrDefault();
                return woColl;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool InsertAndUpdateWorkOrder(WorkOrderCollection equipment)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertWorkOrderCollectionAsync()
        {
            try
            {
                var date = DateTime.UtcNow;
                var coll = _mongoDB.GetCollection<WorkOrderCollection>("RITEWorkOrderCollection");
                List<WorkOrderCollection> woCollection = new List<WorkOrderCollection>();
                WorkOrderCollection col1 = new WorkOrderCollection();
                WorkOrder wo = new WorkOrder()
                {
                    WorkOrderId = 9629787,
                    MaintenanceId = "MNT9629787",
                    WOType = "MNT",
                    Status = "PL",
                    TestCode = "SL",
                    TestLevel = 1,
                    AssignedTo = "vgade2",
                    WOSource = "RITE-UI",
                    CreationDate = date,
                    CreatedBy = "vgade2",
                    LastModifieBy = "vgade2",
                    LastModifiedDate = date,
                    WODate = date

                };
                WorkOrderAsset woa = new WorkOrderAsset()
                {
                    EquipmentId = 2547362,
                    Equipment_Code = "1-23ZA",
                    Serial_No = "RITECOLO",
                    Part_No = "1-23ZA",
                    CreationDate = date,
                    CreatedBy = "vgade2",
                    LastModifieBy = "vgade2",
                    LastModifiedDate = date
                };
                WorkOrderPart wop = new WorkOrderPart()
                {
                    PartId = 1,
                    Part_No = "1-23ZA",
                    Fr_No = "FR1234",
                    CreationDate = date,
                    CreatedBy = "vgade2",
                    LastModifieBy = "vgade2",
                    LastModifiedDate = date
                };
                Organization o = new Organization()
                {
                    AU = 715123,
                    AUDesc = "BRLC-WL10",
                    CreationDate = date,
                    CreatedBy = "vgade2",
                    LastModifieBy = "vgade2",
                    LastModifiedDate = date
                };
                col1.WORKORDER = wo;
                col1.EQUIPMENT = woa;
                col1.PART = wop;
                col1.ORGANIZATION_DETAILS = o;
                col1.DELETED = false;
                col1.PACKET_RECEIVED_DATE = DateTime.UtcNow;
                col1.TotalCount = 1;
                woCollection.Add(col1);
                await Task.Delay(100);
                WorkOrderCollection col2 = new WorkOrderCollection();
                WorkOrder wo1 = new WorkOrder()
                {
                    WorkOrderId = 9629788,
                    MaintenanceId = "MNT9629788",
                    WOType = "MNT",
                    Status = "PL",
                    TestCode = "SL",
                    TestLevel = 1,
                    AssignedTo = "ppanda2",
                    WOSource = "RITE-UI",
                    CreationDate = date,
                    CreatedBy = "ppanda2",
                    LastModifieBy = "ppanda2",
                    LastModifiedDate = date,
                    WODate = date

                };
                WorkOrderAsset woa1 = new WorkOrderAsset()
                {
                    EquipmentId = 2547340,
                    Equipment_Code = "USIS-B",
                    Serial_No = "23Jan2020",
                    Part_No = "100127894",
                    CreationDate = date,
                    CreatedBy = "ppanda2",
                    LastModifieBy = "ppanda2",
                    LastModifiedDate = date
                };
                WorkOrderPart wop1 = new WorkOrderPart()
                {
                    PartId = 2,
                    Part_No = "100127894",
                    Fr_No = "FR123456",
                    CreationDate = date,
                    CreatedBy = "ppanda2",
                    LastModifieBy = "ppanda2",
                    LastModifiedDate = date
                };
                Organization o1 = new Organization()
                {
                    AU = 713436,
                    AUDesc = "INRJ-WL10",
                    CreationDate = date,
                    CreatedBy = "ppanda2",
                    LastModifieBy = "ppanda2",
                    LastModifiedDate = date
                };
                col1.WORKORDER = wo;
                col1.EQUIPMENT = woa;
                col1.PART = wop;
                col1.ORGANIZATION_DETAILS = o;
                col1.DELETED = false;
                col1.PACKET_RECEIVED_DATE = DateTime.UtcNow;
                col1.TotalCount = 2;
                woCollection.Add(col2);
                coll.InsertMany(woCollection);
            }
            catch (Exception e)
            {

                return false;
            }
            return true;
        }
    }
}
