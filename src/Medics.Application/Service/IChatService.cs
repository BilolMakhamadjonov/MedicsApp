using Medics.Application.DtoModels.Chat;

namespace Medics.Application.Service;

public interface IChatService
{
    Task<List<ChatResponseDTO>> GetAllChatsAsync();
    Task<ChatResponseDTO> GetChatByIdAsync(Guid id);
    Task<ChatResponseDTO> CreateChatAsync(ChatCreateDTO dto);
    Task<bool> DeleteChatAsync(Guid id);
}