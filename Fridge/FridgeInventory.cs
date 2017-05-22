using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Fridge
{
    public class FridgeInventory
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("quantity")]
        public double Quantity { get; set; }


        public FridgeInventory(string name, double quantity)
        {
            Name = name;
            Quantity = quantity;
        }

    }
}
