using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web_api
{
    public class PlayersProcessor
    {
        private IRepository _repository;

        public PlayersProcessor(IRepository repository)
        {
            _repository = repository;
        }

        public Task<Player> Get(Guid id)
        {
            return _repository.GetPlayer(id);
        }

        public Task<Player[]> GetAll()
        {
            return _repository.GetAllPlayer();
        }

        public Task<Player> Create(NewPlayer player)
        {
            Player newPlayer = new Player();
            newPlayer.Name = player.Name;
            // set other values for new player
            newPlayer.Id = Guid.NewGuid();
            newPlayer.CreationTime = System.DateTime.Now;

            return _repository.CreatePlayer(newPlayer);
        }

        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            return _repository.ModifyPlayer(id, player);
        }

        public Task<Player> Delete(Guid id)
        {
            return _repository.DeletePlayer(id);
        }

        public Task<Player[]> MoreThanXScore(int x)
        {
            return _repository.MoreThanXScore(x);
        }

        public Task<Player> GetPlayerWithName(string name)
        {
            return _repository.GetPlayerWithName(name);
        }
        public Task<Player[]> GetPlayersWithItem(Item.ItemType itemType)
        {
            return _repository.GetPlayersWithItem(itemType);
        }

        public Task<int> GetLevelsWithMostPlayers()
        {
            return _repository.GetLevelsWithMostPlayers();
        }
    }
}