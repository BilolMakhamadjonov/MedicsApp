using Medics.Application.DtoModels.Pharmacy;

namespace Medics.Application.Service;

public interface IPharmacyService
{
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UpdatePharmacyResponseDTO> UpdateAsync(Guid id, PharmacyUpdateDTO model, CancellationToken cancellationToken = default);
    Task<CreatePharmacyResponseDTO> CreateAsync(PharmacyCreateDTO model, CancellationToken cancellationToken = default);
    Task<PharmacyResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<PharmacyResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
}