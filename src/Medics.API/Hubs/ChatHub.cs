using Medics.Application.Service;
using Microsoft.AspNetCore.SignalR;

namespace Medics.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(Guid userId, Guid doctorId, string message)
        {
            var chat = await _chatService.SendMessageAsync(userId, doctorId, message);
            await Clients.All.SendAsync("ReceiveMessage", chat);
        }
    }
}
