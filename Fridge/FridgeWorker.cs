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


        public FridgeInventoryItemContract GetInventoryItem(string ingredient)
        {
            ContractTranslator translator = new ContractTranslator();
            return translator.Translate(_fridgeRepo.GetInventoryItem(ingredient));
        }


        public void AddIngredientToFridge(InventoryItem item)
        {
            var existingInventoryItem = _fridgeRepo.GetInventoryItem(item.Name);

            if (existingInventoryItem == null)
            {
                _fridgeRepo.AddInventoryItem(item);   
                return;
            }

            existingInventoryItem.Quantity += item.Quantity;
            _fridgeRepo.UpdateInventoryItem(existingInventoryItem);

        }


        public double TakeItemFromFridge(FridgeInventoryItemContract item)
        {
            var existingInventoryItem = _fridgeRepo.GetInventoryItem(item.Name);

            if (existingInventoryItem == null)
            {
                return -1 * item.Quantity;
            }

            if (existingInventoryItem.Quantity < item.Quantity)
            {
                return existingInventoryItem.Quantity - item.Quantity;
            }

            existingInventoryItem.Quantity -= item.Quantity;
            _fridgeRepo.UpdateInventoryItem(existingInventoryItem);
            return existingInventoryItem.Quantity;
        }
    }


}
