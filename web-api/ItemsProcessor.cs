using System;
using System.Threading.Tasks;

namespace web_api
{
    public class ItemsProcessor
    {
        IRepository _repository;

        public ItemsProcessor(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Item> CreateItem(Guid playerId, NewItem item)
        {
            Item newItem = new Item();
            newItem.Modify(item);
            newItem.Id = Guid.NewGuid();
            newItem.CreationDate = System.DateTime.Now;

            Player player = await _repository.GetPlayer(playerId);
            
            if (newItem.Type == Item.ItemType.Sword && player.Level < 3)
            {
                throw new LowLevelPlayerException("Player too low level for sword!");
            }

            return await _repository.CreateItem(playerId, newItem);
        }

        public Task<Item[]> GetAllItems(Guid playerId)
        {
            return _repository.GetAllItems(playerId);
        }

        public Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            return _repository.GetItem(playerId, itemId);
        }

        public Task<Item> ModifyItem(Guid playerId, Guid itemId, ModifiedItem item)
        {
            return _repository.ModifyItem(playerId, itemId, item);
        }

        public Task<Item> DeleteItem(Guid playerId, Guid itemId)
        {
            return _repository.DeleteItem(playerId, itemId);
        }
    }
}
