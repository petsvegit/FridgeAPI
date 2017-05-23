using System;
using System.Collections.Generic;
using System.Text;

namespace Fridge
{
    public interface IFridgeRepository
    {

         List<InventoryItem> ListAllInventory();
         void AddInventoryItem(InventoryItem item);
         void UpdateInventoryItem(InventoryItem item);
         InventoryItem GetInventoryItem(string name);

    }
}
