using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web_api
{
    [Route("api/players/{playerId:Guid}/[controller]")]
    public class ItemsController
    {
        ItemsProcessor _processor;

        public ItemsController(ItemsProcessor processor){
            _processor = processor;
        }

        [HttpPost]
        [LowLevelPlayerExceptionFilter]
        [ValidateModel]
        public Task<Item> CreateItem(Guid playerId, [FromBody] NewItem item)
        {
            return _processor.CreateItem(playerId, item);
        }

        [HttpGet]
        public Task<Item[]> GetAllItems(Guid playerId)
        {
            return _processor.GetAllItems(playerId);
        }

        [HttpGet("{itemId:Guid}")]
        public Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            return _processor.GetItem(playerId, itemId);
        }

        [HttpPut("{itemId:Guid}")]
        public Task<Item> ModifyItem(Guid playerId, Guid itemId, [FromBody] ModifiedItem item)
        {
            return _processor.ModifyItem(playerId, itemId, item);
        }

        [HttpDelete("{itemId:Guid}")]
        public Task<Item> DeleteItem(Guid playerId, Guid itemId)
        {
            return _processor.DeleteItem(playerId, itemId);
        }
    }
}