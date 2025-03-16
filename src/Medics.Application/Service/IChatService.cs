using Medics.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.Application.Service
{
    public interface IChatService
    {
        Task<Chat> SendMessageAsync(Guid userId, Guid doctorId, string message);
        Task<List<Chat>> GetChatHistoryAsync(Guid userId, Guid doctorId);
        Task ReadAsync(Guid chatId);
    }
}
