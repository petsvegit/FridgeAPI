using System;
using System.Collections.Generic;
using System.Text;

namespace Fridge
{
    public interface IFridgeRepository
    {

         List<FridgeInventory> ListAllInventory();
         void AddInventoryItem(FridgeInventory item);
         void UpdateInventoryItem(FridgeInventory item);
         FridgeInventory GetInventoryItem(string name);

    }
}
