using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web_api
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlayersController 
    {
        private PlayersProcessor _processor;

        public PlayersController(PlayersProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet("{id:Guid}")]
        public Task<Player> Get(Guid id)
        {

            return _processor.Get(id);
        }
        [HttpGet]
        public Task<Player[]> GetAll()
        {
            return _processor.GetAll();
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
        [HttpDelete("{id:Guid}")]
        public Task<Player> Delete(Guid id)
        {
            return _processor.Delete(id);
        }
    }
}