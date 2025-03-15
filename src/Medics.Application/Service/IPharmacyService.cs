using Medics.Application.DtoModels;
using Medics.Application.DtoModels.Pharmacy;
using System.Linq.Expressions;

namespace Medics.Application.Service;

public interface IPharmacyService
{
    Task<List<PharmacyResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CreatePharmacyResponseDTO> CreateAsync(PharmacyCreateDTO createPharmacyModel, CancellationToken cancellationToken = default);
    Task<UpdatePharmacyResponseDTO> UpdateAsync(Guid id, PharmacyUpdateDTO updatePharmacyModel, CancellationToken cancellationToken = default);
    Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}