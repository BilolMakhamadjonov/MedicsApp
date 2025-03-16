using Medics.Core.Entities;
using Medics.DataAccess.Repositories;
using Medics.DataAccess.Repositories.Impl;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.Application.Service.Impl
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
        public async Task<Chat> SendMessageAsync(Guid userId, Guid doctorID, string messdage)
        {
            var chat = new Chat
            {
                UserId= userId,
                DoctorId= doctorID,
                Message= messdage,
                IsReaded= false,
                CreatedAt= DateTime.UtcNow
            };
            return await _chatRepository.AddAsync(chat);
        }
        public async Task<List<Chat>>GetChatHistoryAsync(Guid userId,Guid doctorId)
        {
            return await _chatRepository.GetAllAsync(x=>
            (x.UserId==userId && x.DoctorId==doctorId) || (x.UserId==userId && x.DoctorId==doctorId));
        }
        public async Task ReadAsync(Guid chatId)
        {
            var chat=await _chatRepository.GetByIdAsync(chatId);
            if(chat!=null)
            {
                chat.IsReaded=true;
                await _chatRepository.UpdateAsync(chat);
            }
        }
    }
}
