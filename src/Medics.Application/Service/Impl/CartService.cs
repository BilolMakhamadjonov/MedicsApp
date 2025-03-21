using AutoMapper;
using Medics.Application.DtoModels;
using Medics.Application.DtoModels.Cart;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl;

public class CartService : ICartService
{
    private readonly IMapper _mapper;
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<List<CartResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var carts = await _cartRepository.GetAllAsync();
        return _mapper.Map<List<CartResponseDTO>>(carts);
    }

    public async Task<CartResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await _cartRepository.GetByIdAsync(id);
        return cart == null ? null : _mapper.Map<CartResponseDTO>(cart);
    }

    public async Task<CreateCartResponseDTO> CreateAsync(CartCreateDTO model, CancellationToken cancellationToken = default)
    {
        var cart = _mapper.Map<Cart>(model);
        await _cartRepository.AddAsync(cart);
        return new CreateCartResponseDTO { Id = cart.Id };
    }

    public async Task<UpdateCartResponseDTO> UpdateAsync(Guid id, CartUpdateDTO model, CancellationToken cancellationToken = default)
    {
        var cart = await _cartRepository.GetByIdAsync(id);
        if (cart == null) throw new Exception("Cart not found.");

        _mapper.Map(model, cart);
        await _cartRepository.UpdateAsync(cart);
        return new UpdateCartResponseDTO { Id = cart.Id };
    }

    public async Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await _cartRepository.GetByIdAsync(id);
        if (cart == null) return new BaseResponseDTO { Id = id, Success = false, Message = "Cart not found" };

        await _cartRepository.DeleteAsync(cart);
        return new BaseResponseDTO { Id = id, Success = true, Message = "Cart deleted successfully" };
    }
}
