using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fridge;

namespace FridgeAPI.Controllers
{
    [Route("api/[controller]")]
    public class FridgeController : Controller
    {
        private FridgeWorker _fridgeWorker;

        public FridgeController()
        {
            _fridgeWorker = new FridgeWorker();
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public InventoryItem Get(string name)
        {
            return _fridgeWorker.GetInventoryItem(name);
        }

        // GET api/values/5
        [HttpGet("{name}/{quantity}")]
        public bool Get(string name, double quantity)
        {
            return _fridgeWorker.IsItemAvailable(name, quantity);
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]InventoryItem item)
        {
            _fridgeWorker.AddIngredientToFridge(item);
        }

        // PUT api/values/5
        [HttpPut("{name}")]
        public void Put(string name, [FromBody]InventoryItem item)
        {
            _fridgeWorker.AddIngredientToFridge(item);
        }

        // DELETE api/values/5
        [HttpDelete("{name}")]
        public void Delete(string name, [FromBody] InventoryItem item)
        {
            _fridgeWorker.TakeItemFromFridge(item.Name, item.Quantity);
        }
    }
}
