using System.Collections.Generic;


namespace Fridge
{
    public class FridgeWorker
    {

        private readonly IFridgeRepository _fridgeRepo;

        public FridgeWorker()
        {
            _fridgeRepo = new FridgeRepository();
        }

        public FridgeWorker(IFridgeRepository mockFridgeRepository)
        {
            _fridgeRepo = mockFridgeRepository;
        }




        public bool IsItemAvailable(string ingredient, double quantity)
        {
            var inventoryItem = _fridgeRepo.GetInventoryItem(ingredient);
            if (inventoryItem == null) {return false;}
            return (inventoryItem.Quantity >= quantity);
        }


        public FridgeInventory GetInventoryItem(string ingredient)
        {
          return _fridgeRepo.GetInventoryItem(ingredient);
        }


        public void AddIngredientToFridge(FridgeInventory item)
        {
            var existingInventoryItem = GetInventoryItem(item.Name);

            if (existingInventoryItem == null)
            {
                _fridgeRepo.AddInventoryItem(item);   
                return;
            }

            existingInventoryItem.Quantity += item.Quantity;
            _fridgeRepo.UpdateInventoryItem(existingInventoryItem);

        }


        public double TakeItemFromFridge(string inventoryName, double quantity)
        {
            var existingInventoryItem = GetInventoryItem(inventoryName);

            if (existingInventoryItem == null)
            {
                return -1 * quantity;
            }

            if (existingInventoryItem.Quantity < quantity)
            {
                return existingInventoryItem.Quantity - quantity;
            }

            existingInventoryItem.Quantity -= quantity;
            _fridgeRepo.UpdateInventoryItem(existingInventoryItem);
            return existingInventoryItem.Quantity;
        }
    }


}
