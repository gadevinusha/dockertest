using DataModels;
using DataModels.ViewModel;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IWorkOrderOperations
    {
        public IMongoCollection<WorkOrderCollection> WorkOrderCollection { get; }
        public IMongoCollection<BsonDocument> WorkOrder { get; }


        public IList<WorkOrderCollection> GetAllWorkOrderData();
        public Task<IList<WorkOrderCollection>> GetFilteredWorkOrderDataCollection(WorkOrderSearchCriteria equipment);//(WorkOrderSearchCriteria equipment);
        public bool InsertAndUpdateWorkOrder(WorkOrderCollection workorder);
        WorkOrderCollection GetWorkOrderById(int woId);
        public Task<bool> InsertWorkOrderCollectionAsync();

    }
}
