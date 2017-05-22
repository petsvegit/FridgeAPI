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
            string connectionString = "mongodb://localhost:49155";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));

            //1. Connect to MongoDB instance running on localhost
            var client = new MongoClient(settings);

            //Access database named 'FridgeDb'
            return client.GetDatabase("FridgeDb");
        }


        public void AddInventoryItem(FridgeInventory item)
        {
            var collection = GetMongoConnection().GetCollection<FridgeInventory>("Inventory");
            collection.InsertOne(item);
        }

        

        public void UpdateInventoryItem(FridgeInventory item)
        {
            var collection = GetMongoConnection().GetCollection<FridgeInventory>("Inventory");
            var builder = Builders<FridgeInventory>.Filter;
            var filter = builder.Eq("_id", item.Id); 
            var result = collection.ReplaceOne(filter, item);
        }


        List<FridgeInventory> IFridgeRepository.ListAllInventory()
        {
            //Access collection named 'Inventory'
            var collection = GetMongoConnection().GetCollection<FridgeInventory>("Inventory");

            return (from invItem in collection.AsQueryable<FridgeInventory>()
                    select invItem).ToList();
        }


        public FridgeInventory GetInventoryItem(string name)
        {
            var collection = GetMongoConnection().GetCollection<FridgeInventory>("Inventory");

            return (from invItem in collection.AsQueryable<FridgeInventory>()
                    where invItem.Name == name
                    select invItem).FirstOrDefault();
           
        }
        
    }
}
