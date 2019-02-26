using System.Threading.Tasks;
using Candy.Domain.Models;
using Candy.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Candy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public EventsController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task ww()
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage",
                new Message {Body = "Dsa", Name = "Server"});
        }

        [HttpPost]
        public async Task Notify([FromBody] string description)
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage",
                new Message {Body = description, Name = "Server"});
//            --urls=http://0.0.0.0:5001
        }
    }
}