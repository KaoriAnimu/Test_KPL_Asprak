using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Test_Asprak_KPL.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class Controller : ControllerBase
    {
        private static List<Item> items = new List<Item>()
        {
            new Item { Id = 1, Name = "Item 1"}
    };

        public ActionResult<List<Item>> Get()
        {
            return items;
        }

        public ActionResult<Item>  Get(int id)
        {
            var item = items.Find(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        public ActionResult Post([FromBody] Item item)
        {
            items.Add(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

    }
}