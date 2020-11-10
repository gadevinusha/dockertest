using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace DataAccess
{
    public class MongoDBContext
    {
        public IMongoDatabase DBConnection { get; set; }

        public MongoDBContext(IConfiguration configuration)
        {

            string mongoDB = configuration["MongoDBOptions:MongoEquipmentDB"];
            string mongoDbConnection = configuration["MongoDBOptions:MongoDbConnection"];

            var mongoClient = new MongoClient(mongoDbConnection);
            DBConnection = mongoClient.GetDatabase(mongoDB);

        }
    }
}
