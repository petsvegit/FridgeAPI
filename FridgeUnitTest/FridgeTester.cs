using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fridge;


namespace FridgeUnitTest
{
    [TestClass]
    public class FridgeTester
    {

        [TestClass]
        public class WithEmptyFridge
        {
            private string inventoryItemMeatballs = "Meatballs";

            [TestMethod]
            public void GetItem()
            {
                MockFridgeRepository mockRepo = new MockFridgeRepository();
                FridgeWorker fridgeWorker = new FridgeWorker(mockRepo);

                var result = fridgeWorker.GetInventoryItem("Hundgodis");
                Assert.AreEqual(null, result);
            }


            [TestMethod]
            public void AddOneInventoryItem()
            {
                MockFridgeRepository mockRepo = new MockFridgeRepository();
                FridgeWorker fridgeWorker = new FridgeWorker(mockRepo);

                fridgeWorker.AddIngredientToFridge(new InventoryItem(inventoryItemMeatballs, 10));
                Assert.AreEqual(1, mockRepo.InventoryItems.Count);
                Assert.AreEqual(inventoryItemMeatballs, mockRepo.InventoryItems[0].Name);
                Assert.AreEqual(10, mockRepo.InventoryItems[0].Quantity);
            }


            [TestMethod]
            public void AddTwoIdenticalInventoryItem()
            {
                MockFridgeRepository mockRepo = new MockFridgeRepository();
                FridgeWorker fridgeWorker = new FridgeWorker(mockRepo);

                fridgeWorker.AddIngredientToFridge(new InventoryItem(inventoryItemMeatballs, 10));
                fridgeWorker.AddIngredientToFridge(new InventoryItem(inventoryItemMeatballs, 10));

                Assert.AreEqual(1, mockRepo.InventoryItems.Count);
                Assert.AreEqual(20, mockRepo.InventoryItems[0].Quantity);
            }

            [TestMethod]
            public void IsItemAvailable()
            {
                MockFridgeRepository mockRepo = new MockFridgeRepository();
                FridgeWorker fridgeWorker = new FridgeWorker(mockRepo);
                Assert.AreEqual(false, fridgeWorker.IsItemAvailable(inventoryItemMeatballs, 7));
            }


            [TestMethod]
            public void RemoveInventoryItem()
            {
                MockFridgeRepository mockRepo = new MockFridgeRepository();
                FridgeWorker fridgeWorker = new FridgeWorker(mockRepo);
                Double result =
                    fridgeWorker.TakeItemFromFridge(new FridgeInventoryItemContract(inventoryItemMeatballs, 5));
                Assert.AreEqual(-5, result);
            }

        }

        [TestClass]
        public class WithNonEmtpyFridge
        {
            private string inventoryItemMeatballs = "Meatballs";

            [TestMethod]
            public void GetExistingInventoryItem()
            {
                MockFridgeRepository mockRepo = new MockFridgeRepository();
                FridgeWorker fridgeWorker = new FridgeWorker(mockRepo);

                fridgeWorker.AddIngredientToFridge(new InventoryItem(inventoryItemMeatballs, 10));

                FridgeInventoryItemContract result = fridgeWorker.GetInventoryItem(inventoryItemMeatballs);
                Assert.AreEqual(10, result.Quantity);
            }


            [TestMethod]
            public void IsExistingItemAvailable()
            {
                MockFridgeRepository mockRepo = new MockFridgeRepository();
                FridgeWorker fridgeWorker = new FridgeWorker(mockRepo);

                fridgeWorker.AddIngredientToFridge(new InventoryItem(inventoryItemMeatballs, 10));

                Assert.AreEqual(true, fridgeWorker.IsItemAvailable(inventoryItemMeatballs, 7));
            }

            [TestMethod]
            public void RemoveExistingInventoryItem()
            {
                string invItem1 = "Meatballs";
                string invItem2 = "Potato";
                string invItem3 = "Pasta";
                string invItem4 = "Sauce";

                MockFridgeRepository mockRepo = new MockFridgeRepository();
                FridgeWorker fridgeWorker = new FridgeWorker(mockRepo);

                fridgeWorker.AddIngredientToFridge(new InventoryItem(invItem1, 10));
                fridgeWorker.AddIngredientToFridge(new InventoryItem(invItem2, 50));
                fridgeWorker.AddIngredientToFridge(new InventoryItem(invItem3, 4));
                fridgeWorker.AddIngredientToFridge(new InventoryItem(invItem4, 10));

                Double result = fridgeWorker.TakeItemFromFridge(new FridgeInventoryItemContract(invItem1, 7));
                Assert.AreEqual(3, result);

                result = fridgeWorker.TakeItemFromFridge(new FridgeInventoryItemContract(invItem1, 7));
                Assert.AreEqual(-4, result);
            }

            [TestMethod]
            public void RemoveNonExistingInventoryItem()
            {
                string invItem1 = "Meatballs";
                string invItem2 = "Potato";
                string invItem3 = "Pasta";
                string invRemoveItem = "Sauce";

                MockFridgeRepository mockRepo = new MockFridgeRepository();
                FridgeWorker fridgeWorker = new FridgeWorker(mockRepo);

                fridgeWorker.AddIngredientToFridge(new InventoryItem(invItem1, 10));
                fridgeWorker.AddIngredientToFridge(new InventoryItem(invItem2, 50));
                fridgeWorker.AddIngredientToFridge(new InventoryItem(invItem3, 4));

                Double result = fridgeWorker.TakeItemFromFridge(new FridgeInventoryItemContract(invRemoveItem, 5));

                Assert.AreEqual(-5, result);
            }


            //[TestMethod]
            //public void ListInventoryItems()
            //{
            //    IFridgeRepository currentRepo = new FridgeRepository();

            //    currentRepo.AddInventoryItem(new InventoryItem("gurka", 10));
            //    //currentRepo.AddInventoryItem(new FridgeInventory("sallad", 10));

            //    var inventoryList = currentRepo.ListAllInventory();

            //    var inventory = currentRepo.GetInventoryItem("gurka");
            //    inventory.Quantity = 12;

            //    currentRepo.UpdateInventoryItem(inventory);

            //    inventory = currentRepo.GetInventoryItem("gurka");
            //    var stopHere = "breakPoint"
            //        ;
            //}

        }

    }
}
