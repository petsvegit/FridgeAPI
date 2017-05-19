using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fridge
{
   public class FridgeRepository
    {
        
        public void ListAllInventory()
        {
 
            //Access collection named 'Inventory'
            var collection = GetMongoConnection().GetCollection<BsonDocument>("Inventory");

            var documents = collection.Find(new BsonDocument()).ToList();

        }

        public void AddInventoryItem()
        {

        }

        private IMongoDatabase GetMongoConnection()
        {
            string connectionString = "mongodb://localhost:49155";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
        
            //1. Connect to MongoDB instance running on localhost
            var client = new MongoClient(settings);

            //Access database named 'FridgeDb'
            return client.GetDatabase("FridgeDb");
        }

    }
}
