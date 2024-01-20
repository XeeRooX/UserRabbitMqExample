using Microsoft.AspNetCore.Mvc;
using UserRabbitMqExample.Producer.Dtos;
using UserRabbitMqExample.Producer.RabbitMQ;
using UserRabbitMqExample.Producer.Services;

namespace UserRabbitMqExample.Producer.Controllers
{
    public class UserController : ApiBaseController
    {
        private readonly IUserCommandsService _userCommands;
        private readonly IUserQueriesService _userQueries;
        private readonly IMessageProducer _messageProducer;
        public UserController(IUserQueriesService userQueries, IUserCommandsService userCommandsService, 
            IMessageProducer messageProducer)
        {
            _userQueries = userQueries;
            _userCommands = userCommandsService;
            _messageProducer = messageProducer;
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(GetUserInDto user) 
        {
            var result = await _userQueries.Get(user);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> add(AddUserDto user)
        {
            var result = await _userCommands.Add(user);
            _messageProducer.SendMessabe(result, "User created");
            return Ok(result);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit(EditUserDto user)
        {
            var result = await _userCommands.Update(user);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(GetUserInDto user)
        {
            var result = await _userCommands.Delete(user);
            _messageProducer.SendMessabe(result, "User deleted");
            return Ok(result);
        }
    }
}
