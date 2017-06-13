using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fridge;

namespace FridgeUnitTest
{
    class MockFridgeRepository : IFridgeRepository
    {
        public List<InventoryItem> InventoryItems;

        public MockFridgeRepository()
        {
            InventoryItems = new List<InventoryItem>();
        }

        public List<InventoryItem> ListAllInventory()
        {
            return InventoryItems;
        }

        public void AddInventoryItem(InventoryItem item)
        {
            InventoryItems.Add(item);
        }

        public void UpdateInventoryItem(InventoryItem item)
        {
            foreach (var inventoryItem in InventoryItems)
            {
                if (inventoryItem.Name == item.Name) inventoryItem.Quantity = item.Quantity;
                return;
            }
        }

        public InventoryItem GetInventoryItem(string name)
        {
            return InventoryItems.FirstOrDefault(inventoryItem => inventoryItem.Name == name);
        }
    }
}
