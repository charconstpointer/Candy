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
        private readonly IHubContext<ChatHub> _context;

        public EventsController(IHubContext<ChatHub> context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task Notify([FromBody] string description)
        {
            await _context.Clients.All.SendAsync("receiveMessage", new Message {Body = description ,Name = "Server"});
            Ok("");
        }
    }
}