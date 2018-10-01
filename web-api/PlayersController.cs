using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web_api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController
    {
        PlayersProcessor _processor;

        public PlayersController(PlayersProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet("{id:Guid}")]
        public Task<Player> Get(Guid id)
        {
            return _processor.Get(id);
        }

        [HttpPost]
        public Task<Player> Create([FromBody] NewPlayer player)
        {
            return _processor.Create(player);
        }

        [HttpPut("{id:Guid}")]
        public Task<Player> Modify(Guid id, [FromBody] ModifiedPlayer player)
        {
            return _processor.Modify(id, player);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:Guid}")]
        [UserActionAuditActionFilter]
        public Task<Player> Delete(Guid id)
        {
            return _processor.Delete(id);
        }

        [HttpGet("{name}")]

        public Task<Player> GetPlayerWithName(string name)
        {
            return _processor.GetPlayerWithName(name);
        }

        [HttpGet]
        public Task<Player[]> GetSomething(int? minScore, Item.ItemType? itemType)
        {
            if (minScore != null)
            {
                return _processor.MoreThanXScore((int) minScore);
            }
            else if (itemType != null)
            {
                return _processor.GetPlayersWithItem((Item.ItemType) itemType);
            }
            return _processor.GetAll();
        }

        [HttpGet("LevelWithMostPlayers")]

        public Task<int> GetLevelsWithMostPlayers()
        {
            return _processor.GetLevelsWithMostPlayers();
        }

        // [Route("api/players")]
        // [HttpPost]
        // public Task<Player> Create(NewPlayer player)
        // {
        //     return _processor.Create(player);
        // }

        // [Route("api/players/{playerName}")]
        // [HttpPost]
        // public Task<Player> Create(string playerName)
        // {
        //     NewPlayer player = new NewPlayer(playerName);
        //     return _processor.Create(player);
        // }

        // [Route("api/players/diiba")]
        // [HttpPost]
        // public Task<Player> CreateDiiba()
        // {
        //     NewPlayer player = new NewPlayer("Diiba");
        //     return _processor.Create(player);
        // }

        // [Route("api/players")]
        // [HttpPut]
        // public Task<Player> Modify(Guid id, ModifiedPlayer player)
        // {
        //     return _processor.Modify(id, player);
        // }

    }
}