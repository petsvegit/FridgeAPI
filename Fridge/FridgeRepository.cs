using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fridge
{
   public class FridgeRepository:IFridgeRepository
                        
    {
      
        public void AddInventoryItem(FridgeInventory item)
        {
            var collection = GetMongoConnection().GetCollection<BsonDocument>("Inventory");
            var document = new BsonDocument() {
                { "name", item.Name },
                { "quantity", item.Quantity }
            };

            collection.InsertOne(document);
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

        public void UpdateInventoryItem(FridgeInventory item)
        {
            throw new NotImplementedException();
        }

        List<FridgeInventory> IFridgeRepository.ListAllInventory()
        {

            //Access collection named 'Inventory'
            var collection = GetMongoConnection().GetCollection<BsonDocument>("Inventory");

            var documents = collection.Find(new BsonDocument()).ToList();

            return null;
        }

        public FridgeInventory GetInventoryItem(string name)
        {
            var collection = GetMongoConnection().GetCollection<BsonDocument>("Inventory");
            var filter = Builders<BsonDocument>.Filter.Eq("name", name);
            var fridgeItems = collection.Find(filter).SingleAsync();

            return null;
   
            //return BsonSerializer.Deserialize<FridgeInventory>(fridgeItems);
   
        }
    }
}
