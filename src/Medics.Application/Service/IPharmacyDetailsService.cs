using Medics.Application.DtoModels;
using Medics.Application.DtoModels.PharmacyDetails;

namespace Medics.Application.Service;

public interface IPharmacyDetailsService
{
    Task<List<PharmacyDetailsResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PharmacyDetailsResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CreatePharmacyDetailsResponseDTO> CreateAsync(PharmacyDetailsCreateDTO model, CancellationToken cancellationToken = default);
    Task<UpdatePharmacyDetailsResponseDTO> UpdateAsync(Guid id, PharmacyDetailsUpdateDTO model, CancellationToken cancellationToken = default);
    Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
