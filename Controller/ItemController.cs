using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly ItemService _itemService;

        public ItemController(ILogger<ItemController> logger, ItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpPost(Name = "CreateItem")]
        public IActionResult Create([FromBody] Item item)
        {
            _itemService.Add(item);

            return CreatedAtAction(nameof(Create), new { id = item.IDItem }, item);
        }
    }
}
