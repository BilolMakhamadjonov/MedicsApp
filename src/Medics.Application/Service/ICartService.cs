using Medics.Application.DtoModels;
using Medics.Application.DtoModels.Cart;

namespace Medics.Application.Service;

public interface ICartService
{
    Task<List<CartResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CartResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CreateCartResponseDTO> CreateAsync(CartCreateDTO model, CancellationToken cancellationToken = default);
    Task<UpdateCartResponseDTO> UpdateAsync(Guid id, CartUpdateDTO model, CancellationToken cancellationToken = default);
    Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
