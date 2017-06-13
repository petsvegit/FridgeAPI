using System;
using System.Collections.Generic;
using System.Text;

namespace Fridge
{
    public class ContractTranslator
    {
        public FridgeInventoryItemContract Translate(InventoryItem internalItem)
        {
            return internalItem == null ? null : new FridgeInventoryItemContract(internalItem.Name, internalItem.Quantity);
        }

        public InventoryItem Translate(FridgeInventoryItemContract externalItem)
        {
            return externalItem == null ? null : new InventoryItem(externalItem.Name, externalItem.Quantity);
        }

    }
}
