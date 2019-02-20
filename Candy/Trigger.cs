using Candy.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Candy
{
    public class Trigger
    {
        private readonly IHubContext<ChatHub> _context;

        public Trigger(IHubContext<ChatHub> context)
        {
            _context = context;
        }

        public  void Event()
        {
            _context.Clients.All.SendAsync("sendmessage", "ait");
        }
    }
}