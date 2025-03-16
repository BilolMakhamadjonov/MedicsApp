using Medics.Application.DtoModels.Chat;
using Medics.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medics.API.Controllers
{
    public class ChatController : ApiController
    {
       private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatRequestModel model)
        {
            var chat=await _chatService.SendMessageAsync(model.UserId, model.DoctorId,model.Message);
            return Ok(chat);
        }
        [HttpGet("history")]
        public async Task<IActionResult>GetHistory(Guid userId,Guid doctorId)
        {
            var history=await _chatService.GetChatHistoryAsync(userId, doctorId);
            return Ok(history);
        }
        [HttpPost("mark-read")]
        public async Task<IActionResult>Read(Guid chatId)
        {
            await _chatService.ReadAsync(chatId);
            return Ok(new {message="Chat marked as read"});
        }
    }
}
