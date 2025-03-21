using AutoMapper;
using Medics.Application.DtoModels.Chat;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl;

public class ChatService : IChatService
{
    private readonly IChatRepository _repository;
    private readonly IMapper _mapper;

    public ChatService(IChatRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ChatResponseDTO>> GetAllChatsAsync()
    {
        var chats = await _repository.GetAllAsync();
        return _mapper.Map<List<ChatResponseDTO>>(chats);
    }

    public async Task<ChatResponseDTO> GetChatByIdAsync(Guid id)
    {
        var chat = await _repository.GetByIdAsync(id);
        if (chat == null) throw new Exception("Chat not found");
        return _mapper.Map<ChatResponseDTO>(chat);
    }

    public async Task<CreateChatResponseDTO> CreateChatAsync(ChatCreateDTO dto)
    {
        var chat = _mapper.Map<Chat>(dto);
        await _repository.AddAsync(chat);
        return _mapper.Map<CreateChatResponseDTO>(chat);
    }

    public async Task<bool> DeleteChatAsync(Guid id)
    {
        var chat = await _repository.GetByIdAsync(id);
        if (chat == null) throw new Exception("Chat not found");

        await _repository.DeleteAsync(chat);
        return true;
    }
}