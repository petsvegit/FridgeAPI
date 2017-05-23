using System;
using System.Collections.Generic;
using System.Text;

namespace Fridge
{
    public class ContractTranslator
    {
        public FridgeInventoryItemContract Translate(InventoryItem internalItem)
        {
            return new FridgeInventoryItemContract(internalItem.Name, internalItem.Quantity);
        }

        public InventoryItem Translate(FridgeInventoryItemContract externalItem)
        {
            return new InventoryItem(externalItem.Name, externalItem.Quantity);
        }

    }
}
