using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Text;

using MongoDB.Driver.Linq;

namespace Fridge
{
   public class FridgeRepository:IFridgeRepository
                        
    {

        private IMongoDatabase GetMongoConnection()
        {
            string connectionString = "mongodb://172.30.81.97:49155";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));

            //1. Connect to MongoDB instance running on localhost
            var client = new MongoClient(settings);

            //Access database named 'FridgeDb'
            return client.GetDatabase("FridgeDb");
        }


        public void AddInventoryItem(InventoryItem item)
        {
            var collection = GetMongoConnection().GetCollection<InventoryItem>("Inventory");
            collection.InsertOne(item);
        }

        

        public void UpdateInventoryItem(InventoryItem item)
        {
            var collection = GetMongoConnection().GetCollection<InventoryItem>("Inventory");
            var builder = Builders<InventoryItem>.Filter;
            var filter = builder.Eq("_id", item.Id); 
            var result = collection.ReplaceOne(filter, item);
        }


        List<InventoryItem> IFridgeRepository.ListAllInventory()
        {
            //Access collection named 'Inventory'
            var collection = GetMongoConnection().GetCollection<InventoryItem>("Inventory");

            return (from invItem in collection.AsQueryable<InventoryItem>()
                    select invItem).ToList();
        }


        public InventoryItem GetInventoryItem(string name)
        {
            var collection = GetMongoConnection().GetCollection<InventoryItem>("Inventory");

            return (from invItem in collection.AsQueryable<InventoryItem>()
                    where invItem.Name == name
                    select invItem).FirstOrDefault();
           
        }
        
    }
}
